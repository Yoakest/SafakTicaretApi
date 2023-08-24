using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.User.Queries.GetRolesToUser
{
	public class GetRolesToUserHandler : IRequestHandler<GetRolesToUserRequest, GetRolesToUserResponse>
	{
		readonly IUserService _userService;

		public GetRolesToUserHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<GetRolesToUserResponse> Handle(GetRolesToUserRequest request, CancellationToken cancellationToken)
		{
			var roles = await _userService.GetRolesToUser(request.UserId);
			return new GetRolesToUserResponse()
			{
				Roles = roles
			};
		}
	}
}
