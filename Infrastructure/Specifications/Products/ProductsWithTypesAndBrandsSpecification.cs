using System.Linq.Expressions;
using Core.Entities;

namespace Infrastructure.Specifications.Products;

public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpecification()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}