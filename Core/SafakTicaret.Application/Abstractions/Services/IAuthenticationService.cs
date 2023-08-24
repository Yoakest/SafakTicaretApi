using SafakTicaret.Application.DTOs.User.GoogleLoginUser;
using SafakTicaret.Application.DTOs.User.LoginUser;
using SafakTicaret.Application.DTOs.User.RefreshToken;

namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IAuthenticationService
	{
		Task<LoginUserResponse> LoginAsync(LoginUser model);
		Task<GoogleLoginUserResponse> GoogleLoginAsync(string token);
		Task<RefreshTokenResponse> RefreshTokenLoginAsnc(string token);

	}
}
