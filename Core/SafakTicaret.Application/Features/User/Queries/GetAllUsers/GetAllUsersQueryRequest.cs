using MediatR;

namespace SafakTicaret.Application.Features.User.Queries.GettAllUsers
{
	public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
