using statejitsss.RabbitMQ.Models;

namespace statejitsss.RabbitMQ.Interfaces
{
    public interface IConsumeLogRepository
    {
        Task InsertNewLog(NewConsumeLogModel newConsumeLog);
    }
}
