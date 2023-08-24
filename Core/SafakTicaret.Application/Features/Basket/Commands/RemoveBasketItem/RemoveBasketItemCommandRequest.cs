using MediatR;

namespace SafakTicaret.Application.Features.Basket.Commands.RemoveBasketItem
{
	public class RemoveBasketItemCommandRequest : IRequest<RemoveBasketItemCommandResponse>
	{
		public string RemoveBasketItemId { get; set; }
	}
}
