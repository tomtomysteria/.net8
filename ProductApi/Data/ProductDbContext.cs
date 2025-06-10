using Microsoft.EntityFrameworkCore;
using ProductApi.Models.Product;

namespace ProductApi.Data;

public class ProductDbContext : DbContext
{
  public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<ProductTag> Tags { get; set; }
  public DbSet<ProductDetail> ProductDetails { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>().ToTable("product");
    modelBuilder.Entity<Category>().ToTable("category");
    modelBuilder.Entity<ProductTag>().ToTable("tag");
    modelBuilder.Entity<ProductDetail>().ToTable("product_detail");

    // Many-to-One relation between Product and Category
    modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId);


    // Many-to-Many relation between Product and Tag
    modelBuilder.Entity<Product>()
        .HasMany(p => p.Tags)
        .WithMany(t => t.Products)
        .UsingEntity(j => j.ToTable("product_tag"));

    // One-to-One relation between Product and ProductDetail
    modelBuilder.Entity<Product>()
        .HasOne(p => p.ProductDetail)
        .WithOne(pd => pd.Product)
        .HasForeignKey<ProductDetail>(pd => pd.ProductId);
  }
}
