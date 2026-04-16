using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Services
{
	internal interface ITokenService
	{
		string GenerateToken(User user);
	}
}
