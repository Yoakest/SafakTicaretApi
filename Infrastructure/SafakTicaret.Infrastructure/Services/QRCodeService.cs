using QRCoder;
using SafakTicaret.Application.Abstractions.Services;

namespace SafakTicaret.Infrastructure.Services
{
	public class QRCodeService : IQRCodeService
	{
		public byte[] GenerateQRCode(string text)
		{
			QRCodeGenerator generator = new QRCodeGenerator();
			QRCodeData data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.L);
			PngByteQRCode qrCodePng = new PngByteQRCode(data);
			byte[] byteGraphic = qrCodePng.GetGraphic(10, new byte[] { 0, 51, 0 }, new byte[] { 230, 230, 230 });
			return byteGraphic;
		}
	}
}
