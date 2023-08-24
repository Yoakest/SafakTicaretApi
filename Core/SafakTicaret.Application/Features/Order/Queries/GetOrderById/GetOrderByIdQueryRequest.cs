using MediatR;

namespace SafakTicaret.Application.Features.Order.Queries.GetOrderById
{
	public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
	{
		public string Id { get; set; }
	}
}
