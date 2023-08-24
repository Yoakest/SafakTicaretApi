using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.AssingRoleEndPoint.Command.AssingRoleEndPoint
{
	public class AssingRoleEndPointCommandHandler : IRequestHandler<AssingRoleEndPointCommandRequest, AssingRoleEndPointConmmandResponse>
	{
		private IAuthorizationEndpointService _endpointService;

		public AssingRoleEndPointCommandHandler(IAuthorizationEndpointService endpointService)
		{
			_endpointService = endpointService;
		}

		public async Task<AssingRoleEndPointConmmandResponse> Handle(AssingRoleEndPointCommandRequest request, CancellationToken cancellationToken)
		{
			if (request.Type != null)
			{
				await _endpointService.AssingRoleEndpointAsync(request.Roles, request.Menu, request.EndpointCode, request.Type);
			}
			return new();
		}
	}
}
