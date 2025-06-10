using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Dto.Product;
using ProductApi.Models.Product;

namespace ProductApi.GraphQL;

public class Mutation
{
  public async Task<Product> AddProduct(CreateOrUpdateProductDto productDto, ProductDbContext context)
  {
    var category = await context.Categories.FindAsync(productDto.CategoryId);
    if (category == null)
      throw new KeyNotFoundException("Catégorie non trouvée.");

    var tags = await context.Tags
        .Where(t => productDto.TagIds.Contains(t.Id))
        .ToListAsync();

    var product = new Product
    {
      Name = productDto.Name,
      Price = productDto.Price,
      Stock = productDto.Stock,
      CategoryId = productDto.CategoryId,
      Category = category,
      ProductDetail = new ProductDetail
      {
        Description = productDto.ProductDetail.Description,
        Manufacturer = productDto.ProductDetail.Manufacturer
      },
      Tags = tags // Association des tags
    };

    context.Products.Add(product);
    await context.SaveChangesAsync();

    return product;
  }

  public async Task<bool> DeleteProduct(int id, [Service] ProductDbContext context)
  {
    var product = await context.Products.FindAsync(id);

    if (product == null)
    {
      throw new KeyNotFoundException("Produit non trouvé.");
    }

    context.Products.Remove(product);
    await context.SaveChangesAsync();

    return true; // Retourne true si la suppression a réussi
  }
}
