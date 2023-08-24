using SafakTicaret.Application.Enums;

namespace SafakTicaret.Application.CustomAttributes
{
	public class AuthorizeDefinitionAttribute : Attribute
	{
		public string Menu { get; set; }
		public string Definition { get; set; }
		public ActionType ActionType { get; set; }
	}

}
