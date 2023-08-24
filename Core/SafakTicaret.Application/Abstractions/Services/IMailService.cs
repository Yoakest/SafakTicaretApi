namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IMailService
	{
		Task SendMailAsync(string to, string subject, string body);

		Task SendMailAsync(string[] to, string subject, string body);
		Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
		Task SendCompletedOrderMailAsync(string to, string userName, string orderCode, DateTime orderDate);

		Task Main();
	}
}
