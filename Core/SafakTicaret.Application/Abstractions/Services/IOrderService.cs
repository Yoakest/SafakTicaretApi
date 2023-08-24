using SafakTicaret.Application.DTOs.Order.CompletedOrderMail;
using SafakTicaret.Application.DTOs.Order.CreateOrder;
using SafakTicaret.Application.DTOs.Order.GetOrders;
using SafakTicaret.Application.DTOs.Order.SingleOrder;

namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IOrderService
	{
		Task CreateOrderAsync(CreateOrder createOrder);
		Task<Tuple<List<GetAllOrders>, int>> GetAllOrdesAsync(int page, int size);
		Task<SingleOrder> GetOrderByIdAsync(string id);
		Task<CompletedOrderMail> CompleteOrderAsync(string id);
	}
}
