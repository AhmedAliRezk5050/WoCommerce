using System.Linq.Expressions;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Specifications.Products;

public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpecification(string? sort = null)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);

        if (!string.IsNullOrEmpty(sort))
        {
            switch (sort)
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
    }
}