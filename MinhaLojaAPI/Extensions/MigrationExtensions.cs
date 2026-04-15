using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;

namespace MinhaLojaAPI.Extensions
{
	public static class MigrationExtensions
	{
		public static void ApplyMigrations(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			dbContext.Database.Migrate();
		}
	}
}
