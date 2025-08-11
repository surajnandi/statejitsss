namespace statejitsss.RabbitMQ.Config
{
    public interface IRabbitMqService
    {
        void Publish<T>(string routingKey, T message, string exchange = "") where T : class;
        //void Consume<T>(string queueName, Action<T> handleMessage) where T : class;
        Task<string> GetPayloadRabbitMQAsync<T>(string queueName);
        void Consume<T>(string queueName, Func<T, Task> handleMessage) where T : class;
    }
}
