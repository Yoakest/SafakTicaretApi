using MediatR;

namespace SafakTicaret.Application.Features.Role.Commands.DeleteRole
{
	public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
	{
		public string Id { get; set; }
	}
}
