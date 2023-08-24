using MediatR;
using SafakTicaret.Application.Exceptions;
using SafakTicaret.Application.Repositories.ProductRepository;
using Identity = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.Product.Commands.UpdateProductStockQrCode
{
	public class UpdateProductStockQrCodeCammandHandler : IRequestHandler<UpdateProductStockQrCodeCammandRequest, UpdateProductStockQrCodeCammandResponse>
	{
		readonly IProductReadRepository _productReadRepository;
		readonly IProductWriteRepository _productWriteRepository;

		public UpdateProductStockQrCodeCammandHandler(
			IProductReadRepository productReadRepository,
			IProductWriteRepository productWriteRepository)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}

		public async Task<UpdateProductStockQrCodeCammandResponse> Handle(UpdateProductStockQrCodeCammandRequest request, CancellationToken cancellationToken)
		{
			Identity.Product product = await _productReadRepository.GetByIdAsync(request.productId);
			if (product.Stock > 0)
			{
				product.Stock--;
				_productWriteRepository.Update(product);
				await _productWriteRepository.SaveAsync();
			}
			else
			{
				throw new OutOfStockExceptions();
			}

			return new();
		}
	}
}
