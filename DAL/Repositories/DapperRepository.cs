using Dapper;
using statejitsss.DAL.Interfaces;

namespace statejitsss.DAL.Repositories
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        private readonly DapperContext _context;

        public DapperRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string tableName)
        {
            var query = $"SELECT * FROM {tableName}";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<T>(query);
        }

        public async Task<T?> GetByIdAsync(string tableName, string idColumn, object id)
        {
            var query = $"SELECT * FROM {tableName} WHERE {idColumn} = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<int> InsertAsync(string tableName, object parameters)
        {
            var columns = string.Join(", ", parameters.GetType().GetProperties().Select(p => p.Name));
            var values = string.Join(", ", parameters.GetType().GetProperties().Select(p => "@" + p.Name));

            var query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> UpdateAsync(string tableName, string idColumn, object parameters)
        {
            var props = parameters.GetType().GetProperties().Where(p => p.Name != idColumn);
            var setClause = string.Join(", ", props.Select(p => $"{p.Name}=@{p.Name}"));

            var query = $"UPDATE {tableName} SET {setClause} WHERE {idColumn}=@{idColumn}";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> DeleteAsync(string tableName, string idColumn, object id)
        {
            var query = $"DELETE FROM {tableName} WHERE {idColumn} = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
