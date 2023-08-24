namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IProductService
	{
		Task<byte[]> QrCodeToProductAsync(string productId);
		Task<byte[]> ProductImageAsync(string name);
	}
}
