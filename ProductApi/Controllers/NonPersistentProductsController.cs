using Microsoft.AspNetCore.Mvc;
using ProductApi.Dto.Product;
using ProductApi.Models.Product;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/non-persistent/products")]
public class NonPersistentProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Clavier", Price = 49.99M, Category = new Category { Id = 1, Name = "Electronics" } },
        new Product { Id = 2, Name = "Souris", Price = 29.99M, Category = new Category { Id = 1, Name = "Electronics" } }
    };

    [HttpGet]
    public ActionResult<IEnumerable<NonPersistentProductDto>> GetAll()
    {
        var productDtos = products.Select(p => new NonPersistentProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Category = new NonPersistentCategoryDto
            {
                Id = p.Category.Id,
                Name = p.Category.Name
            }
        }).ToList();

        return Ok(productDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<NonPersistentProductDto> GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound("Produit non trouvé.");

        var productDto = new NonPersistentProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = new NonPersistentCategoryDto
            {
                Id = product.Category.Id,
                Name = product.Category.Name
            }
        };

        return Ok(productDto);
    }

    [HttpPost]
    public ActionResult<NonPersistentProductDto> Create(NonPersistentCreateOrUpdateProductDto createProductDto)
    {
        if (string.IsNullOrWhiteSpace(createProductDto.Name))
        {
            return BadRequest("Le nom du produit ne peut pas être vide.");
        }

        if (createProductDto.Price <= 0)
        {
            return BadRequest("Le prix du produit doit être supérieur à zéro.");
        }

        var product = new Product
        {
            Id = products.Max(p => p.Id) + 1,
            Name = createProductDto.Name,
            Price = createProductDto.Price,
            Category = new Category
            {
                Id = createProductDto.CategoryId,
                Name = createProductDto.CategoryName
            }
        };

        products.Add(product);

        var productDto = new NonPersistentProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = new NonPersistentCategoryDto
            {
                Id = product.Category.Id,
                Name = product.Category.Name
            }
        };

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, productDto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, NonPersistentCreateOrUpdateProductDto updateProductDto)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound($"Aucun produit trouvé avec l'ID {id}.");
        }

        if (string.IsNullOrWhiteSpace(updateProductDto.Name))
        {
            return BadRequest("Le nom du produit ne peut pas être vide.");
        }

        if (updateProductDto.Price <= 0)
        {
            return BadRequest("Le prix du produit doit être supérieur à zéro.");
        }

        product.Name = updateProductDto.Name;
        product.Price = updateProductDto.Price;
        product.Category = new Category
        {
            Id = updateProductDto.CategoryId,
            Name = updateProductDto.CategoryName
        };

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
    public ActionResult<IEnumerable<NonPersistentProductDto>> GetByCategory(string category)
    {
        var filteredProducts = products
            .Where(p => string.Equals(p.Category.Name, category, StringComparison.OrdinalIgnoreCase))
            .Select(p => new NonPersistentProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = new NonPersistentCategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .ToList();

        if (!filteredProducts.Any()) return NotFound("Aucun produit trouvé pour cette catégorie.");

        return Ok(filteredProducts);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<NonPersistentProductDto>> Search([FromQuery] string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return BadRequest("Le terme de recherche ne peut pas être vide.");
        }

        var matchingProducts = products
            .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
            .Select(p => new NonPersistentProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = new NonPersistentCategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .ToList();

        if (!matchingProducts.Any())
        {
            return NotFound($"Aucun produit trouvé contenant le terme '{term}'.");
        }

        return Ok(matchingProducts);
    }
}
