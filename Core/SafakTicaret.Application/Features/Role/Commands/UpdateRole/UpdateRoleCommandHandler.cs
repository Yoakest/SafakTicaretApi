using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Role.Commands.UpdateRole
{
	public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
	{
		private IRoleService _roleService;

		public UpdateRoleCommandHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
		{
			bool result = await _roleService.UpdateRoleAsync(request.Id, request.RoleName);
			return new()
			{
				IsSuccess = result,
			};
		}
	}
}
