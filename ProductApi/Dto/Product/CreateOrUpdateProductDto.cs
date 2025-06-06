namespace ProductApi.Dto.Product;

public class CreateOrUpdateProductDto
{
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public int CategoryId { get; set; }
  public ICollection<int> TagIds { get; set; } = new List<int>();
  public CreateOrUpdateProductDetailDto ProductDetail { get; set; } = null!;
}

public class CreateOrUpdateProductDetailDto
{
  public string Description { get; set; } = string.Empty;
  public string Manufacturer { get; set; } = string.Empty;
}
