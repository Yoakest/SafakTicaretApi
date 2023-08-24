using SafakTicaret.Application.DTOs.AuthorizeConfiguration;

namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IAuthorizeConfigurationService
	{
		List<Menu> GetAuthorizeDefinationEndpoint(Type type);
	}
}
