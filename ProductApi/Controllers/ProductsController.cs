using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Dto.Product;
using ProductApi.Models.Product;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    // ********** CONSTANTS AND STATIC FIELDS **********


    // ********** PRIVATE FIELDS **********
    private readonly ProductDbContext _context;

    // ********** CONSTRUCTOR **********
    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    // ********** PUBLIC PROPERTIES **********

    // ********** PUBLIC METHODS **********
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await GetProductDtoQuery().ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await GetProductDtoQuery().FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound("Produit non trouvé.");

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateOrUpdateProductDto createProductDto)
    {
        if (string.IsNullOrWhiteSpace(createProductDto.Name) || createProductDto.Price <= 0)
            return BadRequest("Nom ou prix invalide.");

        try
        {
            var product = await CreateOrUpdateProductAsync(createProductDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productDto = await GetProductDtoQuery().FirstOrDefaultAsync(p => p.Id == product.Id);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, productDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> Update(int id, CreateOrUpdateProductDto updateProductDto)
    {
        var product = await _context.Products
            .Include(p => p.Tags)
            .Include(p => p.ProductDetail)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound("Produit non trouvé.");

        if (string.IsNullOrWhiteSpace(updateProductDto.Name) || updateProductDto.Price <= 0)
            return BadRequest("Nom ou prix invalide.");

        try
        {
            product = await CreateOrUpdateProductAsync(updateProductDto, product);
            await _context.SaveChangesAsync();

            var productDto = await GetProductDtoQuery().FirstOrDefaultAsync(p => p.Id == product.Id);
            return Ok(productDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProduct(int id, JsonPatchDocument<Product> patchDocument)
    {
        if (patchDocument == null)
            return BadRequest("Le document de patch est requis.");

        var product = await _context.Products
            .Include(p => p.Tags)
            .Include(p => p.ProductDetail)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound("Produit non trouvé.");

        // Appliquer les modifications
        patchDocument.ApplyTo(product, ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound("Produit non trouvé.");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory(string category)
    {
        var filteredProducts = await GetProductDtoQuery()
            .Where(p => p.Category.Name.ToLower() == category.ToLower())
            .ToListAsync();

        if (!filteredProducts.Any())
            return NotFound("Aucun produit trouvé pour cette catégorie.");

        return Ok(filteredProducts);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Search([FromQuery] string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return BadRequest("Le terme de recherche ne peut pas être vide.");
        }

        var matchingProducts = await GetProductDtoQuery()
            .Where(p => p.Name.ToLower().Contains(term.ToLower()) || p.Category.Name.ToLower().Contains(term.ToLower()))
            .ToListAsync();

        if (!matchingProducts.Any())
        {
            return NotFound($"Aucun produit trouvé contenant le terme '{term}' dans le nom ou la catégorie.");
        }

        return Ok(matchingProducts);
    }

    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetSortedProducts([FromQuery] string by, [FromQuery] string order)
    {
        if (string.IsNullOrWhiteSpace(by) || string.IsNullOrWhiteSpace(order))
        {
            return BadRequest("Les paramètres 'by' et 'order' sont requis.");
        }

        IQueryable<ProductDto> query = GetProductDtoQuery();

        switch (by.ToLower())
        {
            case "id":
                query = order.ToLower() == "desc" ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                break;
            case "name":
                query = order.ToLower() == "desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                break;
            case "price":
                query = order.ToLower() == "desc" ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price);
                break;
            case "category":
                query = order.ToLower() == "desc" ? query.OrderByDescending(p => p.Category.Name) : query.OrderBy(p => p.Category.Name);
                break;
            case "stock":
                query = order.ToLower() == "desc" ? query.OrderByDescending(p => p.Stock) : query.OrderBy(p => p.Stock);
                break;
            default:
                return BadRequest($"Le critère '{by}' n'est pas valide. Utilisez 'id', 'name', 'price', 'category', ou 'stock'.");
        }

        var sortedProducts = await query.ToListAsync();

        if (!sortedProducts.Any())
        {
            return NotFound("Aucun produit trouvé.");
        }

        return Ok(sortedProducts);
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<ProductDetailDto>> GetProductDetails(int id)
    {
        var productDetail = await _context.ProductDetails
            .Where(pd => pd.ProductId == id)
            .Select(pd => new ProductDetailDto
            {
                Id = pd.Id,
                Description = pd.Description,
                Manufacturer = pd.Manufacturer
            })
            .FirstOrDefaultAsync();

        if (productDetail == null)
            return NotFound("Détails du produit non trouvés.");

        return Ok(productDetail);
    }

    [HttpPut("{id}/details")]
    public async Task<IActionResult> UpdateProductDetails(int id, ProductDetailDto updatedDetailsDto)
    {
        var productDetail = await _context.ProductDetails.FirstOrDefaultAsync(pd => pd.ProductId == id);

        if (productDetail == null)
            return NotFound("Détails du produit non trouvés.");

        productDetail.Description = updatedDetailsDto.Description;
        productDetail.Manufacturer = updatedDetailsDto.Manufacturer;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("{id}/tags")]
    public async Task<IActionResult> AddTagToProduct(int id, TagDto tagDto)
    {
        var product = await _context.Products.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
        var tag = await _context.Tags.FindAsync(tagDto.Id);

        if (product == null || tag == null)
            return NotFound("Produit ou tag non trouvé.");

        product.Tags.Add(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}/tags/{tagId}")]
    public async Task<IActionResult> RemoveTagFromProduct(int id, int tagId)
    {
        var product = await _context.Products.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
        var tag = await _context.Tags.FindAsync(tagId);

        if (product == null || tag == null)
            return NotFound("Produit ou tag non trouvé.");

        product.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ********** PRIVATE METHODS **********
    // Logique de projection
    private IQueryable<ProductDto> GetProductDtoQuery()
    {
        return _context.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.ProductDetail)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Category = new CategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                },
                Tags = p.Tags.Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList(),
                ProductDetail = new ProductDetailDto
                {
                    Id = p.ProductDetail.Id,
                    Description = p.ProductDetail.Description,
                    Manufacturer = p.ProductDetail.Manufacturer
                }
            });
    }

    // Logique de création ou mise à jour
    private async Task<Product> CreateOrUpdateProductAsync(CreateOrUpdateProductDto productDto, Product? existingProduct = null)
    {
        var category = await _context.Categories.FindAsync(productDto.CategoryId);
        if (category == null)
            throw new KeyNotFoundException("Catégorie non trouvée.");

        var tags = await _context.Tags
            .Where(t => productDto.TagIds.Contains(t.Id))
            .ToListAsync();

        var product = existingProduct ?? new Product();

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Stock = productDto.Stock;
        product.CategoryId = productDto.CategoryId;
        product.Category = category;
        product.Tags = tags;

        if (product.ProductDetail == null)
        {
            product.ProductDetail = new ProductDetail();
        }

        product.ProductDetail.Description = productDto.ProductDetail.Description;
        product.ProductDetail.Manufacturer = productDto.ProductDetail.Manufacturer;

        return product;
    }
}
