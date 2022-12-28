namespace Core.Interfaces.Repository;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; set; }
    public IProductTypeRepository ProductTypeRepository { get; set; }
    public IProductBrandRepository ProductBrandRepository { get; set; }
    Task<bool> SaveAsync();
}