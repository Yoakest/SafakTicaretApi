namespace SafakTicaret.Application.DTOs.User.LoginUser
{
	public class LoginUserResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public AccessToken? Token { get; set; }
	}
}
