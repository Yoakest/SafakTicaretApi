namespace SafakTicaret.Application.DTOs.Order.CompletedOrderMail
{
	public class CompletedOrderMail
	{
		public string OrderCode { get; set; }
		public DateTime OrderDate { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public bool IsSuccess { get; set; }
	}
}
