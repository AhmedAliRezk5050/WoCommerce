using Core.Entities;
using Core.Interfaces.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public void Update(Product product)
    {
        _dbSet.Update(product);
    }
}