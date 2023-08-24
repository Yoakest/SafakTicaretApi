using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.CompletedOrder;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.CompletedOrder
{
	public class CompletedOrderWriteRepository : WriteRepository<Domain.Entities.CompletedOrder>, ICompletedOrderWriteRepository
	{
		public CompletedOrderWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
