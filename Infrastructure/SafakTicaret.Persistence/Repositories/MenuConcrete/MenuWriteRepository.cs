using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.MenuReadRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.MenuConcrete
{
	public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
	{
		public MenuWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
