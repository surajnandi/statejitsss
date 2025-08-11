using RabbitMQ.Client;
using statejitsss.RabbitMQ.Models;

namespace statejitsss.RabbitMQ.Config
{
    public class RabbitMQConnectionFactory : IRabbitMQConnectionFactory, IDisposable
    {
        private readonly RabbitMQConfigurationModel _configuration;
        private readonly ILogger<RabbitMQConnectionFactory> _logger;
        private IConnection? _connection;
        private readonly SemaphoreSlim _connectionLock = new(1, 1);

        public RabbitMQConnectionFactory(RabbitMQConfigurationModel configuration, ILogger<RabbitMQConnectionFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
        {
            if (_connection?.IsOpen == true)
                return _connection;

            await _connectionLock.WaitAsync(cancellationToken);
            try
            {
                if (_connection?.IsOpen == true)
                    return _connection;

                var factory = new ConnectionFactory
                {
                    HostName = _configuration.HostName,
                    UserName = _configuration.UserName,
                    Password = _configuration.Password,
                    VirtualHost = _configuration.VirtualHost,
                    Port = _configuration.Port,
                    DispatchConsumersAsync = true // async consumers
                };

                _connection = factory.CreateConnection();
                _logger.LogInformation("Successfully connected to RabbitMQ");

                _connection.ConnectionShutdown += (_, e) =>
                {
                    _logger.LogWarning("RabbitMQ connection shutdown: {0}", e.ReplyText);
                    _connection = null;
                };

                return _connection;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to connect to RabbitMQ");
                throw;
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        public async Task<IModel> CreateChannelAsync(CancellationToken cancellationToken = default)
        {
            var connection = await CreateConnectionAsync(cancellationToken);
            return connection.CreateModel();
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connectionLock.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
