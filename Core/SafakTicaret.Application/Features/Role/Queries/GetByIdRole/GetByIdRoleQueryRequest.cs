using MediatR;

namespace SafakTicaret.Application.Features.Role.Queries.GetByIdRole
{
	public class GetByIdRoleQueryRequest : IRequest<GetByIdRoleQueryResponse>
	{
		public string Id { get; set; }
	}
}
