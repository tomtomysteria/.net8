using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Product;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Clavier", Price = 49.99M },
        new Product { Id = 2, Name = "Souris", Price = 29.99M }
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
    product.Id = products.Max(p => p.Id) + 1;
    products.Add(product);
    return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Product updatedProduct)
  {
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product == null) return NotFound("Produit non trouvé.");

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
}
