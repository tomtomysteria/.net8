using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Product;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Clavier", Price = 49.99M, Category = "Electronics" },
        new Product { Id = 2, Name = "Souris", Price = 29.99M, Category = "Electronics" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Produit non trouvé.");
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return BadRequest("Le nom du produit ne peut pas être vide.");
        }

        if (product.Price <= 0)
        {
            return BadRequest("Le prix du produit doit être supérieur à zéro.");
        }

        product.Id = products.Max(p => p.Id) + 1;
        products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound($"Aucun produit trouvé avec l'ID {id}.");
        }

        if (string.IsNullOrWhiteSpace(updatedProduct.Name))
        {
            return BadRequest("Le nom du produit ne peut pas être vide.");
        }

        if (updatedProduct.Price <= 0)
        {
            return BadRequest("Le prix du produit doit être supérieur à zéro.");
        }

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Produit non trouvé.");

        products.Remove(product);
        return NoContent();
    }

    [HttpGet("category/{category}")]
    public ActionResult<IEnumerable<Product>> GetByCategory(string category)
    {
        var filteredProducts = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!filteredProducts.Any()) return NotFound("Aucun produit trouvé pour cette catégorie.");
        return Ok(filteredProducts);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Product>> Search([FromQuery] string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return BadRequest("Le terme de recherche ne peut pas être vide.");
        }

        var matchingProducts = products
            .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!matchingProducts.Any())
        {
            return NotFound($"Aucun produit trouvé contenant le terme '{term}'.");
        }

        return Ok(matchingProducts);
    }
}
