using MediatR;

namespace SafakTicaret.Application.Features.Product.Commands.RemoveProduct
{
	public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
	{
		public string ProductId { get; set; }
	}
}
