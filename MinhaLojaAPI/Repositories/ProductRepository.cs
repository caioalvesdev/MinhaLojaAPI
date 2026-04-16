using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal sealed class ProductRepository(AppDbContext context) : IProductRepository
	{
		private readonly AppDbContext _context = context;

		public async Task CreateAsync(Product input)
		{
			await _context.Products.AddAsync(input);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAllAsync(Guid? categoryId)
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
	}
}
