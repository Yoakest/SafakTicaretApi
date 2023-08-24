using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Basket.Commands.AddBasketItem
{
	public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommandRequest, AddBasketItemCommandResponse>
	{
		readonly IBasketServices _basketService;

		public AddBasketItemCommandHandler(IBasketServices basketService)
		{
			_basketService = basketService;
		}

		public async Task<AddBasketItemCommandResponse> Handle(AddBasketItemCommandRequest request, CancellationToken cancellationToken)
		{
			await _basketService.AddItemToBasketAsync(new()
			{
				ProductId = request.ProductId,
				Quantity = request.Quantity,
			});

			return new();
		}
	}
}
