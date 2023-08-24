using SafakTicaret.Application.Repositories.BasketRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.BasketConcrete
{
	public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
	{
		public BasketReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
