using MediatR;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.DeleteProductImage
{
	public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
	{
		public string Id { get; set; }
		public string? ImageId { get; set; }
	}
}
