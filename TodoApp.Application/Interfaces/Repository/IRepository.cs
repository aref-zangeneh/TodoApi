using System.Linq.Expressions;

namespace TodoApp.Application.Interfaces.Repository;

/// <summary>
/// CRUD operations with a Generic Repository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// get all entity objects
    /// </summary>
    /// <returns></returns>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// get entity object by identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// add a new entity object
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// update an existing entity object
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// delete an entity object by identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// find entity objects based on a predicate (delegate)
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
