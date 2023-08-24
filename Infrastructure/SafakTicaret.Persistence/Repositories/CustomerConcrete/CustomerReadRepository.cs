using SafakTicaret.Application.Repositories.CutomerRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;


namespace SafakTicaret.Persistence.Repositories.CustomerConcrete
{
	public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
	{
		public CustomerReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
