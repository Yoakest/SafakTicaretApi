using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.CreateUser;
using SafakTicaret.Application.DTOs.User.ListUsers;
using SafakTicaret.Application.Exceptions;
using SafakTicaret.Application.Helpers;
using SafakTicaret.Application.Repositories.EndpointRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Domain.Entities.Identity;
using System.Data;

namespace SafakTicaret.Persistence.Services
{
	public class UserService : IUserService
	{
		readonly UserManager<AppUser> _userManager;
		readonly IMailService _mailService;
		readonly IEndpointReadRepository _endpointReadRepository;



		public UserService(
			UserManager<AppUser> userManager,
			IMailService mailService,
			IEndpointReadRepository endpointReadRepository)
		{
			_userManager = userManager;
			_mailService = mailService;
			_endpointReadRepository = endpointReadRepository;
		}

		public async Task<CreateUserResponse> CreateUserAsync(CreateUser model)
		{
			Guid Id = Guid.NewGuid();
			var result = await _userManager.CreateAsync(new()
			{
				Id = Id.ToString(),
				UserName = model.UserName,
				Email = model.Email,
				NameSurname = model.NameSurname,
			}, model.Password);

			if (result.Succeeded)
			{
				string[] roles = new string[] { "Kullanıcı" };

				await AssignRoleToUsrAsync(Id.ToString(), roles);

				return new()
				{
					IsSuccess = true,
					Message = "Kullanıcı başarı ile oluşturulmuştur."
				};
			}
			else
			{
				string errMessage = "";

				foreach (var error in result.Errors)
				{
					errMessage += $"{error.Code} {error.Description}\n";
				}
				return new()
				{
					IsSuccess = false,
					Message = errMessage
				};
			}

		}

		public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenLifeTime)
		{


			if (user != null)
			{
				user.RefreshToken = refreshToken;
				user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenLifeTime);

				await _userManager.UpdateAsync(user);
			}
			else
			{
				throw new UserNotFoundException();
			}

		}


		public async Task PasswordRessetTokenAsync(string email)
		{
			AppUser user = await _userManager.FindByEmailAsync(email);
			await Console.Out.WriteLineAsync("asd");
			if (user != null)
			{
				string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
				resetToken = resetToken.UrlEncode();

				await _mailService.SendPasswordResetMailAsync(user.Email, user.Id, resetToken);
			}
		}

		public async Task<bool> ResetPasswordTokenIsValidAsync(string resetToken, string userId)
		{
			AppUser user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{

				resetToken = resetToken.UrlDecode();
				return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
			}
			return false;
		}

		public async Task UpdatePasswordAsync(string userId, string resetToken, string password)
		{
			AppUser user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				resetToken = resetToken.UrlDecode();
				IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, password);

				if (result.Succeeded)
				{
					await _userManager.UpdateSecurityStampAsync(user);
				}
				else
				{
					throw new PasswordChangeFaildException();
				}
			}
		}

		public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
		{
			List<AppUser> users = _userManager.Users
				.OrderBy(u => u.UserName)
				.Skip(page * size)
				.Take(size)
				.ToList();

			return users.Select(u => new ListUser
			{
				Id = u.Id,
				Email = u.Email,
				NameSurname = u.NameSurname,
				UserName = u.UserName,
				TwoFactorEneble = u.TwoFactorEnabled
			}).ToList();
		}


		public int TotalUsersCount => _userManager.Users.Count();

		public async Task AssignRoleToUsrAsync(string userId, string[] roles)
		{
			AppUser user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				IList<string> userRoles = await _userManager.GetRolesAsync(user);
				await _userManager.RemoveFromRolesAsync(user, userRoles);
				await _userManager.AddToRolesAsync(user, roles);
			}

		}

		public async Task<string[]> GetRolesToUser(string UserIdOrName)
		{
			AppUser user = await _userManager.FindByIdAsync(UserIdOrName);
			if (user == null)
			{
				user = await _userManager.FindByNameAsync(UserIdOrName);
			}
			if (user != null)
			{
				IList<string> roles = await _userManager.GetRolesAsync(user);
				return roles.ToArray();
			}
			return new string[] { };
		}

		public async Task<bool> HasRolePermissionToActionAsync(string name, string code)
		{
			string[] userRoles = await GetRolesToUser(name);

			if (!userRoles.Any())
			{
				return false;
			}

			Endpoint? endpoint = await _endpointReadRepository.Table
					.Include(e => e.Roles)
					.FirstOrDefaultAsync(e => e.Code == code);

			if (endpoint == null)
			{
				return false;
			}

			string[] endpointRoles = endpoint.Roles.Select(e => e.Name).ToArray();


			foreach (string endpointRole in endpointRoles)
			{
				foreach (string userRole in userRoles)
				{
					if (endpointRole == userRole)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
