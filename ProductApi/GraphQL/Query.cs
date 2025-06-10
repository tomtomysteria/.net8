using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models.Product;

namespace ProductApi.GraphQL;

public class Query
{
    // Récupère tous les produits avec leurs relations
    public static IQueryable<Product> GetProducts([Service] ProductDbContext context) =>
        context.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.ProductDetail);

    // Récupère un produit par son ID
    public static Product? GetProductById(int id, [Service] ProductDbContext context) =>
        context.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.ProductDetail)
            .FirstOrDefault(p => p.Id == id);
}
