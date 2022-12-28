using System.Linq.Expressions;

namespace Core.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, List<string>? includedProperties = null);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, List<string>? includedProperties = null);

    void Add(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> range);
}