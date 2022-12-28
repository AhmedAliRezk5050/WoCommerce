using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seeding;

public static class Seed
{
    public static async Task SeedData(AppDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!dbContext.ProductBrands.Any())
        {
            var productBrandsData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeding/brands.json");
            var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
            if (productBrands != null) dbContext.ProductBrands.AddRange(productBrands);
        }
        
        if (!dbContext.ProductTypes.Any())
        {
            var productTypesData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeding/types.json");
            var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
            if (productTypes != null) dbContext.ProductTypes.AddRange(productTypes);
        }
        
        if (!dbContext.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products != null) dbContext.Products.AddRange(products);
        }
        
       

        await dbContext.SaveChangesAsync();
    }
}