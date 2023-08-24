using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.Features.User.Commands.AssignRoleToUser;
using SafakTicaret.Application.Features.User.Commands.CreateUser;
using SafakTicaret.Application.Features.User.Commands.GoogleLoginUser;
using SafakTicaret.Application.Features.User.Commands.LoginUser;
using SafakTicaret.Application.Features.User.Commands.RefreshTokenLogin;
using SafakTicaret.Application.Features.User.Commands.ResetPassword;
using SafakTicaret.Application.Features.User.Commands.ResetPasswordIsValid;
using SafakTicaret.Application.Features.User.Commands.UpdatePassword;
using SafakTicaret.Application.Features.User.Queries.GetRolesToUser;
using SafakTicaret.Application.Features.User.Queries.GettAllUsers;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMailService _mailService;

		public UserController(IMediator mediator, IMailService mailService)
		{
			_mediator = mediator;
			_mailService = mailService;
		}

		[HttpPost]
		//Kullanıcı oluşturma
		public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
		{
			return Ok(await _mediator.Send(createUserCommandRequest));
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
		{
			return Ok(await _mediator.Send(loginUserCommandRequest));
		}

		[HttpPost("google-login")]
		public async Task<IActionResult> GoogleLogin(GoogleLoginUserCommandRequest googleLoginUserCommandRequest)
		{
			return Ok(await _mediator.Send(googleLoginUserCommandRequest));
		}

		[HttpPost("RefreshToken")]
		public async Task<IActionResult> RefreshToken(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
		{
			return Ok(await _mediator.Send(refreshTokenLoginCommandRequest));
		}

		[HttpPost("passwordreset")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommandRequest resetPasswordCommandRequest)
		{
			return Ok(await _mediator.Send(resetPasswordCommandRequest));
		}

		[HttpPost("verifyresettoken")]
		public async Task<IActionResult> PasswordTokenIsValid([FromBody] ResetPasswordIsValidCommandRequest resetPasswordIsValidCommandRequest)
		{
			return Ok(await _mediator.Send(resetPasswordIsValidCommandRequest));
		}

		[HttpPost("updatepassword")]
		public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
		{
			return Ok(await _mediator.Send(updatePasswordCommandRequest));
		}

		[HttpGet("Mail")]
		public async Task<IActionResult> Mail()
		{
			_mailService.Main();
			return Ok("mail");
		}

		[HttpGet]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
		public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
		{

			return Ok(await _mediator.Send(getAllUsersQueryRequest));
		}

		[HttpGet("getrolestouser/{UserId}")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(ActionType = Application.Enums.ActionType.Reading, Definition = "Get Roles To User", Menu = "Users")]
		public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserRequest getRolesToUserRequest)
		{
			return Ok(await _mediator.Send(getRolesToUserRequest));
		}

		[HttpPost("assingroletouser")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(ActionType = Application.Enums.ActionType.Writing, Definition = "Assing Role To User", Menu = "Users")]
		public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleToUserRequest assignRoleToUserRequest)
		{
			var a = assignRoleToUserRequest;
			await Console.Out.WriteLineAsync(assignRoleToUserRequest.ToString());


			return Ok(await _mediator.Send(assignRoleToUserRequest));
		}
	}
}