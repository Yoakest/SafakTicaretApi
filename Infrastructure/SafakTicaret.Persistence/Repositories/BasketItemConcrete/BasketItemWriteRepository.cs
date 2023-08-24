using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.BasketItemRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.BasketItemConcrete
{
	public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
	{
		public BasketItemWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
