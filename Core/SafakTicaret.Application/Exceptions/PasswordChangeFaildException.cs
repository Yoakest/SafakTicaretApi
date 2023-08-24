namespace SafakTicaret.Application.Exceptions
{
	public class PasswordChangeFaildException : Exception
	{
		public PasswordChangeFaildException() : base("Şifre güncellenirken sorun oluştu tekrar deneyiniz..")
		{
		}

		public PasswordChangeFaildException(string? message) : base(message)
		{
		}

		public PasswordChangeFaildException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
