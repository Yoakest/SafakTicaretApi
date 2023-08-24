using SafakTicaret.Application.Repositories.MenuReadRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.MenuConcrete
{
	internal class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
	{
		public MenuReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
