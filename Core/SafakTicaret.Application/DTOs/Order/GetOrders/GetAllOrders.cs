namespace SafakTicaret.Application.DTOs.Order.GetOrders
{
	public class GetAllOrders
	{
		public string OrderId { get; set; }
		public string OrderCode { get; set; }
		public string UserName { get; set; }
		public float TotalPrice { get; set; }
		public bool Completed { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
