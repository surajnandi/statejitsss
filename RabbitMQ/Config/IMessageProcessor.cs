using FluentValidation.Results;

namespace statejitsss.RabbitMQ.Config
{
    public  interface IMessageProcessor<T> where T : class
    {
        Task<ValidationResult> ValidateMessage(T message);
        Task ProcessMessage(T message);
    }
}
