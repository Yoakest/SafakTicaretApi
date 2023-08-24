using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.ResetPasswordIsValid
{
	public class ResetPasswordIsValidCommandRequest : IRequest<ResetPasswordIsValidCommandResponse>
	{
		public string UserId { get; set; }
		public string ResetToken { get; set; }
	}
}
