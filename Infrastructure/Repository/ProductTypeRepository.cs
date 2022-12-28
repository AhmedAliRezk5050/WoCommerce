using Core.Entities;
using Core.Interfaces.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
{
    public ProductTypeRepository(AppDbContext context) : base(context)
    {
    }

    public void Update(ProductType productType)
    {
        productType.UpdatedAt = DateTime.Now;
        _dbSet.Update(productType);
    }
}