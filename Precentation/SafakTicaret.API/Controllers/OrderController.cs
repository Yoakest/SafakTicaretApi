using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Consts;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.Features.Order.Commands.CompletedOrder;
using SafakTicaret.Application.Features.Order.Commands.CreateOrder;
using SafakTicaret.Application.Features.Order.Queries.GetOrderById;
using SafakTicaret.Application.Features.Order.Queries.GetOrders;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]

	public class OrderController : Controller
	{
		readonly IMediator mediator;

		public OrderController(IMediator mediator)
		{
			this.mediator = mediator;
		}


		[HttpPost]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Writing, Definition = "Create Order")]
		public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest createOrderCommandRequest)
		{
			CreateOrderCommandResponse response = await mediator.Send(createOrderCommandRequest);
			return Ok(response);
		}

		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Orders")]
		public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
		{
			GetAllOrdersQueryResponse response = await mediator.Send(getAllOrdersQueryRequest);
			return Ok(response);
		}

		[HttpGet("{Id}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Reading, Definition = "Get Order By Id")]
		public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
		{
			GetOrderByIdQueryResponse response = await mediator.Send(getOrderByIdQueryRequest);
			return Ok(response);
		}

		[HttpGet("comleteorder/{Id}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Updating, Definition = "Complete Order")]
		public async Task<IActionResult> CompleteOrder([FromRoute] CompletedOrderCommandRequest completedOrderCommandRequest)
		{
			return Ok(await mediator.Send(completedOrderCommandRequest));
		}

	}
}
