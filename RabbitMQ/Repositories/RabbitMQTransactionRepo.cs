using Dapper;
using statejitsss.DAL;
using statejitsss.RabbitMQ.Interfaces;

namespace statejitsss.RabbitMQ.Repositories
{
    public class RabbitMQTransactionRepo : IRabbitMQTransactionRepo
    {
        private readonly DapperContext _dapperontext;
        public RabbitMQTransactionRepo(StateJitDbContext context, DapperContext dapperontext)
        {
            _dapperontext = dapperontext;
        }

        public async Task<bool> AddTransaction(string queue_name, string payload, string created_by)
        {
            var query = @"insert into transaction.rabbitmq_log (queue_name, payload, created_by)
                         values(@queue_name, @payload::jsonb, @created_by)";

            using (var connection = _dapperontext.CreateConnection())
            {
                var parameters = new
                {
                    queue_name = queue_name,
                    payload = payload,
                    created_by = created_by,
                };

                int st = await connection.ExecuteAsync(query, parameters);
                return (st > 0);
            }
        }

        public async Task<bool> LogErrorAsync(string queueName, string payload, string errorMessage, string? createdBy = "System")
        {
            var query = @"
                INSERT INTO transaction.rabbitmq_error_log
                    (queue_name, payload, error_message, created_by)
                VALUES
                    (@QueueName, @Payload::jsonb, @ErrorMessage, @CreatedBy)";

            using (var connection = _dapperontext.CreateConnection())
            {
                var parameters = new
                {
                    QueueName = queueName,
                    Payload = payload,
                    ErrorMessage = errorMessage,
                    CreatedBy = createdBy
                };

                int rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> LogProcessedResultAsync(string queueName, string refNo, bool success, string errorMessage, string payload, string createdBy = "System")
        {
            var query = @"
        INSERT INTO txn.operation_logs
            (success, error_message, ref_no, queue_name, payload, created_by)
        VALUES
            (@Success, @ErrorMessage, @RefNo, @QueueName, @Payload::jsonb, @CreatedBy)";

            using (var connection = _dapperontext.CreateConnection())
            {
                var parameters = new
                {
                    Success = success,
                    ErrorMessage = errorMessage,
                    RefNo = refNo,
                    QueueName = queueName,
                    Payload = payload,
                    CreatedBy = createdBy
                };

                int rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }

    }
}
