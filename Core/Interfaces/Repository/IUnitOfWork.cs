namespace Core.Interfaces.Repository;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; set; }
    Task<bool> SaveAsync();
}