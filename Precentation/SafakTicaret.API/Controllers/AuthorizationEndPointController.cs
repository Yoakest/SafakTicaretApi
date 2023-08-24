using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Features.AssingRoleEndPoint.Command.AssingRoleEndPoint;
using SafakTicaret.Application.Features.AssingRoleEndPoint.Command.GetRolesEndpoint;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class AuthorizationEndPointController : Controller
	{
		private IMediator _mediator;
		public AuthorizationEndPointController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("GetRolesEndpoint")]
		public async Task<IActionResult> GetRolesEndpoint([FromBody] GetRolesEndpointCommandRequest getRolesEndpointCommandRequest)
		{
			return Ok(await _mediator.Send(getRolesEndpointCommandRequest));
		}

		[HttpPost]
		public async Task<IActionResult> AssingRoleEndPoint([FromBody] AssingRoleEndPointCommandRequest assingRoleEndPointControllerRequest)
		{
			assingRoleEndPointControllerRequest.Type = typeof(Program);
			await Console.Out.WriteLineAsync(assingRoleEndPointControllerRequest.ToString());
			return Ok(await _mediator.Send(assingRoleEndPointControllerRequest));
		}


	}
}
