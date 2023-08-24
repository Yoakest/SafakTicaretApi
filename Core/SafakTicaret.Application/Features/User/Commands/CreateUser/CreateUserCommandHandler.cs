using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.CreateUser;


namespace SafakTicaret.Application.Features.User.Commands.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		readonly IUserService _userService;


		public CreateUserCommandHandler(
			IUserService userService)
		{
			_userService = userService;

		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{
			CreateUserResponse response = await _userService.CreateUserAsync(new()
			{
				UserName = request.UserName,
				NameSurname = request.NameSurname,
				Email = request.Email,
				Password = request.Password,
				RePassword = request.RePassword,
			});

			return new()
			{
				IsSuccess = response.IsSuccess,
				Message = response.Message,
			};
		}

	}
}
