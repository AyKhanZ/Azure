using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniTurboAzAPI.DbContexts;
using MiniTurboAzAPI.Models;

namespace MiniTurboAzAPI.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductsController : ControllerBase
    {

        private readonly MiniTurboAzContext _dbContext;

        public ProductsController(MiniTurboAzContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dbContext.Products.Include(p => p.Images).ToListAsync();

            if (products == null)
            {
                return NotFound("Product not found");
            }

            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _dbContext.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

    }
}
