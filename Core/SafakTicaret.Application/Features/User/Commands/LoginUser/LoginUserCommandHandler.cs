using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.LoginUser;

namespace SafakTicaret.Application.Features.User.Commands.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
	{
		readonly IAuthenticationService _authenticationService;

		public LoginUserCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{

			LoginUserResponse response = await _authenticationService.LoginAsync(new()
			{
				Password = request.Password,
				UserNameOrEmail = request.UserNameOrEmail,
			});

			if (response.IsSuccess)
			{
				return new LoginUserSuccessCommandResponse()
				{
					IsSuccess = response.IsSuccess,
					Message = response.Message,
					Token = response.Token
				};
			}
			return new LoginUserErrorCommandResponse()
			{
				IsSuccess = response.IsSuccess,
				Message = response.Message,
			};
		}
	}
}
