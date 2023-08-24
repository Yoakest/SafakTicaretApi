using SafakTicaret.Application.DTOs;

namespace SafakTicaret.Application.Features.User.Commands.LoginUser
{
	public class LoginUserCommandResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }

	}

	public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
	{
		public AccessToken Token { get; set; }
	}

	public class LoginUserErrorCommandResponse : LoginUserCommandResponse
	{

	}
}
