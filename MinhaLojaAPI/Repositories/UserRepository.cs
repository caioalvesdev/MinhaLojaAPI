using Microsoft.EntityFrameworkCore;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal sealed class UserRepository(AppDbContext context) : IUserRepository
	{
		private readonly AppDbContext _context = context;

		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}
	}
}
