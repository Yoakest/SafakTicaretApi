using MediatR;

namespace SafakTicaret.Application.Features.AssingRoleEndPoint.Command.AssingRoleEndPoint
{
	public class AssingRoleEndPointCommandRequest : IRequest<AssingRoleEndPointConmmandResponse>
	{
		public string[] Roles { get; set; }
		public string EndpointCode { get; set; }
		public string Menu { get; set; }
		public Type? Type { get; set; }
	}
}
