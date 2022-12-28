using Core.Entities;

namespace Core.Interfaces.Repository;

public interface IProductTypeRepository : IRepository<ProductType>
{
    void Update(ProductType productType);
}