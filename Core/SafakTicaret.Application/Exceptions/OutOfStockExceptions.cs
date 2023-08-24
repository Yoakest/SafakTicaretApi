namespace SafakTicaret.Application.Exceptions
{
	public class OutOfStockExceptions : Exception
	{
		public OutOfStockExceptions() : base("Ürün stokları tükenmiştir!!")
		{
		}

		public OutOfStockExceptions(string? message) : base(message)
		{
		}

		public OutOfStockExceptions(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
