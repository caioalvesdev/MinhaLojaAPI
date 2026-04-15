using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProductsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAll(Guid? categoryId)
		{
			var query = _context.Products
			.Include(p => p.Category)
			.Include(p => p.Images)
			.AsQueryable();

			if (categoryId.HasValue)
			{
				query = query.Where(p => p.CategoryId == categoryId);
			}

			return await query.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Product>> Create(Product produto)
		{
			_context.Products.Add(produto);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAll), new { id = produto.Id }, produto);
		}
	}
}
