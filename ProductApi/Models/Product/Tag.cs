namespace ProductApi.Models.Product;

public class Tag
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;

  // Many-to-Many relation with Product
  public ICollection<Product> Products { get; set; } = new List<Product>();
}
