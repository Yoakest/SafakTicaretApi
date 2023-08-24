using MediatR;

namespace SafakTicaret.Application.Features.Role.Commands.CreateRole
{
	public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
	{
		public string Name { get; set; }
	}
}
