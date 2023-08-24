using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Consts;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.Features.Product.Commands.CeateProduct;
using SafakTicaret.Application.Features.Product.Commands.RemoveProduct;
using SafakTicaret.Application.Features.Product.Commands.UpdateProduct;
using SafakTicaret.Application.Features.Product.Commands.UpdateProductStockQrCode;
using SafakTicaret.Application.Features.Product.Queries.GetAllProducts;
using SafakTicaret.Application.Features.Product.Queries.GetByIdProduct;
using SafakTicaret.Application.Features.ProductImageFile.Commands.DeleteProductImage;
using SafakTicaret.Application.Features.ProductImageFile.Commands.SelectProductImage;
using SafakTicaret.Application.Features.ProductImageFile.Commands.UploadProductImage;
using SafakTicaret.Application.Features.ProductImageFile.Queries.GetProductImage;
using SafakTicaret.Application.Repositories.ProductRepository;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IProductWriteRepository _productWriteRepository;
		readonly IProductService _productService;

		public ProductController(
			IMediator mediator,
			IProductWriteRepository productWriteRepository,
			IProductService productService)
		{
			_mediator = mediator;
			_productWriteRepository = productWriteRepository;
			_productService = productService;
		}


		//Bütün ürünleri getiriyor
		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Products")]
		public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest getAllProductsQueryRequest)
		{
			return Ok(await _mediator.Send(getAllProductsQueryRequest));
		}


		//Ürün Id göre bir ürün getiriyor
		[HttpGet("{Id}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get Product By Id")]
		public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
		{
			return Ok(await _mediator.Send(getByIdProductQueryRequest));
		}


		[HttpGet("updatestock/{productId}")]
		public async Task<IActionResult> UpdateProductStockQrCode([FromRoute] UpdateProductStockQrCodeCammandRequest updateProductStockQrCodeCammandRequest)
		{

			return Ok(await _mediator.Send(updateProductStockQrCodeCammandRequest));
		}


		[HttpGet("[action]")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing, Definition = "Create packet product")]
		public async Task<IActionResult> Yarat()
		{
			for (int i = 0; i < 100; i++)
			{

				Random random = new Random();
				int uruneki = random.Next(100, 1000);
				int price = random.Next(100, 60000);
				int stock = random.Next(3, 1000);
				string urunadi = $"Ürün {uruneki}";

				await _productWriteRepository.AddAsync(new Domain.Entities.Product()
				{
					Name = urunadi,
					Price = price,
					Stock = stock
				});

				await _productWriteRepository.SaveAsync();


				Console.WriteLine("ürün " + i);

			}
			return Ok("Yarrat");
		}


		//Bir ürün oluşturuyor
		[HttpPost]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing, Definition = "Create Product")]
		public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
		{
			await _mediator.Send(createProductCommandRequest);
			return Ok();
		}


		//Id'si verilen ürünün istenilen özellikleri değiştiriliyor
		[HttpPut]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Updating, Definition = "Update Product")]
		public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
		{
			return Ok(await _mediator.Send(updateProductCommandRequest));
		}

		//Id'si verilen ürün siliniyor
		[HttpDelete("{ProductId}")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Deleting, Definition = "Delete Product")]
		public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
		{
			return Ok(await _mediator.Send(removeProductCommandRequest));
		}


		//Gelen dosyalar kaydediliyor
		[HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing, Definition = "Upload Product Images")]
		public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
		{
			uploadProductImageCommandRequest.FormCollection = Request.Form.Files;
			return Ok(await _mediator.Send(uploadProductImageCommandRequest));
		}


		//Id'si verilen ürünün fotoğrafları gönderiliyor
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All  Product Images")]
		public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesCommandRequest getProductImagesCommandRequest)
		{
			return Ok(await _mediator.Send(getProductImagesCommandRequest));
		}


		//Id'si verilen ürüne ait dosyalar siliniyor
		[HttpDelete("[action]/{Id}")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Deleting, Definition = "Delete Product Image")]
		public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageCommandRequest deleteProductImageCommandRequest, [FromQuery] string ImageId)
		{
			deleteProductImageCommandRequest.ImageId = ImageId;
			return Ok(await _mediator.Send(deleteProductImageCommandRequest));
		}

		[HttpGet("[action]")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing, Definition = "Select Showcase Image")]
		public async Task<IActionResult> SelectImageFile([FromQuery] SelectProductImageCommandRequest selectProductImageCommandRequest)
		{

			return Ok(await _mediator.Send(selectProductImageCommandRequest));
		}

		//name'si verilen fotoğraf gönderiliyor
		[HttpGet("[action]/{Name}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All  Product Images")]
		public async Task<IActionResult> GetImage([FromRoute] string Name)
		{
			var data = await _productService.ProductImageAsync(Name);
			return File(data, "image/png");
		}

		[HttpGet("qrcode/{productId}")]
		public async Task<IActionResult> GetQrCodeToProduct([FromRoute] string productId)
		{
			var data = await _productService.QrCodeToProductAsync(productId);
			return File(data, "image/png");
		}

	}
}
