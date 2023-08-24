using MediatR;

namespace SafakTicaret.Application.Features.Product.Queries.GetAllProducts
{
	public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
	{
		public int Page { get; set; }
		public int Size { get; set; }
	}
}
