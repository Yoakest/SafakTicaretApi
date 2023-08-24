using SafakTicaret.Application.Repositories.OrderRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.OrderConcrete
{
	public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
	{
		public OrderReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}

		public bool IsOrderCodeUnique(string orderCode)
		{
			bool isUnique = !Table.Any(order => order.OrderCode == orderCode);
			return isUnique;
		}

	}
}
