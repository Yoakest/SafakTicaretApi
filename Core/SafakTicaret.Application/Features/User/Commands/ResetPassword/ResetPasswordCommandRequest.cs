using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.ResetPassword
{
	public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
	{
		public string Email { get; set; }
	}
}
