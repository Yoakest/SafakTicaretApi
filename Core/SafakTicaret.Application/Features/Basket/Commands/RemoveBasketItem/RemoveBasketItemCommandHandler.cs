using MediatR;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Application.Features.Basket.Commands.RemoveBasketItem
{
	internal class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommandRequest, RemoveBasketItemCommandResponse>
	{
		readonly IBasketServices _basketServices;

		public RemoveBasketItemCommandHandler(IBasketServices basketServices)
		{
			_basketServices = basketServices;
		}

		public async Task<RemoveBasketItemCommandResponse> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
		{
			await _basketServices.RemoveBasketItemAsync(request.RemoveBasketItemId);
			return new();
		}
	}
}
