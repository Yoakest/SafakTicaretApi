using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Role.Queries.GetByIdRole
{
	public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
	{
		private IRoleService _roleService;

		public GetByIdRoleQueryHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}
		public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
		{
			(string id, string name) data = await _roleService.GetlRoleByIdAsync(request.Id);
			return new()
			{
				Id = data.id,
				Name = data.name
			};
		}
	}
}
