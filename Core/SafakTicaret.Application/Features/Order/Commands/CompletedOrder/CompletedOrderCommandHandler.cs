using MediatR;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.DTOs.Order.CompletedOrderMail;

namespace SafakTicaret.Application.Features.Order.Commands.CompletedOrder
{
	internal class CompletedOrderCommandHandler : IRequestHandler<CompletedOrderCommandRequest, CompletedOrderCommandResponse>
	{
		private IOrderService _orderService;
		private IMailService _mailService;

		public CompletedOrderCommandHandler(IOrderService orderService, IMailService mailService)
		{
			_orderService = orderService;
			_mailService = mailService;
		}

		public async Task<CompletedOrderCommandResponse> Handle(CompletedOrderCommandRequest request, CancellationToken cancellationToken)
		{
			CompletedOrderMail result = await _orderService.CompleteOrderAsync(request.Id);
			if (result != null)
			{
				await _mailService.SendCompletedOrderMailAsync(result.Email, result.UserName, result.OrderCode, result.OrderDate);
			}
			return new CompletedOrderCommandResponse();
		}
	}
}
