using Microsoft.Extensions.DependencyInjection;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Abstractions.Token;
using SafakTicaret.Application.Services;
using SafakTicaret.Application.Storage;
using SafakTicaret.Infrastructure.AuthorizeConfiguration;
using SafakTicaret.Infrastructure.Services;
using SafakTicaret.Infrastructure.Services.Storage;
using SafakTicaret.Infrastructure.Services.Storage.Storage;
using SafakTicaret.Infrastructure.Services.Token;

namespace SafakTicaret.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IMailService, MailService>();
			serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
			serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
			serviceCollection.AddScoped<IStorageService, StorageService>();
			serviceCollection.AddScoped<IFileUploadService, FileUploadService>();
			serviceCollection.AddScoped<IAuthorizeConfigurationService, AuthorizeConfigurationService>();
		}

		public static void AddStorage<T>(this IServiceCollection serciceCollection) where T : BaseStorage, IStorage
		{
			serciceCollection.AddScoped<IStorage, T>();
		}
	}
}
