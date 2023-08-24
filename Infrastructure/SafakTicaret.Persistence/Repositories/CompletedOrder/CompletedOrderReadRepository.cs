using SafakTicaret.Application.Repositories.CompletedOrder;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.CompletedOrder
{
	public class CompletedOrderReadRepository : ReadRepository<Domain.Entities.CompletedOrder>, ICompletedOrderReadRepository
	{
		public CompletedOrderReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
