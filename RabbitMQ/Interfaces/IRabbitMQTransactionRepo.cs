namespace statejitsss.RabbitMQ.Interfaces
{
    public interface IRabbitMQTransactionRepo
    {
        Task<bool> AddTransaction(string queue_name, string payload, string created_by);
        Task<bool> LogErrorAsync(string queueName, string payload, string errorMessage, string? createdBy = "System");
        Task<bool> LogProcessedResultAsync(string queueName, string refNo, bool success, string errorMessage, string payload, string createdBy = "System");
    }
}
