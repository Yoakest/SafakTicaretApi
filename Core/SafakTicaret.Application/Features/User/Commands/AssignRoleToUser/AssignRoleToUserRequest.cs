using MediatR;

namespace SafakTicaret.Application.Features.User.Commands.AssignRoleToUser
{
	public class AssignRoleToUserRequest : IRequest<AssignRoleToUserResponse>
	{
		public string UserId { get; set; }
		public string[] Roles { get; set; }
	}
}
