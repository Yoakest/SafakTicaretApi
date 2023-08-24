using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.ProductConcrete
{
	public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
	{
		public ProductReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
