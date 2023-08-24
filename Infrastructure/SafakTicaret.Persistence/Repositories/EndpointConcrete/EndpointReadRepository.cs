using SafakTicaret.Application.Repositories.EndpointRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.EndpointConcrete
{
	public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
	{
		public EndpointReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
