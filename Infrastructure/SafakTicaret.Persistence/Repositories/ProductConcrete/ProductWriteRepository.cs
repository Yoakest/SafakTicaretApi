using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.ProductConcrete
{
	public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
	{
		public ProductWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
