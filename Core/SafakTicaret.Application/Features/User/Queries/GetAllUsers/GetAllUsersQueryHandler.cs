using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.User.ListUsers;

namespace SafakTicaret.Application.Features.User.Queries.GettAllUsers
{
	public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>

	{
		private IUserService _userService;

		public GetAllUsersQueryHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
		{
			List<ListUser> listUsers = await _userService.GetAllUsersAsync(request.Page, request.Size);

			return new GetAllUsersQueryResponse()
			{
				TotalUsersCount = _userService.TotalUsersCount,
				Users = listUsers
			};
		}
	}
}
