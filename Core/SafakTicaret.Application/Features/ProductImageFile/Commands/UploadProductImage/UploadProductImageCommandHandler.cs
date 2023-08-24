using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;
using SafakTicaret.Application.Storage;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.UploadProductImage
{
	public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
	{
		IStorageService _storageService;
		IProductReadRepository _productReadRepository;
		IUploadFileProductImageWriteRepository _uploadFileProductImageWriteRepository;

		public UploadProductImageCommandHandler(
			IUploadFileProductImageWriteRepository uploadFileProductImageWriteRepository,
			IProductReadRepository productReadRepository,
			IStorageService storageService
			)
		{
			_uploadFileProductImageWriteRepository = uploadFileProductImageWriteRepository;
			_productReadRepository = productReadRepository;
			_storageService = storageService;
		}

		public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
		{

			List<(string name, string path)> datas = await _storageService.UploadAsync("product-images", request.FormCollection);

			P.Product product = await _productReadRepository.GetByIdAsync(request.id);


			await _uploadFileProductImageWriteRepository.AddListAsync(datas.Select(d => new P.UploadFileProductImage()
			{
				FileName = d.name,
				Path = d.path,
				Product = new List<P.Product>() { product }
			}).ToList());

			await _uploadFileProductImageWriteRepository.SaveAsync();


			return new()
			{
				IsSuccess = true,
			};
		}
	}
}
