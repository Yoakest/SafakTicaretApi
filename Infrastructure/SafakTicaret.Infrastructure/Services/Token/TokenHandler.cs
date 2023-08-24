using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SafakTicaret.Application.Abstractions.Token;
using SafakTicaret.Application.DTOs;
using SafakTicaret.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SafakTicaret.Infrastructure.Services.Token
{
	public class TokenHandler : ITokenHandler
	{
		readonly IConfiguration configuration;

		public TokenHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public AccessToken CreateAccessToken(int seconds, AppUser user)
		{
			//Token geçerlilik süresi dakika olarak
			DateTime expires = DateTime.UtcNow.AddSeconds(seconds);

			//Security key simetriği oluştur
			SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

			//Şifreleme kimliği oluştur
			SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

			//Token için ayarlar
			JwtSecurityToken securityToken = new(
				audience: configuration["Token:Web"],
				issuer: configuration["Token:Api"],
				expires: expires,
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials,
				claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
				);

			//Token oluşturucu sınıf örneği
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();


			//TOKEN oluştu
			return new()
			{
				Token = tokenHandler.WriteToken(securityToken),
				Expiration = expires,
				RefreshToken = CreateRefreshToken()
			};

		}

		public string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using RandomNumberGenerator random = RandomNumberGenerator.Create();
			random.GetBytes(number);
			return Convert.ToBase64String(number);
		}
	}
}
