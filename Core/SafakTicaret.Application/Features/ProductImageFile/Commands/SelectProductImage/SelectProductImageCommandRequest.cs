using MediatR;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.SelectProductImage
{
	public class SelectProductImageCommandRequest : IRequest<SelectProductImageCommandResponse>
	{
		public string ProductId { get; set; }
		public string ImageId { get; set; }
	}
}
