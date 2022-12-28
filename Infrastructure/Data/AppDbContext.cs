using System.Reflection;
using Core.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductBrandEntityTypeConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductTypeEntityTypeConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<ProductBrand>().HasQueryFilter(pB => !pB.IsDeleted);
        modelBuilder.Entity<ProductType>().HasQueryFilter(pT => !pT.IsDeleted);
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductBrand> ProductBrands { get; set; } = null!;
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
}