using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.User.Commands.ResetPasswordIsValid
{
	public class ResetPasswordIsValidCommandHandler : IRequestHandler<ResetPasswordIsValidCommandRequest, ResetPasswordIsValidCommandResponse>
	{
		private IUserService _useUserService;

		public ResetPasswordIsValidCommandHandler(IUserService useUserService)
		{
			_useUserService = useUserService;
		}

		async Task<ResetPasswordIsValidCommandResponse> IRequestHandler<ResetPasswordIsValidCommandRequest, ResetPasswordIsValidCommandResponse>.Handle(ResetPasswordIsValidCommandRequest request, CancellationToken cancellationToken)
		{
			bool state = await _useUserService.ResetPasswordTokenIsValidAsync(request.ResetToken, request.UserId);
			return new()
			{
				State = state,
			};
		}
	}
}
