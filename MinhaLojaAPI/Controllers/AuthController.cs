using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Services;

namespace MinhaLojaAPI.Controllers
{
	public class AuthController(IAuthService authService) : MainController
	{
		private readonly IAuthService _authService = authService;

		[AllowAnonymous]
		[HttpPost("login")]
		[ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO request)
		{
			var response = await _authService.Login(request);
			return Ok(response);
		}
	}
}
