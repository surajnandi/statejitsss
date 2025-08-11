using RabbitMQ.Client;

namespace statejitsss.RabbitMQ.Config
{
    public interface IRabbitMQConnectionFactory
    {

        Task<IConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
        Task<IModel> CreateChannelAsync(CancellationToken cancellationToken = default);

    }
}
