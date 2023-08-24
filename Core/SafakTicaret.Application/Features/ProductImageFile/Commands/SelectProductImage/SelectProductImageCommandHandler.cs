using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.SelectProductImage
{
	public class SelectProductImageCommandHandler : IRequestHandler<SelectProductImageCommandRequest, SelectProductImageCommandResponse>
	{
		readonly IUploadFileProductImageWriteRepository _uploadFileProductImageWriteRepository;


		public SelectProductImageCommandHandler(
			IUploadFileProductImageWriteRepository uploadFileProductImageWriteRepository)
		{
			_uploadFileProductImageWriteRepository = uploadFileProductImageWriteRepository;
		}

		public async Task<SelectProductImageCommandResponse> Handle([FromBody] SelectProductImageCommandRequest request, CancellationToken cancellationToken)
		{
			var query = _uploadFileProductImageWriteRepository.Table
				.Include(p => p.Product)
				.SelectMany(p => p.Product, (pif, p) => new
				{
					pif,
					p
				});

			var oldImage = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.Showcase);
			if (oldImage != null)
				oldImage.pif.Showcase = false;

			var newImage = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
			newImage.pif.Showcase = true;

			await _uploadFileProductImageWriteRepository.SaveAsync();

			return new()
			{
				IsSuccess = true,
				Message = $"{newImage.pif.FileName} showcase seçildi"
			};
		}
	}
}
