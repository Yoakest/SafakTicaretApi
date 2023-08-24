using Microsoft.AspNetCore.Hosting;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Domain.Entities;
using System.Text.Json;

namespace SafakTicaret.Persistence.Services
{
	public class ProductService : IProductService
	{
		readonly IProductReadRepository _productReadRepository;
		readonly IProductWriteRepository _productWriteRepository;
		readonly IQRCodeService _qrCodeService;
		readonly IWebHostEnvironment _webHostEnvironment;


		public ProductService(
			IProductReadRepository productReadRepository,
			IProductWriteRepository productWriteRepository,
			IQRCodeService qrCodeService,
			IWebHostEnvironment webHostEnvironment)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
			_qrCodeService = qrCodeService;
			_webHostEnvironment = webHostEnvironment;
		}


		public async Task<byte[]> QrCodeToProductAsync(string productId)
		{
			Product product = await _productReadRepository.GetByIdAsync(productId);
			if (product != null)
			{
				var plainObject = new
				{
					product.Id,
					product.Name,
					product.Price,
					product.Stock
				};
				string plainText = JsonSerializer.Serialize(plainObject);
				return _qrCodeService.GenerateQRCode(plainText);
			}
			else
			{
				throw new Exception("Product Not Found");
			}
		}

		public async Task<byte[]> ProductImageAsync(string name)
		{
			var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "product-images", name);
			Console.WriteLine(imagePath);
			return System.IO.File.ReadAllBytes(imagePath);
		}


	}
}
