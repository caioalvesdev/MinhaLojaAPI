using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Data
{
	internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}