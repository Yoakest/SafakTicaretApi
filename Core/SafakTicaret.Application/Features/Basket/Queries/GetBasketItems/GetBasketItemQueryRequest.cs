using MediatR;

namespace SafakTicaret.Application.Features.Basket.Queries.GetBasketItems
{
	public class GetBasketItemQueryRequest : IRequest<List<GetBasketItemQueryResponse>>
	{
	}
}
