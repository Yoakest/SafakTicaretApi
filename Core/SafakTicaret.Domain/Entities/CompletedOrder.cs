using SafakTicaret.Domain.Entities.Common;

namespace SafakTicaret.Domain.Entities
{
	public class CompletedOrder : BaseEntity
	{
		public Guid OrderId { get; set; }
		public Order Order { get; set; }
	}
}
