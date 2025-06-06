namespace ProductApi.Dto.Product;

public class NonPersistentProductDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public NonPersistentCategoryDto Category { get; set; } = null!;
}

public class NonPersistentCategoryDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
}
