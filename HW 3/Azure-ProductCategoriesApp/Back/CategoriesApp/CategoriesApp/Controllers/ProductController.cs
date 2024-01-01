using CategoriesApp.DbContexts;
using CategoriesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoriesApp.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly ComboBoxContext _dbContext;

        public ProductController(ComboBoxContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _dbContext.ProductCategories.ToListAsync();
            
            return Ok(categories);
        }


        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            var products = await _dbContext.Products.Where(p => p.ProductCategoryId == id).ToListAsync();

            return Ok(products);
        }


    }
}
