using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.EndpointRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.EndpointConcrete
{
	public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
	{
		public EndpointWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
