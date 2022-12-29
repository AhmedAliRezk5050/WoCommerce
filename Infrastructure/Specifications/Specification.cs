using System.Linq.Expressions;
using Core.Interfaces.Specifications;

namespace Infrastructure.Specifications;

public class Specification<T> : ISpecification<T>
{
    public Specification() {}
    
    public Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>>? Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}