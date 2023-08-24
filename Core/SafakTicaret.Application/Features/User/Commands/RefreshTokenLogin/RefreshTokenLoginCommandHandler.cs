using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.RefreshToken;

namespace SafakTicaret.Application.Features.User.Commands.RefreshTokenLogin
{
	public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
	{
		readonly IAuthenticationService _authenticationService;

		public RefreshTokenLoginCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
		{
			RefreshTokenResponse response = await _authenticationService.RefreshTokenLoginAsnc(request.RefreshToken);
			if (response.IsSuccess)
			{
				return new()
				{
					IsSuccess = response.IsSuccess,
					Message = response.Message,
					Token = response.Token
				};
			}
			else
			{
				return new()
				{
					IsSuccess = response.IsSuccess,
					Message = response.Message,
				};
			}
		}
	}
}
