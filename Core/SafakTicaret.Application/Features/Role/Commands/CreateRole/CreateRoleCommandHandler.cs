using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Role.Commands.CreateRole
{
	public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
	{
		private IRoleService _roleService;

		public CreateRoleCommandHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
		{
			bool result = await _roleService.CreateRoleAsync(request.Name);
			return new()
			{
				IsSuccess = result
			};
		}
	}
}
