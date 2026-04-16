using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal interface IUserRepository
	{
		Task<User?> GetByEmailAsync(string email);
	}
}