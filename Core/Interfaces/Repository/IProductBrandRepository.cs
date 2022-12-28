using Core.Entities;

namespace Core.Interfaces.Repository;

public interface IProductBrandRepository : IRepository<ProductBrand>
{
    void Update(ProductBrand productBrand);
}