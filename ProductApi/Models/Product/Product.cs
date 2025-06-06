namespace ProductApi.Models.Product;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; } = 0;

    // Many-to-One relation with Category
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // Many-to-Many relation with Tag
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    // One-to-One relation with ProductDetail
    public ProductDetail ProductDetail { get; set; } = null!;
}
