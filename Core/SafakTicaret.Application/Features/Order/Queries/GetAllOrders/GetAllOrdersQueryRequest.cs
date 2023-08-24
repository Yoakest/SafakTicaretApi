using MediatR;

namespace SafakTicaret.Application.Features.Order.Queries.GetOrders
{
	public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
