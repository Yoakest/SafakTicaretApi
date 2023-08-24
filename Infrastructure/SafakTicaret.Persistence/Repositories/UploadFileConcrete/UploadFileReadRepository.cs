using SafakTicaret.Application.Repositories.UploadFileRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories
{
	public class UploadFileReadRepository : ReadRepository<UploadFile>, IUploadFileReadRepository
	{
		public UploadFileReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
