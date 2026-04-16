using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal sealed class CategoryRepository(AppDbContext context) : ICategoryRespository
	{
		private readonly AppDbContext _context = context;

		public async Task CreateAsync(Category input)
		{
			await _context.Categories.AddAsync(input);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}
	}
}