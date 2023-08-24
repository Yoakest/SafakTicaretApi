using MediatR;

namespace SafakTicaret.Application.Features.Order.Commands.CreateOrder
{
	public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
	{
		public string Adress { get; set; }
		public string Description { get; set; }
	}
}
