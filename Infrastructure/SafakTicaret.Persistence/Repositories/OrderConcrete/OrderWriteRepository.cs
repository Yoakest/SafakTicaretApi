using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.OrderRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.OrderConcrete
{
	public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
	{
		public OrderWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
