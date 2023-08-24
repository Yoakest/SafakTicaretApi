using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.LoginUser
{
	public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
	{
		public string UserNameOrEmail { get; set; }
		public string Password { get; set; }
	}
}
