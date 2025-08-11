using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace statejitsss.RabbitMQ.Config
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;
        private readonly ConnectionFactory _factory;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"],
                Port = int.Parse(_configuration["RabbitMQ:Port"]),
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"],
            };
        }
        public void Publish<T>(string routingKey, T message, string exchange = "") where T : class
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: routingKey,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: messageBody);
            }
        }
        public async Task<string> GetPayloadRabbitMQAsync<T>(string queueName)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare the queue (ensure it exists)
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Use BasicGet to get a message from the queue (non-blocking)
                var result = channel.BasicGet(queue: queueName, autoAck: true);

                if (result == null)
                {
                    Console.WriteLine($"No Message [Received] {queueName}");
                    return null; // No message in the queue
                }

                var body = result.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Received] Raw Message: {message}");
                return await Task.FromResult(message); // Return the message
            }
        }
        public void Consume<T>(string queueName, Func<T, Task> handleMessage) where T : class
        {
            var connection = _factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Received] Raw Message: {message}"); // Log raw message

                try
                {
                    var data = JsonSerializer.Deserialize<T>(message);
                    if (data != null)
                    {
                        await handleMessage(data);
                    }

                    // Acknowledge the message
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                    // Optionally, handle error (retry logic, logging, etc.)
                    // channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true); // Uncomment if you want to requeue on failure
                }
            };

            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }
    }
}
