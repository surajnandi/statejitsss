namespace statejitsss.RabbitMQ.Models
{
    public class RabbitMQConfigurationModel
    {
        public string HostName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string VirtualHost { get; set; } = "/";
        public int Port { get; set; } = 5672;
    }

    public class RabbitmqDetailsModel
    {
        public string name { get; set; }
        public string state { get; set; }
        public int messages { get; set; }
        public int messages_ready { get; set; }
        public int messages_unacknowledged { get; set; }
        public double publish_Rate { get; set; }
        public double consumeRate { get; set; }
    }
    public class InputModel
    {
        public string? QueueName { get; set; }
    }
}
