using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.Order.SingleOrder;

namespace SafakTicaret.Application.Features.Order.Queries.GetOrderById
{
	public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
	{
		readonly IOrderService _orderService;

		public GetOrderByIdQueryHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}


		public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
		{
			SingleOrder data = await _orderService.GetOrderByIdAsync(request.Id);
			await Console.Out.WriteLineAsync("qwik");
			GetOrderByIdQueryResponse data2 = new GetOrderByIdQueryResponse()
			{
				Id = data.Id,
				OrderCode = data.OrderCode,
				Adress = data.Adress,
				BasketItems = data.BasketItems,
				CreatedDate = data.CreatedDate,
				Description = data.Description,
				Completed = data.Completed,
			};


			return data2;

		}
	}
}
