namespace SafakTicaret.Application.DTOs.User.RefreshToken
{
	public class RefreshTokenResponse
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public AccessToken? Token { get; set; }
	}
}
