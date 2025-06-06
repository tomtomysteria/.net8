namespace ProductApi.Models.Product;

public class Category
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;

  // One-to-Many relation with Product
  public ICollection<Product> Products { get; set; } = new List<Product>();
}
