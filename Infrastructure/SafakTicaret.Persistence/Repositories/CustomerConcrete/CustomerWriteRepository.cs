using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.CutomerRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.CustomerConcrete
{
	public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
	{
		public CustomerWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
