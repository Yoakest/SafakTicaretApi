using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Role.Commands.DeleteRole
{
	public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
	{
		private IRoleService _roleService;

		public DeleteRoleCommandHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
		{
			bool result = await _roleService.DeleteRoleAsync(request.Id);
			return new()
			{
				IsSuccess = result
			};
		}
	}
}
