using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using statejitsss.RabbitMQ.Enum;
using statejitsss.RabbitMQ.Interfaces;
using statejitsss.RabbitMQ.Models;
using System.Text.Json;
using System.Text;

namespace statejitsss.RabbitMQ.Config
{
    public abstract class RabbitMQConsumerBase<T> : BackgroundService where T : class
    {
        private IConnection? _connection;
        private IModel? _channel;
        private readonly ILogger _logger;
        private readonly string _queueName;
        private readonly string _errorQueueName;
        private readonly IRabbitMQConnectionFactory _connectionFactory;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly NewConsumeLogModel _newConsumeLog;

        protected RabbitMQConsumerBase(
            ILogger logger,
            IRabbitMQConnectionFactory connectionFactory,
            IServiceScopeFactory serviceScopeFactory,
            string queueName)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
            _serviceScopeFactory = serviceScopeFactory;
            _queueName = queueName;
            _errorQueueName = $"{_queueName}_error";
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _newConsumeLog = new NewConsumeLogModel { QueueName = queueName };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ConnectAndConsume(stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in consumer execution. Retrying...");
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }
        }

        private async Task ConnectAndConsume(CancellationToken stoppingToken)
        {
            _connection = await _connectionFactory.CreateConnectionAsync(stoppingToken);
            _channel = await _connectionFactory.CreateChannelAsync(stoppingToken);

            _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueDeclare(_errorQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.BasicQos(0, 1, false);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += HandleMessageAsync;

            _channel.BasicConsume(_queueName, autoAck: false, consumer);

            try
            {
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Consumer shutdown requested");
            }
        }

        private async Task HandleMessageAsync(object sender, BasicDeliverEventArgs ea)
        {
            _newConsumeLog.Reset();
            _newConsumeLog.ConsumedAt = DateTime.Now;

            using var scope = _serviceScopeFactory.CreateScope();
            var messageProcessor = scope.ServiceProvider.GetRequiredService<IMessageProcessor<T>>();
            var consumeLog = scope.ServiceProvider.GetRequiredService<IConsumeLogRepository>();
            _logger.LogInformation(($"Message receiving from queue: {_queueName}"));
            try
            {
                var message = Encoding.UTF8.GetString(ea.Body.Span);
                var isRedelivered = ea.Redelivered;
                _newConsumeLog.MessageBody = message;

                if (await ProcessMessageAsync(message, isRedelivered, messageProcessor, consumeLog))
                    _channel?.BasicAck(ea.DeliveryTag, false);
                else
                    _channel?.BasicNack(ea.DeliveryTag, false, !isRedelivered);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Message processing failed");
                _channel?.BasicNack(ea.DeliveryTag, false, true);
                _newConsumeLog.Status = ConsumeStatusEnums.FAILED;
                _newConsumeLog.ErrorType = "ProcessingError";
                _newConsumeLog.ErrorMessages = ex.Message;
                await consumeLog.InsertNewLog(_newConsumeLog);
            }
        }

        private async Task<bool> ProcessMessageAsync(string message, bool isRedelivered, IMessageProcessor<T> processor, IConsumeLogRepository logRepo)
        {
            try
            {
                var payload = JsonSerializer.Deserialize<T>(message, _jsonOptions);
                if (payload == null)
                {
                    await PublishErrorAsync(message, "Deserialization", new[] {
                        new ValidationErrorModel { PropertyName = "Message", ErrorMessage = "Deserialization returned null" }
                    }, logRepo);
                    return true;
                }

                _logger.LogInformation($"Message  Deserialised{payload}");
                var validationResult = await processor.ValidateMessage(payload);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => new ValidationErrorModel
                    {
                        PropertyName = e.PropertyName,
                        ErrorMessage = e.ErrorMessage
                    });

                    await PublishErrorAsync(message, "ValidationFailure", errors, logRepo);
                    return true;
                }

                await processor.ProcessMessage(payload);
                _newConsumeLog.Status = ConsumeStatusEnums.SUCCESS;
                _logger.LogInformation("Message receiving..");
                await logRepo.InsertNewLog(_newConsumeLog);
                return true;
            }
            catch (JsonException ex)
            {
                await PublishErrorAsync(message, "DeserializationError", new[] {
                    new ValidationErrorModel { PropertyName = "Message", ErrorMessage = ex.Message }
                }, logRepo);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error during message processing");
                _newConsumeLog.Status = ConsumeStatusEnums.FAILED;
                _newConsumeLog.ErrorType = "ProcessingError";
                _newConsumeLog.ErrorMessages = ex.Message;
                await logRepo.InsertNewLog(_newConsumeLog);
                return false;
            }
        }

        private async Task PublishErrorAsync(string message, string errorType, IEnumerable<ValidationErrorModel> errors, IConsumeLogRepository logRepo)
        {
            if (_channel == null) return;

            var errorPayload = new ErrorPayloadModel
            {
                OriginalMessage = message,
                ErrorType = errorType,
                ValidationErrors = errors,
                Timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(errorPayload, _jsonOptions);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", routingKey: _errorQueueName, basicProperties: null, body: body);

            _newConsumeLog.Status = ConsumeStatusEnums.FAILED;
            _newConsumeLog.ErrorType = errorType;
            _newConsumeLog.ErrorMessages = JsonSerializer.Serialize(errors);
            await logRepo.InsertNewLog(_newConsumeLog);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping consumer");
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
