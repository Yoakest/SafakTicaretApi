using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.Product.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
	{
		IProductWriteRepository _productWriteRepository;
		IProductReadRepository _productReadRepository;

		public UpdateProductCommandHandler(
			IProductReadRepository productReadRepository,
			IProductWriteRepository productWriteRepository
			)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}


		public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			P.Product product = await _productReadRepository.GetByIdAsync(request.Id);
			product.Stock = request.Stock;
			product.Name = request.Name;
			product.Price = request.Price;
			await _productWriteRepository.SaveAsync();

			return new()
			{
				Updated = true,
			};
		}
	}
}
