namespace SafakTicaret.Application.DTOs.User.GoogleLoginUser
{
	public class GoogleLoginUserResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public AccessToken? Token { get; set; }
	}
}
