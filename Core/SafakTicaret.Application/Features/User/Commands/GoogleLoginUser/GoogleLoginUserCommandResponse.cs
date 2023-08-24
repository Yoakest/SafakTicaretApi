using SafakTicaret.Application.DTOs;

namespace SafakTicaret.Application.Features.User.Commands.GoogleLoginUser
{
	public class GoogleLoginUserCommandResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}

	public class GoogleLoginUserSuccessCommandResponse : GoogleLoginUserCommandResponse
	{
		public AccessToken Token { get; set; }
	}

	public class GoogleLoginUserErrorCommandResponse : GoogleLoginUserCommandResponse
	{

	}
}
