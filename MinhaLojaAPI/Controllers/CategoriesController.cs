using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CategoriesController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<Category>> Create(Category categoria)
		{
			_context.Categories.Add(categoria);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAll), new { id = categoria.Id }, categoria);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Category>>> GetAll()
		{
			return await _context.Categories.ToListAsync();
		}
	}
}
