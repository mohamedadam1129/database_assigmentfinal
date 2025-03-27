using database_assigmentfinal.DataContext;
using System.Linq.Expressions;

namespace database_assigmentfinal.Repositories
    {
        public interface IBaseRepository<TEntity> where TEntity : class
        {
            Task AddAsync(TEntity entity);
            Task<IEnumerable<TEntity>> GetAsync();
            Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
            Task UpdateAsync(TEntity entity);
            Task RemoveAsync(TEntity entity);
        }
        }
    