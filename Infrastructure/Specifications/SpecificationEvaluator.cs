using Core.Entities;
using Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Specifications;

public static class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(
        IQueryable<T> inputQuery,
        ISpecification<T> specification)
    {
        var query = inputQuery;

        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderByAscending is not null)
        {
            query = query.OrderBy(specification.OrderByAscending);
        }
        
        if (specification.OrderByDescending is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        query = specification.Includes
            .Aggregate(query, (current, include)
                => current.Include(include));

        return query;
    }
}