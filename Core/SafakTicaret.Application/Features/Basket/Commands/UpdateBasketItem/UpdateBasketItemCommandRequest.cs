using MediatR;

namespace SafakTicaret.Application.Features.Basket.Commands.UpdateBasketItem
{
	public class UpdateBasketItemCommandRequest : IRequest<UpdateBasketItemCommandResponse>
	{
		public string BasketItemId { get; set; }
		public int Quantity { get; set; }
	}
}
