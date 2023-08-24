using Microsoft.Extensions.DependencyInjection;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.SignalR.Services;

namespace SafakTicaret.SignalR
{
	public static class ServiceRegistration
	{
		public static void AddSignalRServices(this IServiceCollection collection)
		{
			collection.AddTransient<IProductHubService, ProductHubService>();
			collection.AddTransient<IOrderHubService, OrderHubService>();
			collection.AddSignalR();
		}
	}
}
