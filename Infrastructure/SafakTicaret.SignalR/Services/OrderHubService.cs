using Microsoft.AspNetCore.SignalR;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.SignalR.Hubs;

namespace SafakTicaret.SignalR.Services
{
	public class OrderHubService : IOrderHubService
	{
		readonly IHubContext<OrderHub> _hubContext;

		public OrderHubService(IHubContext<OrderHub> hubContext)
		{
			_hubContext = hubContext;
		}

		public async Task OrderAddedMessageAsync(string message)
		{
			await _hubContext.Clients.All.SendAsync(ReciveFunctionNames.OrderAddedMessage, message);
		}
	}
}
