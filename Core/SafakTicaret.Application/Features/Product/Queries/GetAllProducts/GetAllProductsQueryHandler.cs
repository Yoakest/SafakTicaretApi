using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.Product.Queries.GetAllProducts
{
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
	{
		private readonly IProductReadRepository _productReadRepository;

		public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}

		public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<P.Product> products = _productReadRepository.GetAll(false);
			int totalProducts = products.Count();
			var pagedProducts = products
				//Ürün adına göre sıralıyor
				.OrderBy(p => p.Name)
				.Skip(request.Page * request.Size)
				.Take(request.Size)
				.Select(p => new
				{
					p.Id,
					p.Name,
					p.Price,
					p.Stock,
					p.CreatedDate,
					p.UpdatedDate,
					p.ProductImages
				})
				.ToList();

			return new GetAllProductsQueryResponse()
			{
				Products = pagedProducts,
				TotalCount = totalProducts
			};
		}
	}
}
