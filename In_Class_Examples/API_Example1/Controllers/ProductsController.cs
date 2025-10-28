using Microsoft.AspNetCore.Mvc;

namespace API_Example1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // ---------- Hard-coded in-memory store ----------
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop",   Price = 999.99m, Category = "Electronics" },
            new Product { Id = 2, Name = "Mouse",    Price =  25.50m, Category = "Electronics" },
            new Product { Id = 3, Name = "Desk",     Price = 150.00m, Category = "Furniture"   },
            new Product { Id = 4, Name = "Chair",    Price =  89.99m, Category = "Furniture"   },
            new Product { Id = 5, Name = "Monitor",  Price = 199.99m, Category = "Electronics" }
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // ==================== GET ALL ====================
        [HttpGet(Name = "GetAllProducts")]
        public ActionResult<List<Product>> GetAll()
        {
            _logger.LogInformation("GET all – {Count} products", _products.Count);
            return Ok(_products);
        }

        // ==================== GET BY ID ====================
        [HttpGet("{id:int}", Name = "GetProductById")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                _logger.LogWarning("GET id={Id} – not found", id);
                return NotFound($"Product with Id {id} not found.");
            }

            _logger.LogInformation("GET id={Id} – {Name}", id, product.Name);
            return Ok(product);
        }


        [HttpGet("category/{category}", Name = "GetProductsByCategory")]
        public ActionResult<IEnumerable<Product>> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                _logger.LogWarning("GET category – empty value supplied");
                return BadRequest("Category parameter is required.");
            }

            var matches = _products
                .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!matches.Any())
            {
                _logger.LogInformation("GET category={Category} – no products found", category);
                return NotFound($"No products found in category '{category}'.");
            }

            _logger.LogInformation(
                "GET category={Category} – {Count} product(s) returned",
                category,
                matches.Count);

            return Ok(matches);
        }

        //[HttpGet("{category:string}", Name = "GetProductByCategory")]
        //public ActionResult<List<Product>> GetByCategory(string category)
        //{
        //    var products = _products.FirstOrDefault(p => p.Category == category);
        //    if (products == null)
        //    {
        //        return NotFound($"Product with Category {category} not found.");
        //    }

        //    return Ok(products);
        //}

        // ==================== CREATE ====================
        [HttpPost(Name = "CreateProduct")]
        public ActionResult<Product> Create([FromBody] Product newProduct)
        {
            // Basic validation
            if (newProduct == null || string.IsNullOrWhiteSpace(newProduct.Name))
                return BadRequest("Product name is required.");

            // Auto-increment Id
            newProduct.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(newProduct);

            _logger.LogInformation("POST – created Id={Id} '{Name}'", newProduct.Id, newProduct.Name);

            // 201 Created + Location header
            return CreatedAtAction(
                nameof(GetById),
                new { id = newProduct.Id },
                newProduct);
        }

        // ==================== UPDATE ====================
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || string.IsNullOrWhiteSpace(updatedProduct.Name))
                return BadRequest("Invalid product data.");

            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                _logger.LogWarning("PUT id={Id} – not found", id);
                return NotFound($"Product with Id {id} not found.");
            }

            // Update fields
            existing.Name = updatedProduct.Name;
            existing.Price = updatedProduct.Price;
            existing.Category = updatedProduct.Category;

            _logger.LogInformation("PUT id={Id} – updated to '{Name}'", id, existing.Name);
            return NoContent(); // 204 – success, no body
        }

        // ==================== DELETE ====================
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                _logger.LogWarning("DELETE id={Id} – not found", id);
                return NotFound($"Product with Id {id} not found.");
            }

            _products.Remove(product);
            _logger.LogInformation("DELETE id={Id} – removed '{Name}'", id, product.Name);
            return NoContent(); // 204
        }
    }

    // ---------- POCO model ----------
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}

