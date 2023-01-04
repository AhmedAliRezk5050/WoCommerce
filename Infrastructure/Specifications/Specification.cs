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
    
    public Expression<Func<T, object>>? OrderByAscending { get; private set;}
    public Expression<Func<T, object>>? OrderByDescending { get; private set;}

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddOrderByAscending(Expression<Func<T, object>> expression)
    {
        OrderByAscending = expression;
    }
    
    protected void AddOrderByDescending(Expression<Func<T, object>> expression)
    {
        OrderByDescending = expression;
    }
}