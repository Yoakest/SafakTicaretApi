using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Abstractions.Token;
using SafakTicaret.Application.DTOs;
using SafakTicaret.Application.DTOs.User.GoogleLoginUser;
using SafakTicaret.Application.DTOs.User.LoginUser;
using SafakTicaret.Application.DTOs.User.RefreshToken;
using SafakTicaret.Domain.Entities.Identity;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace SafakTicaret.Persistence.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		readonly UserManager<AppUser> _userManager;
		readonly SignInManager<AppUser> _signInManager;
		readonly ITokenHandler _tokenHandler;
		readonly IConfiguration _configuration;
		readonly IUserService _userService;
		readonly ILogger<AuthenticationService> _logger;

		public AuthenticationService(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager,
			ITokenHandler tokenHandler,
			IConfiguration configuration,
			IUserService userService,
			ILogger<AuthenticationService> logger)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
			_configuration = configuration;
			_userService = userService;
			_logger = logger;
		}

		public async Task<LoginUserResponse> LoginAsync(LoginUser model)
		{
			AppUser user = await _userManager.FindByNameAsync(model.UserNameOrEmail);
			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
				if (user == null)
				{

					_logger.LogInformation(model.UserNameOrEmail + " ile başarısız giriş denemesi yapıldı");
					return new()
					{
						IsSuccess = false,
						Message = "Kullanıcı adı veya email bulunamadı..."
					};
				}
			}


			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

			if (result.Succeeded)
			{
				AccessToken accessToken = _tokenHandler.CreateAccessToken(9000, user);
				await _userService.UpdateRefreshTokenAsync(accessToken.RefreshToken, user, accessToken.Expiration, 9000);
				_logger.LogInformation(model.UserNameOrEmail + " ile giriş yapıldı");

				return new()
				{
					IsSuccess = true,
					Message = "Kullanıcı Girişi başarılı...",
					Token = accessToken
				};
			}
			_logger.LogInformation(model.UserNameOrEmail + " hatalı şifre ile başarısız giriş denemesi yapıldı");
			return new()
			{

				IsSuccess = false,
				Message = "Kullanıcı bilgileri hatalı girdiniz tekrar deneyiniz..."
			};

		}

		public async Task<GoogleLoginUserResponse> GoogleLoginAsync(string token)
		{
			ValidationSettings settings = new()
			{
				Audience = new List<string> { _configuration["Google:Client_ID"] },
			};
			Payload payload = await ValidateAsync(token, settings);

			UserLoginInfo info = new(_configuration["Google:Provider"], payload.Subject, _configuration["Google:Provider"]);

			AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

			bool result = user != null;

			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(payload.Email);
				if (user == null)
				{
					user = new()
					{
						Id = Guid.NewGuid().ToString(),
						Email = payload.Email,
						UserName = payload.Email,
						NameSurname = payload.Name,
					};
					IdentityResult identity = await _userManager.CreateAsync(user);
					result = identity.Succeeded;
				}
			}

			if (result)
			{
				await _userManager.AddLoginAsync(user, info);
			}
			else
			{
				return new()
				{
					IsSuccess = false,
					Message = "Kayıt başarısız"
				};
			}

			AccessToken accessToken = _tokenHandler.CreateAccessToken(9000, user);
			await _userService.UpdateRefreshTokenAsync(accessToken.RefreshToken, user, accessToken.Expiration, 9000);

			return new()
			{
				IsSuccess = true,
				Message = "Kullanıcı oluşturuldu",
				Token = accessToken
			};

		}

		public async Task<RefreshTokenResponse> RefreshTokenLoginAsnc(string refreshToken)
		{
			AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

			if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
			{
				AccessToken token = _tokenHandler.CreateAccessToken(30, user);
				await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 9000);
				return new()
				{
					IsSuccess = true,
					Message = "Token created",
					Token = token
				};
			}
			else
			{
				return new()
				{
					IsSuccess = false,
					Message = "Token cannot created"
				};
			}
		}

	}
}
