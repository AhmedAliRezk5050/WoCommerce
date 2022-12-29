namespace API.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    public string ProductBrand { get; set; } = null!;
    public string ProductType { get; set; } = null!;
}