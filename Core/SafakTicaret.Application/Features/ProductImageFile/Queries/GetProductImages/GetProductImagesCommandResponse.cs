namespace SafakTicaret.Application.Features.ProductImageFile.Queries.GetProductImage
{
	public class GetProductImagesCommandResponse
	{
		public string Path { get; set; }
		public string FileName { get; set; }
		public Guid Id { get; set; }
		public bool Showcase { get; set; }
	}
}
