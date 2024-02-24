using AykhanWebApplication.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AykhanWebApplication.Controllers;
[ApiController]
[Route("Product")]
public class CategoryController : ControllerBase
{
	private readonly SqldatabaseContext _dbContext;

	public CategoryController(SqldatabaseContext dbContext)
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


	//// POST api/<CategoryController>
	//[HttpPost]
	//public void Post([FromBody] string value)
	//{ }
	//// PUT api/<CategoryController>/5
	//[HttpPut("{id}")]
	//public void Put(int id, [FromBody] string value)
	//{ }
	//// DELETE api/<CategoryController>/5
	//[HttpDelete("{id}")]
	//public void Delete(int id)
	//{ }
}