using Microsoft.AspNetCore.Builder;
using SafakTicaret.SignalR.Hubs;

namespace SafakTicaret.SignalR
{
	public static class HubRegistration
	{
		public static void MapHubs(this WebApplication webApplication)
		{
			webApplication.MapHub<ProductHub>(ReciveFunctionNames.ProductsMapHub);
			webApplication.MapHub<OrderHub>(ReciveFunctionNames.OrderMapHub);
		}
	}
}
