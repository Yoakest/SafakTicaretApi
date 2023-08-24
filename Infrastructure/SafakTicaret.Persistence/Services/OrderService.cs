using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.Order.CompletedOrderMail;
using SafakTicaret.Application.DTOs.Order.CreateOrder;
using SafakTicaret.Application.DTOs.Order.GetOrders;
using SafakTicaret.Application.DTOs.Order.SingleOrder;
using SafakTicaret.Application.Repositories.CompletedOrder;
using SafakTicaret.Application.Repositories.OrderRepository;
using SafakTicaret.Domain.Entities;

namespace SafakTicaret.Persistence.Services
{
	public class OrderService : IOrderService
	{
		readonly IOrderWriteRepository _orderWriteRepository;
		readonly IOrderReadRepository _orderReadRepository;
		readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
		readonly ICompletedOrderReadRepository _completedOrderReadRepository;

		public OrderService(
			IOrderWriteRepository orderWriteRepository,
			IOrderReadRepository orderReadRepository,
			ICompletedOrderWriteRepository completedOrderWriteRepository,
			ICompletedOrderReadRepository completedOrderReadRepository)
		{
			_orderWriteRepository = orderWriteRepository;
			_orderReadRepository = orderReadRepository;
			_completedOrderWriteRepository = completedOrderWriteRepository;
			_completedOrderReadRepository = completedOrderReadRepository;
		}


		public async Task CreateOrderAsync(CreateOrder createOrder)
		{

			string orderCode = GenerateUniqueOrderCode();

			await _orderWriteRepository.AddAsync(new()
			{
				Id = Guid.Parse(createOrder.BasketId),
				Adress = createOrder.Adress,
				Description = createOrder.Description,
				OrderCode = orderCode,
			});

			await _orderWriteRepository.SaveAsync();
		}

		public async Task<Tuple<List<GetAllOrders>, int>> GetAllOrdesAsync(int page, int size)
		{
			IIncludableQueryable<Order, Product> query = _orderReadRepository.Table
				.Include(o => o.Basket)
					.ThenInclude(b => b.User)
				.Include(o => o.Basket)
					.ThenInclude(b => b.BasketItems)
					.ThenInclude(bi => bi.Product);


			IQueryable<Order> orders = query
			.OrderByDescending(o => o.CreatedDate)
			.Skip(page * size)
			.Take(size);


			IQueryable<GetAllOrders> data = from order in orders
											join CompletedOrder in _completedOrderReadRepository.Table
											on order.Id equals CompletedOrder.OrderId into co
											from _co in co.DefaultIfEmpty()
											select new GetAllOrders
											{
												OrderId = order.Id.ToString(),
												CreatedDate = order.CreatedDate,
												OrderCode = order.OrderCode,
												TotalPrice = order.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
												UserName = order.Basket.User.UserName,
												Completed = _co != null ? true : false,
											};

			int orderCount = await query.CountAsync();

			return new Tuple<List<GetAllOrders>, int>(await data.ToListAsync(), orderCount);
		}

		public async Task<SingleOrder> GetOrderByIdAsync(string id)
		{
			var data = _orderReadRepository.Table
								 .Include(o => o.Basket)
									 .ThenInclude(b => b.BasketItems)
										 .ThenInclude(bi => bi.Product);

			var data2 = await (from order in data
							   join completedOrder in _completedOrderReadRepository.Table
									on order.Id equals completedOrder.OrderId into co
							   from _co in co.DefaultIfEmpty()
							   select new SingleOrder
							   {
								   Id = order.Id.ToString(),
								   CreatedDate = order.CreatedDate,
								   OrderCode = order.OrderCode,
								   BasketItems = order.Basket.BasketItems.Select(bi => new
								   {
									   bi.Product.Name,
									   bi.Product.Price,
									   bi.Quantity,
								   }),
								   Completed = _co != null ? true : false,
								   Adress = order.Adress,
								   Description = order.Description
							   }).FirstOrDefaultAsync(o => o.Id == id);

			return data2;
		}

		private string GenerateUniqueOrderCode()
		{
			string orderCode;
			do
			{
				orderCode = (new Random().Next(111111111, 999999999)).ToString() + (new Random().Next(111111111, 999999999)).ToString();
			} while (!_orderReadRepository.IsOrderCodeUnique(orderCode)); // Bu metodu gerçekten implemente etmeniz gerekecektir.

			return orderCode;
		}

		public async Task<CompletedOrderMail> CompleteOrderAsync(string id)
		{

			Order? order = await _orderReadRepository.Table
				.Include(o => o.Basket)
				.ThenInclude(b => b.User).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

			if (order != null)
			{
				await _completedOrderWriteRepository.AddAsync(new CompletedOrder() { OrderId = Guid.Parse(id) });
				await _completedOrderWriteRepository.SaveAsync();
				return new CompletedOrderMail()
				{
					Email = order.Basket.User.Email,
					IsSuccess = true,
					OrderCode = order.OrderCode,
					OrderDate = DateTime.UtcNow,
					UserName = order.Basket.User.UserName
				};
			}
			return null;
		}

	}
}
