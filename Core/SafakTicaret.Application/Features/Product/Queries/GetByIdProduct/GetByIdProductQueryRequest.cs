using MediatR;

namespace SafakTicaret.Application.Features.Product.Queries.GetByIdProduct
{
	public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
	{
		public string Id { get; set; }
	}

}

