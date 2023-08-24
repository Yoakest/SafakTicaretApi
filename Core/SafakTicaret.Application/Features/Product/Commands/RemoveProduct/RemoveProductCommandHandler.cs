using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;

namespace SafakTicaret.Application.Features.Product.Commands.RemoveProduct
{
	public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
	{
		private readonly IProductWriteRepository _productWriteRepository;

		public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository)
		{
			_productWriteRepository = productWriteRepository;
		}

		public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
		{
			await _productWriteRepository.Remove(request.ProductId);
			await _productWriteRepository.SaveAsync();
			return new()
			{
				Removed = true,
			};
		}
	}
}
