using MediatR;

namespace SafakTicaret.Application.Features.AssingRoleEndPoint.Command.GetRolesEndpoint
{
	public class GetRolesEndpointCommandRequest : IRequest<GetRolesEndpointCommandResponse>
	{
		public string Code { get; set; }
		public string Menu { get; set; }
	}
}
