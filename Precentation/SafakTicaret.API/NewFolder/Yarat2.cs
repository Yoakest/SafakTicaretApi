using MediatR;
using SafakTicaret.Application.Repositories.ProductRepository;

namespace SafakTicaret.API.NewFolder
{
	public class Yarat2 : IRequest
	{
		private IProductWriteRepository _productWriteRepository;

		public Yarat2(IProductWriteRepository productWriteRepository)
		{
			_productWriteRepository = productWriteRepository;
		}

		public async void qwe()
		{

			for (int i = 0; i < 100; i++)
			{

				Random random = new Random();
				int uruneki = random.Next(100, 1000);
				int price = random.Next(100, 60000);
				int stock = random.Next(3, 1000);
				string urunadi = $"Ürün {uruneki}";

				await _productWriteRepository.AddAsync(new Domain.Entities.Product()
				{
					Name = urunadi,
					Price = price,
					Stock = stock
				});

			}
		}

	}
}
