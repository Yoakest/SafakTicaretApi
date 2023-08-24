using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.DTOs.AuthorizeConfiguration;
using SafakTicaret.Application.Enums;
using System.Reflection;

namespace SafakTicaret.Infrastructure.AuthorizeConfiguration
{
	public class AuthorizeConfigurationService : IAuthorizeConfigurationService
	{

		public List<Menu> GetAuthorizeDefinationEndpoint(Type type)
		{
			Assembly? assembly = Assembly.GetAssembly(type);
			List<Menu> menus = new();

			if (assembly != null)
			{
				var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));


				foreach (var controller in controllers)
				{
					var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));
					if (actions != null)
						foreach (var action in actions)
						{
							var attributes = action.GetCustomAttributes(true);
							if (attributes != null)
							{
								Menu menu = new Menu();

								var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
								if (!menus.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
								{
									menu = new Menu() { Name = authorizeDefinitionAttribute.Menu, Actions = new List<Application.DTOs.AuthorizeConfiguration.Action>() };
									menus.Add(menu);
								}
								else
									menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);

								Application.DTOs.AuthorizeConfiguration.Action _action = new()
								{
									ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType), //authorizeDefinitionAttribute Enum olduğu için sonuçlar index nuamrasına göre geliyo 0, 1, 2, 3 gibi
									Definition = authorizeDefinitionAttribute.Definition
								};

								var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
								if (httpAttribute != null)
									_action.HttpType = httpAttribute.HttpMethods.First();
								else
									_action.HttpType = HttpMethods.Get;

								_action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";

								menu.Actions.Add(_action);

							}
						}
				}
			}
			return menus;
		}
	}
}
