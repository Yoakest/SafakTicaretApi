using MediatR;

namespace SafakTicaret.Application.Features.Product.Commands.UpdateProductStockQrCode
{
	public class UpdateProductStockQrCodeCammandRequest : IRequest<UpdateProductStockQrCodeCammandResponse>
	{
		public string productId { get; set; }
	}
}
