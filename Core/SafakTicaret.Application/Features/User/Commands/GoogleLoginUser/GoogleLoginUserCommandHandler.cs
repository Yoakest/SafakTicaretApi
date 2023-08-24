using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.GoogleLoginUser;

namespace SafakTicaret.Application.Features.User.Commands.GoogleLoginUser
{
	public class GoogleLoginUserCommandHandler : IRequestHandler<GoogleLoginUserCommandRequest, GoogleLoginUserCommandResponse>
	{

		readonly IAuthenticationService _authenticationService;

		public GoogleLoginUserCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<GoogleLoginUserCommandResponse> Handle(GoogleLoginUserCommandRequest request, CancellationToken cancellationToken)
		{
			GoogleLoginUserResponse response = await _authenticationService.GoogleLoginAsync(request.IdToken);
			if (response.IsSuccess)
			{
				return new GoogleLoginUserSuccessCommandResponse()
				{
					IsSuccess = response.IsSuccess,
					Message = response.Message,
					Token = response.Token
				};
			}
			else
			{
				return new GoogleLoginUserErrorCommandResponse()
				{
					IsSuccess = response.IsSuccess,
					Message = response.Message,
				};
			}
		}
	}
}
