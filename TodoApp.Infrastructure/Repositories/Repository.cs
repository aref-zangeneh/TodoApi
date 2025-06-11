using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoApp.Application.Interfaces.Repository;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class, IBaseEntity
{
    #region Fields

    private readonly TodoAppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    #endregion

    #region Ctor

    public Repository(TodoAppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    #endregion

    #region Methods
    /// <summary>
    /// get all entity objects asynchronously
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    /// <summary>
    /// get entity object by identifier asynchronously
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
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
    public virtual async Task<T> UpdateAsync(T entity)
    {
        if (entity == null || entity.Id == Guid.Empty)
            throw new ArgumentException("entity does not have a valid id");

        var local = _dbSet.Local.FirstOrDefault(e => e.Id.Equals(entity.Id));
        if (local != null)
        {
            _dbContext.Entry(local).State = EntityState.Detached;
        }

        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return entity;
    }


    /// <summary>
    /// delete an entity object by identifier asynchronously
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<T> DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        throw new KeyNotFoundException($"entity with id {id} not found.");
    }

    /// <summary>
    /// find entity objects based on a predicate (delegate) asynchronously
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }
    #endregion

}

