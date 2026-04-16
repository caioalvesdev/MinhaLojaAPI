using MinhaLojaAPI.DTOs;

namespace MinhaLojaAPI.Services
{
	public interface IAuthService
	{
		public Task<LoginResponseDTO> Login(LoginRequestDTO input);
	}
}
