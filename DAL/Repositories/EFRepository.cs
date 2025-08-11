using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using statejitsss.Helpers;
using System.Linq.Expressions;
using statejitsss.DAL.Interfaces;

namespace statejitsss.DAL.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        protected readonly StateJitDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(StateJitDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _dbContext.Database.CreateExecutionStrategy();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }

        public void SaveChangesManaged()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAManaged(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            _dbSet.Attach(entity);
            _dbContext.Entry<T>(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> condition)
        {
            return await this._dbContext.Set<T>().Where(condition).SingleOrDefaultAsync();
        }

        public bool Insert(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
            return true;
        }

        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().Where(condition).SingleOrDefaultAsync();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this._dbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }
            return result;
        }

        public bool Add(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            return true;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this._dbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }
            return await result.ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().Where(condition).FirstOrDefaultAsync();
        }

        public virtual async Task<PaginatedResponseObject<IEnumerable<T>>> GetAllDynamicAsync(QueryParameters queryParameters)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (queryParameters.Filters.Count() > 0)
            {
                query = query.ApplyFilters(queryParameters.Filters);
            }

            if (queryParameters.Sorts.Count() > 0)
            {
                query = query.ApplySorts(queryParameters.Sorts);
            }

            var totalItems = await query.CountAsync();

            var resultSet = await query
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();

            return (new PaginatedResponseObject<IEnumerable<T>>
            {
                TotalCount = totalItems,
                PageSize = queryParameters.PageSize,
                PageNumber = queryParameters.PageNumber,
                Data = resultSet
            });

        }

        public async Task ExecuteStoredProcedureAsync(string storedProcedureName, Dictionary<string, object> parameters)
        {
            var sql = $"CALL {storedProcedureName}({string.Join(", ", parameters.Keys.Select(k => "@" + k))})";

            var npgsqlParameters = parameters.Select(p =>
            {
                if (p.Value is NpgsqlParameter existingParam)
                {
                    return existingParam;
                }

                var param = new NpgsqlParameter("@" + p.Key, p.Value ?? DBNull.Value);
                return param;
            }).ToArray();
            await _dbContext.Database.ExecuteSqlRawAsync(sql, npgsqlParameters);
        }
    }
}
