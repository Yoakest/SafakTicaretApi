using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Globalization;
using System.Net;

namespace SafakTicaret.Infrastructure.Services
{
	public class MailService : Application.Abstractions.Services.IMailService
	{
		readonly IConfiguration _configuration;

		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public async Task SendMailAsync(string to, string subject, string body)
		{
			await SendMailAsync(new[] { to }, subject, body);
		}





		public async Task SendMailAsync(string[] to, string subject, string body)
		{

			// Compose a message
			MimeMessage mail = new MimeMessage();

			mail.From.Add(new MailboxAddress("SafakTicaret", _configuration["Mail:Username"]));
			foreach (var ato in to)
			{
				mail.To.Add(new MailboxAddress("Excited User", ato));
			}
			mail.Subject = "Hello";
			mail.Body = new TextPart("html")
			{
				Text = body
			};

			Console.WriteLine(mail);


			// Send it!
			using (var client = new MailKit.Net.Smtp.SmtpClient())
			{
				// XXX - Should this be a little different?
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;

				client.Connect("smtp.mailgun.org", 587, false);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Authenticate(_configuration["Mail:Username"], _configuration["Mail:Password"]);

				client.Send(mail);
				client.Disconnect(true);
			}
			Console.WriteLine("MAİL MAİL GÖBDERİLDİ");

		}

		public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
		{
			string Text =
@"
<body style=""font-family: Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 0;"">

	<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""background-color: #f5f5f5;"">
		<tr>
			<td align=""center"" style=""padding: 20px;"">
				<table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);"">
					<tr>
						<td align=""center"" style=""padding: 30px;"">
							<h1 style=""color: #333333;"">Şifre Yenileme İsteği</h1>
							<p style=""font-size: 16px; color: #666666;"">Merhaba,</p>
							<p style=""font-size: 16px; color: #666666;"">Şifre yenileme isteği aldık. Şifrenizi yenilemek için aşağıdaki bağlantıyı kullanabilirsiniz:</p>
							<p style=""font-size: 16px; color: #666666;""><a href=";
			Text += "\"" + _configuration["ResetPasswordUrl"] + userId + "/" + resetToken + "\"";
			Text += @"style = ""color: #007bff; text-decoration: none;"">Şifre Yenileme</a></p>
							<p style = ""font-size: 16px; color: #666666;"">Eğer şifre yenileme isteği göndermediyseniz, bu e-postayı görmezden gelebilirsiniz.</p>
							<p style = ""font-size: 16px; color: #666666;"">Saygılarımla,<br>Siteniz Ekibi</p>
						</td >
					</tr >
				</table >
			</td >
		</tr >
	</table >
</body >
<html >
";

			await SendMailAsync(to, "Şifre yenileme talebi", Text);

		}


		public async Task SendCompletedOrderMailAsync(string to, string userName, string orderCode, DateTime orderDate)
		{
			string Text =
@"
<body>
	<div style = ""font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;"" >
		<h2 > Sipariş Tamamlandı! </h2 >
		<p > Merhaba " + userName + @"</p >
		<p > Siparişiniz başarıyla tamamlandı. Aşağıda sipariş detaylarını bulabilirsiniz:</p >
		<table style = ""border-collapse: collapse; width: 100%;"" >
			<tr >
				<th style = ""border: 1px solid #ddd; padding: 8px;"" > Sipariş Kodu </th >
				<th style = ""border: 1px solid #ddd; padding: 8px;"" > Tamamlanma Tarihi </th >
			</tr >
			<tr >
				<td style = ""border: 1px solid #ddd; padding: 8px;"" >" + orderCode + @"</td >
				<td style = ""border: 1px solid #ddd; padding: 8px;"" >" + orderDate.ToString("dd MMMM yyyy HH:mm", new CultureInfo("tr-TR")) + @"</td >
			</tr >
		</table >
		<p > Teşekkür ederiz.</p >
	</div >
</body >
";

			await SendMailAsync(to, "Şifre yenileme talebi", Text);

		}

		public async Task Main()
		{
			Console.WriteLine("Sent1");

			var client = new System.Net.Mail.SmtpClient("live.smtp.mailtrap.io", 587)
			{
				Credentials = new NetworkCredential("api", "453d2ab2e6a1341166a774face39de19"),
				EnableSsl = true
			};
			Console.WriteLine("Sent22");

			client.Send("mailtrap@safakticaret.godaddysites.com", "shafaktm@gmail.com", "Hello world", "testbody");
			Console.WriteLine("Sent2");

		}
	}
}