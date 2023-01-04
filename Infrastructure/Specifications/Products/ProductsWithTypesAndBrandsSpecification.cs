using Core.Entities;

namespace Infrastructure.Specifications.Products;

public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpecification(ProductsSpecParams specParams)
        : base(product => (!specParams.TypeId.HasValue || specParams.TypeId == product.ProductTypeId)
                          &&
                          (!specParams.BrandId.HasValue || specParams.BrandId == product.ProductBrandId))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);

        if (!string.IsNullOrEmpty(specParams.Sort))
        {
            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderByAscending(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                case "nameAsc":
                    AddOrderByAscending(x => x.Name);
                    break;
                case "nameDesc":
                    AddOrderByDescending(x => x.Name);
                    break;
            }
        }

        ApplyPaging((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
    }
}