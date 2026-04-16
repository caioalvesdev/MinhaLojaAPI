using Microsoft.IdentityModel.Tokens;
using MinhaLojaAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinhaLojaAPI.Services
{
	internal sealed class TokenService(IConfiguration configuration) : ITokenService
	{
		private readonly IConfiguration _configuration = configuration;

		public string GenerateToken(User user)
		{
			string secret = _configuration["Jwt:Secret"]!;

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
			   new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
			   new(JwtRegisteredClaimNames.Email, user.Email),
			   new(JwtRegisteredClaimNames.Name, user.Username),
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpirationMinutes"]!)),
				SigningCredentials = credentials,
				Issuer = _configuration["Jwt:Issuer"],
				Audience = _configuration["Jwt:Audience"]
			};

			var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();

			return handler.CreateToken(tokenDescriptor);
		}
	}
}
