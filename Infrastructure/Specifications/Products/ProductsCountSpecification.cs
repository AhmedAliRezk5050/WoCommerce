using Core.Entities;

namespace Infrastructure.Specifications.Products;

public class ProductsCountSpecification : Specification<Product>
{
    public ProductsCountSpecification(
        ProductsSpecParams specParams
    )
        : base(product => (!specParams.TypeId.HasValue || specParams.TypeId == product.ProductTypeId)
                          &&
                          (!specParams.BrandId.HasValue || specParams.BrandId == product.ProductBrandId))
    {
        
    }
}