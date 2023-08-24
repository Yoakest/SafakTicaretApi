using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.UploadFileRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.UploadFileConcrete
{
	public class UploadFileWriteRepository : WriteRepository<UploadFile>, IUploadFileWriteRepository
	{
		public UploadFileWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
