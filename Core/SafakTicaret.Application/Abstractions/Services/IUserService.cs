using SafakTicaret.Application.DTOs.User.CreateUser;
using SafakTicaret.Application.DTOs.User.ListUsers;
using SafakTicaret.Domain.Entities.Identity;

namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IUserService
	{
		Task<CreateUserResponse> CreateUserAsync(CreateUser model);
		Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenLifeTime);
		Task PasswordRessetTokenAsync(string email);
		Task<bool> ResetPasswordTokenIsValidAsync(string resetToken, string userId);
		Task UpdatePasswordAsync(string userId, string resetToken, string password);
		Task<List<ListUser>> GetAllUsersAsync(int page, int size);
		int TotalUsersCount { get; }
		Task AssignRoleToUsrAsync(string userId, string[] roles);
		Task<string[]> GetRolesToUser(string UserId);
		Task<bool> HasRolePermissionToActionAsync(string name, string code);
	}
}
