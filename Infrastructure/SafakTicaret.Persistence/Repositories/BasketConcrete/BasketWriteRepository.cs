using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.BasketRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.BasketConcrete
{
	public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
	{
		public BasketWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
