using AykhanTurboWebApplication.DbContexts;
using AykhanTurboWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AykhanTurboWebApplication.Controllers;
[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
	private readonly SqldatabaseContext _dbContext;

	public ProductController(SqldatabaseContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet("Products")]
	public async Task<IActionResult> GetProducts()
	{
		var ps = await _dbContext.Products.ToListAsync();

		return Ok(ps);
	}

	[HttpGet("Product/{id}")]
	public async Task<IActionResult> GetProductById(int id)
	{
		var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

		return Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Product product)
	{
		if (product == null)
		{
			return BadRequest("Product object is null");
		}

		Product p = new Product()
		{
			Id = 4,
			Name = "Hyundai ",
			Description = "Hyundai Elantra, 2.0 L, 2016 il, 124 000 km",
			Model = "Hundai",
			Price = 27000,
			Speed = 124,
			Color = "Black",
			Image = "56679_HZHxbfzWRZBhEvycxA-rRg.jpg"
		};
		// Добавляем новый продукт в базу данных
		_dbContext.Products.Add(p);
		await _dbContext.SaveChangesAsync();

		// Возвращаем HTTP статус 201 Created и созданный объект продукта
		return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
	}

}