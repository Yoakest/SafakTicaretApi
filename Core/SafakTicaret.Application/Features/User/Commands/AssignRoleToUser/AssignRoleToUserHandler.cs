using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.User.Commands.AssignRoleToUser
{
	public class AssignRoleToUserHandler : IRequestHandler<AssignRoleToUserRequest, AssignRoleToUserResponse>
	{
		readonly IUserService _userService;

		public AssignRoleToUserHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<AssignRoleToUserResponse> Handle(AssignRoleToUserRequest request, CancellationToken cancellationToken)
		{
			await _userService.AssignRoleToUsrAsync(request.UserId, request.Roles);
			return new AssignRoleToUserResponse() { };
		}
	}
}
