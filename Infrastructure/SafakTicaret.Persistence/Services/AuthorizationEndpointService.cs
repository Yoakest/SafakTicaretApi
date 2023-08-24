using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Repositories.EndpointRepository;
using SafakTicaret.Application.Repositories.MenuReadRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Domain.Entities.Identity;
using A = SafakTicaret.Application.DTOs.AuthorizeConfiguration;

namespace SafakTicaret.Persistence.Services
{
	public class AuthorizationEndpointService : IAuthorizationEndpointService
	{
		readonly IAuthorizeConfigurationService _authorizeConfigurationService;
		readonly IEndpointReadRepository _endpointReadRepository;
		readonly IEndpointWriteRepository _endpointWriteRepository;
		readonly IMenuReadRepository _menuReadRepository;
		readonly IMenuWriteRepository _menuWriteRepository;
		readonly RoleManager<AppRole> _roleManager;
		public AuthorizationEndpointService(
			IAuthorizeConfigurationService authorizeConfigurationService,
			IEndpointReadRepository endpointReadRepository,
			IEndpointWriteRepository endpointWriteRepository,
			IMenuReadRepository menuReadRepository,
			IMenuWriteRepository menuWriteRepository,
			RoleManager<AppRole> roleManager)
		{
			_authorizeConfigurationService = authorizeConfigurationService;
			_endpointReadRepository = endpointReadRepository;
			_endpointWriteRepository = endpointWriteRepository;
			_menuReadRepository = menuReadRepository;
			_menuWriteRepository = menuWriteRepository;
			_roleManager = roleManager;
		}

		public async Task AssingRoleEndpointAsync(string[] roles, string menu, string code, Type type)
		{
			Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
			if (_menu == null)
			{
				_menu = new()
				{
					Id = Guid.NewGuid(),
					Name = menu,

				};
				await _menuWriteRepository.AddAsync(_menu);
				await _menuWriteRepository.SaveAsync();
			}

			Endpoint? endpoint = await _endpointReadRepository.Table
				.Include(e => e.Menu)
				.Include(e => e.Roles)
				.FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
			if (endpoint == null)
			{
				A.Action? action = _authorizeConfigurationService.GetAuthorizeDefinationEndpoint(type)
					   .FirstOrDefault(m => m.Name == menu)
					   ?.Actions.FirstOrDefault(e => e.Code == code);

				endpoint = new()
				{
					Id = Guid.NewGuid(),
					Code = action.Code,
					ActionType = action.ActionType,
					HttpType = action.HttpType,
					Definition = action.Definition,
					Menu = _menu
				};

				await _endpointWriteRepository.AddAsync(endpoint);
				await _endpointWriteRepository.SaveAsync();
			}

			foreach (var role in endpoint.Roles)
			{
				endpoint.Roles.Remove(role);
			}

			var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Id)).ToListAsync();

			foreach (var role in appRoles)
			{
				endpoint.Roles.Add(role);
			}

			await _endpointWriteRepository.SaveAsync();

		}

		public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
		{
			Endpoint? endpoint = await _endpointReadRepository.Table
				.Include(e => e.Roles)
				.Include(e => e.Menu)
				.FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
			if (endpoint != null)
				return endpoint.Roles.Select(r => r.Name).ToList();
			return new List<string> { };
		}
	}
}
