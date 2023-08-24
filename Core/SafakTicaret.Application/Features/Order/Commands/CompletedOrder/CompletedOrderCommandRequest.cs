using MediatR;

namespace SafakTicaret.Application.Features.Order.Commands.CompletedOrder
{
	public class CompletedOrderCommandRequest : IRequest<CompletedOrderCommandResponse>
	{
		public string Id { get; set; }
	}
}
