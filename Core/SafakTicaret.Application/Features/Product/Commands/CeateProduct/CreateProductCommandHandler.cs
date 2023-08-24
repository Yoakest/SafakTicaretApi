using MediatR;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.ProductRepository;

namespace SafakTicaret.Application.Features.Product.Commands.CeateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
	{
		readonly IProductWriteRepository _productWriteRepository;
		readonly IProductHubService _productHubService;

		public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService productHubService)
		{
			_productWriteRepository = productWriteRepository;
			_productHubService = productHubService;
		}

		public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{


			await _productWriteRepository.AddAsync(new()
			{
				Name = request.Name,
				Price = request.Price,
				Stock = request.Stock,
			});

			//await _productHubService.ProductAddedMessageAsync($"Ürün eklenmiştir.");
			await _productWriteRepository.SaveAsync();

			return new();

		}
	}
}
