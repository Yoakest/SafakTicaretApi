using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Exceptions;

namespace SafakTicaret.Application.Features.User.Commands.UpdatePassword
{
	public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
	{
		private IUserService _userService;

		public UpdatePasswordCommandHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
		{
			if (request.Password.Equals(request.PasswordConfirm))
			{
				await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
			}
			else
			{
				throw new PasswordChangeFaildException("Şifreler eşleşmiyor. Aynı olmalıdır.");
			}
			return new();


		}
	}
}
