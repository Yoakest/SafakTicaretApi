using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace SafakTicaret.API.Extensions
{
	static public class ConfigureExeptionHandlerExtension
	{
		public static void ConfigureExeptionHandler<T>(this WebApplication webApplication, ILogger<T> logger)
		{
			webApplication.UseExceptionHandler(builder =>
			{
				builder.Run(async contex =>
				{
					contex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					contex.Response.ContentType = MediaTypeNames.Application.Json;

					var contexFeture = contex.Features.Get<IExceptionHandlerFeature>();
					if (contexFeture != null)
					{
						logger.LogError(contexFeture.Error.Message);

						await contex.Response.WriteAsync(
							JsonSerializer.Serialize(new
							{
								StatusCode = contex.Response.StatusCode,
								Message = contexFeture.Error.Message,
								Title = "Hata oluştu."
							})
							);
					}

				});
			});
		}
	}
}
