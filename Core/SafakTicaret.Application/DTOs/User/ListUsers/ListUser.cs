namespace SafakTicaret.Application.DTOs.User.ListUsers
{
	public class ListUser
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string NameSurname { get; set; }
		public bool TwoFactorEneble { get; set; }

	}
}
