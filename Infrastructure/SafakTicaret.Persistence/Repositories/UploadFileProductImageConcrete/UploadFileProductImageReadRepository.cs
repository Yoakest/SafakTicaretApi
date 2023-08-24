using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.UploadFileProductImageConcrete
{
	public class UploadFileProductImageReadRepository : ReadRepository<UploadFileProductImage>, IUploadFileProductImageReadRepository
	{
		public UploadFileProductImageReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
