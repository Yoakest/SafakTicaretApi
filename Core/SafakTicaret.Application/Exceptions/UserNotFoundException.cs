namespace SafakTicaret.Application.Exceptions
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException() : base("Giriş Bilgileri Hatalı")
		{
		}

		public UserNotFoundException(string? message) : base(message)
		{
		}

		public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
