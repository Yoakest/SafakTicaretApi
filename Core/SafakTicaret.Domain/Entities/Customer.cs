using SafakTicaret.Domain.Entities.Common;

namespace SafakTicaret.Domain.Entities
{
	public class Customer : BaseEntity
	{
		public String Name { get; set; }
		//public ICollection<Order> Orders { get; set; }
	}
}
