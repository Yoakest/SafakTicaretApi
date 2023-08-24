namespace SafakTicaret.Application.Features.Order.Queries.GetOrderById
{
	public class GetOrderByIdQueryResponse
	{
		public string Id { get; set; }
		public string Adress { get; set; }
		public object BasketItems { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Description { get; set; }
		public string OrderCode { get; set; }
		public bool Completed { get; set; }
	}
}
