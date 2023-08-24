using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.CustomAttributes;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class AuthorizeServiceController : Controller
	{
		IAuthorizeConfigurationService _authService;

		public AuthorizeServiceController(IAuthorizeConfigurationService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		[AuthorizeDefinition(ActionType = Application.Enums.ActionType.Reading, Definition = "Get Authorize Definition Endpoints", Menu = "Aplication Service")]
		public IActionResult GetAuthorizeDefinitionEndPoints()
		{
			var data = _authService.GetAuthorizeDefinationEndpoint(typeof(Program));
			return Ok(data);
		}
	}
}
