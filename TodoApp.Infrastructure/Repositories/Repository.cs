using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoApp.Application.Interfaces.Repository;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly TodoAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Ctor

        public Repository(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods
        /// <summary>
        /// get all entity objects asynchronously
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// get entity object by identifier asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// add a new entity object asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// update an existing entity object asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete an entity object by identifier asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// find entity objects based on a predicate (delegate) asynchronously
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        #endregion

    }
}
