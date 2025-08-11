namespace statejitsss.DAL.Interfaces
{
    public interface IDapperRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string tableName);
        Task<T?> GetByIdAsync(string tableName, string idColumn, object id);
        Task<int> InsertAsync(string tableName, object parameters);
        Task<int> UpdateAsync(string tableName, string idColumn, object parameters);
        Task<int> DeleteAsync(string tableName, string idColumn, object id);
    }
}
