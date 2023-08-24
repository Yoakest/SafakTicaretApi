using MediatR;

namespace SafakTicaret.Application.Features.User.Queries.GetRolesToUser
{
	public class GetRolesToUserRequest : IRequest<GetRolesToUserResponse>
	{
		public string UserId { get; set; }
	}
}
