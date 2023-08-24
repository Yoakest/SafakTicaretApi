using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.User.Commands.ResetPassword
{

	public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
	{
		IUserService _userService;

		public ResetPasswordCommandHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
		{
			await _userService.PasswordRessetTokenAsync(request.Email);
			return new();
		}
	}
}
