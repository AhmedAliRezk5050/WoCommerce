using System.Linq.Expressions;
using Core.Entities;

namespace Infrastructure.Specifications.Products;

public class ProductByIdSpecification : Specification<Product>
{
    public ProductByIdSpecification(Expression<Func<Product, bool>> criteria) : base(criteria)
    {
    }
}