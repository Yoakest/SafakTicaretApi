using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.Enums;
using SafakTicaret.Application.Features.Role.Commands.CreateRole;
using SafakTicaret.Application.Features.Role.Commands.DeleteRole;
using SafakTicaret.Application.Features.Role.Commands.UpdateRole;
using SafakTicaret.Application.Features.Role.Queries.GetAllRoles;
using SafakTicaret.Application.Features.Role.Queries.GetByIdRole;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class RoleController : Controller
	{
		private readonly IMediator _mediator;
		public RoleController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
		public async Task<IActionResult> GetRoles([FromQuery] GetAllRolesQueryRequest getRolesQueryRequest)
		{
			return Ok(await _mediator.Send(getRolesQueryRequest));
		}

		[HttpGet("{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
		public async Task<IActionResult> GetRoleById([FromRoute] GetByIdRoleQueryRequest getByIdRoleQueryRequest)
		{
			return Ok(await _mediator.Send(getByIdRoleQueryRequest));
		}

		[HttpPost]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
		public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
		{
			return Ok(await _mediator.Send(createRoleCommandRequest));
		}

		[HttpPut("{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
		public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
		{
			return Ok(await _mediator.Send(updateRoleCommandRequest));
		}

		[HttpDelete("{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
		public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
		{
			return Ok(await _mediator.Send(deleteRoleCommandRequest));
		}
	}
}
