namespace SafakTicaret.Application.Features.Order.Queries.GetOrders;
using O = SafakTicaret.Application.DTOs.Order.GetOrders;


public class GetAllOrdersQueryResponse
{
	public List<O.GetAllOrders> Orders { get; set; }
	public int TotalCount { get; set; }
}

