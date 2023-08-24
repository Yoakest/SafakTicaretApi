using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.Product.Queries.GetByIdProduct
{
	public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
		private readonly IProductReadRepository _productReadRepository;

		public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}

		public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
		{
			P.Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
			return new GetByIdProductQueryResponse()
			{
				Name = product.Name,
				Stock = product.Stock,
				Price = product.Price,
			};
		}

	}
}
