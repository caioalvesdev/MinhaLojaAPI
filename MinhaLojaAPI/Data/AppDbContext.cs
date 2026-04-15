using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Image> Images { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

	}
}
