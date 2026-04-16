using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Repositories;

namespace MinhaLojaAPI.Services
{
	internal sealed class AuthService(
		IUserRepository userRepository,
		IPasswordHasher passwordHasher,
		ITokenService tokenService,
		IConfiguration configuration) : IAuthService
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IPasswordHasher _passwordHasher = passwordHasher;
		private readonly ITokenService _tokenService = tokenService;
		private readonly IConfiguration _configuration = configuration;

		public async Task<LoginResponseDTO> Login(LoginRequestDTO input)
		{
			var user = await _userRepository.GetByEmailAsync(input.Email);

			if (user is null)
			{
				throw new UnauthorizedAccessException("Invalid email or password.");
			}

			if (!_passwordHasher.Verify(input.Password, user.PasswordHash))
			{
				throw new UnauthorizedAccessException("Invalid email or password.");
			}

			var token = _tokenService.GenerateToken(user);

			return new LoginResponseDTO
			{
				AccessToken = token,
				ExpiresAt = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpirationMinutes"]!)),
				User = new UserDTO
				{
					Id = user.Id,
					Username = user.Username,
					Email = user.Email
				}
			};
		}
	}
}
