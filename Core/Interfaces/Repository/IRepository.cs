using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Specifications;

namespace Core.Interfaces.Repository;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetFirstOrDefaultAsync(ISpecification<T> specification);

    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(ISpecification<T> specification);

    void Add(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> range);
}