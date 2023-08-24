using SafakTicaret.Application.Repositories.UploadFileInvoiceRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.UploadFileInvoiceConcrete
{
	public class UploadFileInvoiceReadRepository : ReadRepository<UploadFileInvoice>, IUploadFileInvoiceReadRepository
	{
		public UploadFileInvoiceReadRepository(SafakTicaretDbContext context) : base(context)
		{
		}
	}
}
