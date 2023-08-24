using SafakTicaret.Application.DTOs;
using SafakTicaret.Domain.Entities.Identity;

namespace SafakTicaret.Application.Abstractions.Token
{
	public interface ITokenHandler
	{
		AccessToken CreateAccessToken(int seconds, AppUser user);
		string CreateRefreshToken();

	}
}
