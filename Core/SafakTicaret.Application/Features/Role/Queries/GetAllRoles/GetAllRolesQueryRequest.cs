using MediatR;

namespace SafakTicaret.Application.Features.Role.Queries.GetAllRoles
{
	public class GetAllRolesQueryRequest : IRequest<GetAllRolesQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
