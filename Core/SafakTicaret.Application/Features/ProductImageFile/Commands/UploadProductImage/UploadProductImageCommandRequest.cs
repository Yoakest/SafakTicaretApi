using MediatR;
using Microsoft.AspNetCore.Http;

namespace SafakTicaret.Application.Features.ProductImageFile.Commands.UploadProductImage
{
	public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
	{
		public string id { get; set; }
		public IFormFileCollection? FormCollection { get; set; }
	}
}
