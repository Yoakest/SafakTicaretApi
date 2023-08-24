using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories.UploadFileInvoiceRepository;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories.UploadFileInvoiceConcrete
{
	public class UploadFileInvoiceWriteRepository : WriteRepository<UploadFileInvoice>, IUploadFileInvoiceWriteRepository
	{
		public UploadFileInvoiceWriteRepository(SafakTicaretDbContext context, IProductHubService productHubService) : base(context, productHubService)
		{
		}
	}
}
