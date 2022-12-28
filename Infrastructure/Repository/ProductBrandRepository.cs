using Core.Entities;
using Core.Interfaces.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
{
    public ProductBrandRepository(AppDbContext context) : base(context)
    {
    }

    public void Update(ProductBrand productBrand)
    {
        productBrand.UpdatedAt = DateTime.Now;
        _dbSet.Update(productBrand);
    }
}