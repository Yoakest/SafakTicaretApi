using SafakTicaret.Application.Repositories.BasketItemRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.BasketItemConcrete
{
	internal class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
	{
		public BasketItemReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
