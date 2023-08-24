using MediatR;

namespace SafakTicaret.Application.Features.Product.Commands.CeateProduct
{
	public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public float Price { get; set; }
	}
}
