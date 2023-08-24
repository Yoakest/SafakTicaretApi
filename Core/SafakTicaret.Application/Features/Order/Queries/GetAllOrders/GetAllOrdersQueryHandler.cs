using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.Order.GetOrders;
using O = SafakTicaret.Application.DTOs.Order.GetOrders;

namespace SafakTicaret.Application.Features.Order.Queries.GetOrders
{
	public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
	{
		private readonly IOrderService _orderService;

		public GetAllOrdersQueryHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
		{
			Task<Tuple<List<GetAllOrders>, int>> orders = _orderService.GetAllOrdesAsync(request.Page, request.Size);

			int totalCount = orders.Result.Item2;
			List<O.GetAllOrders> ordersLsit = orders.Result.Item1
				.Select(o => new GetAllOrders()
				{
					CreatedDate = o.CreatedDate,
					OrderCode = o.OrderCode,
					TotalPrice = o.TotalPrice,
					UserName = o.UserName,
					OrderId = o.OrderId,
					Completed = o.Completed,
				}).ToList();


			return new GetAllOrdersQueryResponse()
			{
				Orders = ordersLsit,
				TotalCount = totalCount
			};
		}

	}
}
