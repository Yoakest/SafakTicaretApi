using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.UploadFileProductImageConcrete
{
	public class UploadFileProductImageWriteRepository : WriteRepository<UploadFileProductImage>, IUploadFileProductImageWriteRepository
	{
		public UploadFileProductImageWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
