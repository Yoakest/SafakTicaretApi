namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IAuthorizationEndpointService
	{
		public Task AssingRoleEndpointAsync(string[] roles, string menu, string code, Type type);
		public Task<List<string>> GetRolesToEndpointAsync(string code, string menu);
	}
}
