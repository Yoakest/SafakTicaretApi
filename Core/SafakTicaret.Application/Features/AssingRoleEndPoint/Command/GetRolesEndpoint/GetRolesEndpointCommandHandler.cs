using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.AssingRoleEndPoint.Command.GetRolesEndpoint
{
	public class GetRolesEndpointCommandHandler : IRequestHandler<GetRolesEndpointCommandRequest, GetRolesEndpointCommandResponse>
	{
		private IAuthorizationEndpointService _endpointService;

		public GetRolesEndpointCommandHandler(IAuthorizationEndpointService endpointService)
		{
			_endpointService = endpointService;
		}

		public async Task<GetRolesEndpointCommandResponse> Handle(GetRolesEndpointCommandRequest request, CancellationToken cancellationToken)
		{
			return new GetRolesEndpointCommandResponse()
			{
				Roles = await _endpointService.GetRolesToEndpointAsync(request.Code, request.Menu)
			};
		}
	}
}
