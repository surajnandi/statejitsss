namespace statejitsss.RabbitMQ.Models
{
    public class NewConsumeLogModel
    {
        public string? MessageId { get; set; }
        public string QueueName { get; set; } = null!;
        public string? ExchangeName { get; set; }
        public string? RaoutingKey { get; set; }
        public string? MessageBody { get; set; }
        public string? Status { get; set; }
        public string? ErrorMessages { get; set; }
        public string? ErrorType { get; set; }
        public DateTime ConsumedAt { get; set; } = DateTime.UtcNow;

        public void Reset()
        {
            MessageId = null;
            ExchangeName = null;
            RaoutingKey = null;
            MessageBody = null;
            Status = null;
            ErrorMessages = null;
            ErrorType = null;
            ConsumedAt = DateTime.UtcNow;
            // QueueName is intentionally not reset
        }
    }

    public class ValidationErrorModel
    {
        public string PropertyName { get; set; } = default!;
        public string ErrorMessage { get; set; } = default!;
    }
    public class ErrorPayloadModel
    {
        public string OriginalMessage { get; set; } = default!;
        public string ErrorType { get; set; } = default!;
        public IEnumerable<ValidationErrorModel> ValidationErrors { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}
