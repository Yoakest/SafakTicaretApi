using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafakTicaret.Application.Consts;
using SafakTicaret.Application.CustomAttributes;
using SafakTicaret.Application.Features.Basket.Commands.AddBasketItem;
using SafakTicaret.Application.Features.Basket.Commands.RemoveBasketItem;
using SafakTicaret.Application.Features.Basket.Commands.UpdateBasketItem;
using SafakTicaret.Application.Features.Basket.Queries.GetBasketItems;

namespace SafakTicaret.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class BasketController : Controller
	{
		readonly IMediator _mediator;

		public BasketController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Reading, Definition = "Get Basket Items")]
		public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemQueryRequest getBasketItemQueryRequest)
		{
			List<GetBasketItemQueryResponse> response = await _mediator.Send(getBasketItemQueryRequest);
			return Ok(response);
		}


		[HttpPost]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Writing, Definition = "Add Item To Basket")]
		public async Task<IActionResult> AddBasketItem(AddBasketItemCommandRequest addBasketItemCommandRequest)
		{
			AddBasketItemCommandResponse result = await _mediator.Send(addBasketItemCommandRequest);
			return Ok(result);

		}

		[HttpPut]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Updating, Definition = "Update Basket Item")]
		public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemCommandRequest updateBasketItemCommandRequest)
		{
			UpdateBasketItemCommandResponse result = await _mediator.Send(updateBasketItemCommandRequest);
			return Ok(result);
		}

		[HttpDelete("{RemoveBasketItemId}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Deleting, Definition = "Remove Basket Item")]
		public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
		{
			RemoveBasketItemCommandResponse result = await _mediator.Send(removeBasketItemCommandRequest);
			return Ok(result);

		}
	}
}
