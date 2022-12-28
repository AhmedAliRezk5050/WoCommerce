namespace Core.Entities;

public class ProductType : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}