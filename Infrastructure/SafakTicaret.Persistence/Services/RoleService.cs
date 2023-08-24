using Microsoft.AspNetCore.Identity;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Domain.Entities.Identity;

namespace SafakTicaret.Persistence.Services
{
	public class RoleService : IRoleService
	{
		readonly RoleManager<AppRole> _roleManager;

		public RoleService(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<bool> CreateRoleAsync(string roleName)
		{
			IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = roleName });
			return result.Succeeded;
		}

		public async Task<bool> DeleteRoleAsync(string Id)
		{
			AppRole appRole = await _roleManager.FindByIdAsync(Id);
			IdentityResult result = await _roleManager.DeleteAsync(appRole);
			return result.Succeeded;
		}

		public (object, int) GetAllRoles(int page, int size)
		{
			var query = _roleManager.Roles;

			IQueryable<AppRole> rolesQuery = null;

			if (page != -1 && size != -1)
			{
				rolesQuery = query
								.OrderBy(r => r.Name)
								.Skip(page * size)
								.Take(size);
			}
			else
			{
				rolesQuery = query.OrderBy(r => r.Name);
			}

			return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
		}

		public async Task<(string id, string name)> GetlRoleByIdAsync(string id)
		{
			string name = await _roleManager.GetRoleIdAsync(new() { Id = id });
			return (id, name);
		}

		public async Task<bool> UpdateRoleAsync(string id, string roleName)
		{
			IdentityResult result = await _roleManager.UpdateAsync(new() { Id = id, Name = roleName });
			return result.Succeeded;
		}
	}
}
