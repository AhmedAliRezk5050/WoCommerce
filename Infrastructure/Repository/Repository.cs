using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Specifications;
using Infrastructure.Data;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    internal readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public Task<List<T>> GetAllAsync() =>  _dbSet.AsNoTracking().ToListAsync();

    public Task<List<T>> GetAllAsync(ISpecification<T> specification) =>
        ApplySpecification(specification).AsNoTracking().ToListAsync();

    public Task<T?> GetFirstOrDefaultAsync(ISpecification<T> specification) => ApplySpecification(specification).FirstOrDefaultAsync();

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> range)
    {
        _dbSet.RemoveRange(range);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);
    }
}