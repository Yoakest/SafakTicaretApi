using Microsoft.AspNetCore.SignalR;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.SignalR.Hubs;

namespace SafakTicaret.SignalR.Services
{
	public class ProductHubService : IProductHubService
	{
		readonly IHubContext<ProductHub> _hubContext;

		public ProductHubService(IHubContext<ProductHub> hubContext)
		{
			_hubContext = hubContext;
		}

		public async Task ProductAddedMessageAsync(string message)
		{
			await _hubContext.Clients.All.SendAsync(ReciveFunctionNames.ProductAddedMessage, message);
		}
	}
}
