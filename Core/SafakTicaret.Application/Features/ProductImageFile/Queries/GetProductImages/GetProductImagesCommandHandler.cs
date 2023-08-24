using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SafakTicaret.Application.Repositories.ProductRepository;
using P = SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Features.ProductImageFile.Queries.GetProductImage
{
	public class GetProductImagesCommandHandler : IRequestHandler<GetProductImagesCommandRequest, List<GetProductImagesCommandResponse>>
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public GetProductImagesCommandHandler
			(
			IProductReadRepository productReadRepository,
			IConfiguration configuration
,
			IWebHostEnvironment webHostEnvironment)
		{
			_productReadRepository = productReadRepository;
			_configuration = configuration;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<List<GetProductImagesCommandResponse>> Handle(GetProductImagesCommandRequest request, CancellationToken cancellationToken)
		{
			P.Product? product = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

			string path = Path.Combine(_webHostEnvironment.WebRootPath, "product-images");
			await Console.Out.WriteLineAsync(path);
			if (product != null)
			{
				return product.ProductImages.Select(p => new GetProductImagesCommandResponse
				{
					Path = Path.Combine(path, p.FileName),
					FileName = p.FileName,
					Id = p.Id,
					Showcase = p.Showcase,
				}).ToList();
			}
			return new List<GetProductImagesCommandResponse>();
		}
	}
}
