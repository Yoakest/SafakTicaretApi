using MediatR;
using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;
using SafakTicaret.Domain.Entities;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.DeleteProductImage
{
	public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IUploadFileProductImageWriteRepository _uploadFileProductImageWriteRepository;


		public DeleteProductImageCommandHandler(
			IProductReadRepository productReadRepository,
			IUploadFileProductImageWriteRepository uploadFileProductImageWriteRepository
			)
		{
			_productReadRepository = productReadRepository;
			_uploadFileProductImageWriteRepository = uploadFileProductImageWriteRepository;
		}

		public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
		{
			P.Product product = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

			UploadFileProductImage productImage = product.ProductImages.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

			product.ProductImages.Remove(productImage);

			await _uploadFileProductImageWriteRepository.SaveAsync();


			return new()
			{
				IsSuccess = true
			};
		}
	}
}
