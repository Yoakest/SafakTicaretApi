using SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Repositories.OrderRepository
{
	public interface IOrderReadRepository : IReadRepository<Order>
	{
		bool IsOrderCodeUnique(string orderCode);
	}
}
