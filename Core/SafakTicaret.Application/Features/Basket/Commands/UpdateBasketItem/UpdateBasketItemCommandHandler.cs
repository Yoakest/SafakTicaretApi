using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Basket.Commands.UpdateBasketItem
{
	public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
	{
		readonly IBasketServices _basketServices;

		public UpdateBasketItemCommandHandler(IBasketServices basketServices)
		{
			_basketServices = basketServices;
		}

		public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
		{
			await _basketServices.UpdateQuantityAsync(new()
			{
				BasketItemId = request.BasketItemId,
				Quantity = request.Quantity
			});
			return new();
		}
	}
}
