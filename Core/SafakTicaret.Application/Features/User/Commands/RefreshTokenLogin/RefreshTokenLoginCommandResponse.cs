using SafakTicaret.Application.DTOs;

namespace SafakTicaret.Application.Features.User.Commands.RefreshTokenLogin
{
	public class RefreshTokenLoginCommandResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public AccessToken Token { get; set; }
	}
}
