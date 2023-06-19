using Microsoft.AspNetCore.Mvc;
using StoreApi.Data;

namespace StoreApi.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase {
    private readonly MyContext _context;

    public ProductsController(MyContext context) {
        _context = context;
    }

    // GET: products
    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
        => await _context.Products.ToListAsync();

    // GET: products/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id) {
        var product = await _context.Products.FindAsync(id);

        if(product == null) {
            return NotFound();
        }

        return product;
    }

    // PUT: Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody]Product product) {
        if(id != product.Id) {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException) {
            if(!ProductExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product) {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // DELETE: Products/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        var product = await _context.Products.FindAsync(id);
        if(product == null) {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
        => _context.Products.Any(e => e.Id == id);
}
