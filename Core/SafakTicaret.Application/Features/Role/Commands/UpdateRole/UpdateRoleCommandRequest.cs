using MediatR;

namespace SafakTicaret.Application.Features.Role.Commands.UpdateRole
{
	public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
	{
		public string Id { get; set; }
		public string RoleName { get; set; }
	}
}
