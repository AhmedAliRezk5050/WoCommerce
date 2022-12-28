using Core.Entities;

namespace Core.Interfaces.Repository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
}