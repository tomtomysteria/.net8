namespace ProductApi.Models.Product;

public class ProductDetail
{
  public int Id { get; set; }
  public string Description { get; set; } = string.Empty;
  public string Manufacturer { get; set; } = string.Empty;

  // One-to-One relation with Product
  public int ProductId { get; set; }
  public Product Product { get; set; } = null!;
}
