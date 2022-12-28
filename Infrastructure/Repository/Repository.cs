using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Repository;
using Infrastructure.Data;
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

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, List<string>? includedProperties = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includedProperties is null) return query.ToListAsync();
        
        foreach (var c in includedProperties)
        {
            query = query.Include(c);
        }

        return query.ToListAsync();
    }

    public Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, List<string>? includedProperties = null)
    {
        var query = _dbSet.Where(filter);

        if (includedProperties is null) return query.FirstOrDefaultAsync();
        
        foreach (var c in includedProperties)
        {
            query = query.Include(c);
        }

        return query.FirstOrDefaultAsync();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> range)
    {
        _dbSet.RemoveRange(range);
    }
}