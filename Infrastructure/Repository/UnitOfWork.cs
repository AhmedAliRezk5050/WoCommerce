using Core.Interfaces.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public IProductRepository ProductRepository { get; set; }
    public IProductTypeRepository ProductTypeRepository { get; set; }
    public IProductBrandRepository ProductBrandRepository { get; set; }

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        ProductRepository = new ProductRepository(dbContext);
        ProductTypeRepository = new ProductTypeRepository(dbContext);
        ProductBrandRepository = new ProductBrandRepository(dbContext);
    }

    public async Task<bool> SaveAsync()
    {
        return  await _dbContext.SaveChangesAsync() > 0;
    }
}