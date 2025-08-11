using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using statejitsss.RabbitMQ.Interfaces;
using System.Text;

namespace statejitsss.RabbitMQ.Helper
{
    public class RabbitMQHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _hostName;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _queue_name;
        private readonly string _queue_name_agency_ddo_mapping;

        private readonly string _queue_name_master_data_hoa_group_n_approval;
        //private readonly ITsaAgencymasterService _tsaAgencymasterService;
        private readonly IRabbitMQTransactionRepo _RabbitMQTransactionRepo;

        public RabbitMQHelper(IConfiguration configuration, /*ITsaAgencymasterService tsaAgencymasterService, */IRabbitMQTransactionRepo RabbitMQTransactionRepo)
        {
            _configuration = configuration;
            //_tsaAgencymasterService = tsaAgencymasterService;
            _RabbitMQTransactionRepo = RabbitMQTransactionRepo;

            // Fetch RabbitMQ connection details from configuration
            _hostName = _configuration["RabbitMQ:HostName"];
            _port = int.Parse(_configuration["RabbitMQ:Port"]);
            _userName = _configuration["RabbitMQ:UserName"];
            _password = _configuration["RabbitMQ:Password"];
            _queue_name = _configuration["RabbitMQ:QueueName"];

            _queue_name_agency_ddo_mapping = _configuration["RabbitMQ:QueueNameRequestAgencyDDOMapping"];
            _queue_name_master_data_hoa_group_n_approval = _configuration["RabbitMQ:QueueNameHOAMasterDataByGroupN"];
            //
            // TODO: Add constructor logic here
            //
        }
        public bool SendPayloadRabitMQ<T>(T obj)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port,
                UserName = _userName,
                Password = _password

            };

            // Optional: If you need to specify credentials
            //factory.UserName = "guest";
            //factory.Password = "guest";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare a queue (create if it doesn't exist)
                channel.QueueDeclare(queue: _queue_name,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string message = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(message);

                // Publish the message to the default exchange with the queue name as the routing key
                channel.BasicPublish(exchange: "",
                                    routingKey: _queue_name,
                                    basicProperties: null,
                                    body: body);

                Console.WriteLine($"[x] Sent {message}");
            }
            return true;
        }

        public void GetPayloadRabitMQ<T>(string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port,
                UserName = _userName,
                Password = _password
            };

            // Optional: If you need to specify credentials
            //factory.UserName = "guest";
            //factory.Password = "guest";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare the queue (ensure it exists)
                channel.QueueDeclare(queue: queueName,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                // Create a consumer to pull messages from the queue
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x-accpt] Received {message}");

                    // Optionally, deserialize message back to object of type T
                    // var obj = JsonConvert.DeserializeObject<T>(message);
                    // Handle deserialized object
                };

                // Start consuming messages from the queue
                channel.BasicConsume(queue: queueName,
                                    autoAck: true,
                                    consumer: consumer);

                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public bool SendPayloadRabitMQ<T>(T obj, string queue_name)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port,
                UserName = _userName,
                Password = _password

            };

            // Optional: If you need to specify credentials
            //factory.UserName = "guest";
            //factory.Password = "guest";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare a queue (create if it doesn't exist)
                channel.QueueDeclare(queue: queue_name,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string message = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(message);

                // Publish the message to the default exchange with the queue name as the routing key
                channel.BasicPublish(exchange: "",
                                    routingKey: queue_name,
                                    basicProperties: null,
                                    body: body);

                Console.WriteLine($"[x] Sent {message}");
            }
            return true;
        }

        //public async Task<bool> SendDDORequestPayloadRabitMQ(string agencyCode, string SlsCode, string userId)
        //{
        //    //var tsaAgencymaster = _tsaAgencymasterService.getAgencyMasterDataById(agencyCode,SlsCode).Result; // Replace with actual logic to fetch TSA AgencyMaster data
        //    AgencyCodeSLSMappingModel agency_ddo_map_data = _tsaAgencymasterService.getAgencyCodeDDOMapping(agencyCode, SlsCode).Result;

        //    var ddoRequestPayload = new DDORequestPayloadModel
        //    {
        //        Slscode = agency_ddo_map_data.SlsCode,
        //        Agencycode = agency_ddo_map_data.AgencyCode,
        //        Agencyname = agency_ddo_map_data.AgencyName,
        //        DdoCode = agency_ddo_map_data.DdoCode,
        //        TreasCode = agency_ddo_map_data.TreasCode,
        //        RequestMessage = "DDO Request Message" // Replace with actual request message
        //    };

        //    _ = await _RabbitMQTransactionRepo.AddTransaction(_queue_name_agency_ddo_mapping, JsonConvert.SerializeObject(ddoRequestPayload), userId);

        //    var output = SendPayloadRabitMQ(ddoRequestPayload, _queue_name_agency_ddo_mapping); // Replace with actual queue name

        //    return output;
        //}

    }
}
