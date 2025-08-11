using Dapper;
using statejitsss.RabbitMQ.Interfaces;
using statejitsss.RabbitMQ.Models;
using System.Data;

namespace statejitsss.RabbitMQ.Repositories
{
    public class ConsumeLogRepository : IConsumeLogRepository
    {
        private readonly IDbConnection _dbConnection;

        public ConsumeLogRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task InsertNewLog(NewConsumeLogModel newConsumeLog)
        {
            string sql = @"
            INSERT INTO txn.consume_logs_rabbitmq (
                message_id,
                queue_name,
                exchange_name,
                raouting_key,
                message_body,
                consumed_at,
                status,
                error_messages,
                error_type,
                created_at
            ) VALUES (
                @MessageId,
                @QueueName,
                @ExchangeName,
                @RaoutingKey,
                @MessageBody,
                @ConsumedAt,
                @Status,
                @ErrorMessages,
                @ErrorType,
                NOW()
            );";

            await _dbConnection.ExecuteAsync(sql, new
            {
                newConsumeLog.MessageId,
                newConsumeLog.QueueName,
                newConsumeLog.ExchangeName,
                newConsumeLog.RaoutingKey,
                newConsumeLog.MessageBody,
                newConsumeLog.ConsumedAt,
                newConsumeLog.Status,
                newConsumeLog.ErrorMessages,
                newConsumeLog.ErrorType
            });
        }
    }
}
