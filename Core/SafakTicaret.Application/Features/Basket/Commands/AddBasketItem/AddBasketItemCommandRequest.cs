using MediatR;

namespace SafakTicaret.Application.Features.Basket.Commands.AddBasketItem
{
	public class AddBasketItemCommandRequest : IRequest<AddBasketItemCommandResponse>
	{
		public string ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
