namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IRoleService
	{
		(object, int) GetAllRoles(int page, int size);
		Task<(string id, string name)> GetlRoleByIdAsync(string id);
		Task<bool> CreateRoleAsync(string roleName);
		Task<bool> DeleteRoleAsync(string roleName);
		Task<bool> UpdateRoleAsync(string id, string roleName);
	}
}
