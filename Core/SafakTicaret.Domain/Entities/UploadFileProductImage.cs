namespace SafakTicaret.Domain.Entities
{
	public class UploadFileProductImage : UploadFile
	{
		public bool Showcase { get; set; }
		public ICollection<Product> Product { get; set; }
	}
}
