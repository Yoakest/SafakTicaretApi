using MediatR;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Order.Commands.CreateOrder
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
	{
		readonly IOrderService _orderService;
		readonly IBasketServices _basketServices;
		readonly IOrderHubService _orderHubService;


		public CreateOrderCommandHandler(IOrderService orderService, IBasketServices basketServices, IOrderHubService orderHubService)
		{
			_orderService = orderService;
			_basketServices = basketServices;
			_orderHubService = orderHubService;

		}

		public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			await _orderService.CreateOrderAsync(new()
			{
				BasketId = _basketServices.GetUserActiveBaseket?.Id.ToString(),
				Adress = request.Adress,
				Description = request.Description,
			});

			await _orderHubService.OrderAddedMessageAsync("Yeni Sipariş oluşturuldu..");
			return new();
		}

	}
}