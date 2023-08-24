using MediatR;

namespace SafakTicaret.Application.Features.ProductImageFile.Queries.GetProductImage
{
	public class GetProductImagesCommandRequest : IRequest<List<GetProductImagesCommandResponse>>
	{
		public string Id { get; set; }
	}
}
