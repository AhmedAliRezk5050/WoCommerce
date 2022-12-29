using System.Linq.Expressions;
using Core.Entities;

namespace Infrastructure.Specifications.Products;

public class ProductWithTypesAndBrandsSpecification : Specification<Product>
{

    public ProductWithTypesAndBrandsSpecification(int id) : base(product => product.Id == id)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}