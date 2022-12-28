namespace Core.Entities;

public class ProductBrand : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}