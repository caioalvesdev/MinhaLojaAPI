using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MinhaLojaAPI.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	public abstract class MainController : ControllerBase
	{
	}
}
