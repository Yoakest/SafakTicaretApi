using SafakTicaret.Domain.Entities.Common;

namespace SafakTicaret.Domain.Entities
{
	public class Menu : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Endpoint> Endpoints { get; set; }
	}
}
