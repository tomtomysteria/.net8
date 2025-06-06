namespace ProductApi.Dto.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public CategoryDto Category { get; set; } = null!;
    public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();
    public ProductDetailDto ProductDetail { get; set; } = null!;
}

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class TagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProductDetailDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}
