using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.Basket.Queries.GetBasketItems
{
	public class GetBasketItemQueryHandler : IRequestHandler<GetBasketItemQueryRequest, List<GetBasketItemQueryResponse>>
	{
		readonly IBasketServices _basketServices;

		public GetBasketItemQueryHandler(IBasketServices basketServices)
		{
			_basketServices = basketServices;
		}

		public async Task<List<GetBasketItemQueryResponse>> Handle(GetBasketItemQueryRequest request, CancellationToken cancellationToken)
		{
			List<BasketItem> basketItems = await _basketServices.GetBasketItemsAsync();
			return basketItems.Select(ba => new GetBasketItemQueryResponse()
			{
				Id = ba.Id.ToString(),
				Name = ba.Product.Name,
				Price = ba.Product.Price,
				Quantity = ba.Quantity
			}).ToList();
		}
	}
}