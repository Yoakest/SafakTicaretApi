using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Repositories.BasketItemRepository;
using SafakTicaret.Application.Repositories.BasketRepository;
using SafakTicaret.Application.Repositories.OrderRepository;
using SafakTicaret.Application.ViewModels.Baskets;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Domain.Entities.Identity;
using System.Security.Claims;

namespace SafakTicaret.Persistence.Services
{
	public class BasketService : IBasketServices
	{
		readonly IHttpContextAccessor _contextAccessor;
		readonly UserManager<AppUser> _userManager;
		readonly IOrderReadRepository _orderReadRepository;
		readonly IBasketReadRepository _basketReadRepository;
		readonly IBasketWriteRepository _basketWriteRepository;
		readonly IBasketItemReadRepository _basketItemReadRepository;
		readonly IBasketItemWriteRepository _basketItemWriteRepository;

		public BasketService(
			IHttpContextAccessor contextAccessor,
			UserManager<AppUser> userManager,
			IOrderReadRepository orderReadRepository,
			IBasketReadRepository basketReadRepository,
			IBasketWriteRepository basketWriteRepository,
			IBasketItemReadRepository basketItemReadRepository,
			IBasketItemWriteRepository basketItemWriteRepository
			)
		{
			_contextAccessor = contextAccessor;
			_userManager = userManager;
			_orderReadRepository = orderReadRepository;
			_basketReadRepository = basketReadRepository;
			_basketWriteRepository = basketWriteRepository;
			_basketItemReadRepository = basketItemReadRepository;
			_basketItemWriteRepository = basketItemWriteRepository;

		}

		private async Task<Basket?> ContextUser()
		{


			var asd = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			string? username = _contextAccessor.HttpContext?.User.Identity?.Name;
			if (!string.IsNullOrEmpty(username))
			{
				AppUser? user = await _userManager.Users
					   .Include(u => u.Baskets)
					   .FirstOrDefaultAsync(u => u.UserName == username);

				var _basket = from basket in user.Baskets
							  join order in _orderReadRepository.Table
							  on basket.Id equals order.Id into basketOrder
							  from order in basketOrder.DefaultIfEmpty()
							  select new
							  {
								  Basket = basket,
								  Order = order
							  };

				Basket? targetBasket = null;
				if (_basket.Any(b => b.Order is null))
				{
					targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
				}
				else
				{
					targetBasket = new();
					user.Baskets.Add(targetBasket);
				}

				await _basketWriteRepository.SaveAsync();

				return targetBasket;
			}


			throw new Exception("Sunucuda beklenmeyen hata meydana geldi");
		}

		public async Task AddItemToBasketAsync(VMBasket basketItem)
		{
			Basket? basket = await ContextUser();
			if (basket != null)
			{//help
				BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));
				if (_basketItem != null)
				{
					_basketItem.Quantity++;
				}
				else
				{
					await _basketItemWriteRepository.AddAsync(new()
					{
						BasketId = basket.Id,
						ProductId = Guid.Parse(basketItem.ProductId),
						Quantity = basketItem.Quantity
					});

				}
				await _basketItemWriteRepository.SaveAsync();
			}
		}

		public async Task<List<BasketItem>> GetBasketItemsAsync()
		{
			Basket? basket = await ContextUser();
			if (basket != null)
			{
				Basket? result = await _basketReadRepository.Table
							.Include(b => b.BasketItems)
							.ThenInclude(bi => bi.Product)
							.FirstOrDefaultAsync(b => b.Id == basket.Id);

				if (result != null)
					return result.BasketItems.ToList();
			}

			throw new Exception("Basket boş ki");

		}

		public async Task RemoveBasketItemAsync(string basketItemId)
		{
			BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
			if (basketItem != null)
			{
				_basketItemWriteRepository.Remove(basketItem);
				await _basketItemWriteRepository.SaveAsync();
			}
		}

		public async Task UpdateQuantityAsync(VMUpdateBasketItem basketItem)
		{
			BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
			if (_basketItem != null)
			{
				_basketItem.Quantity = basketItem.Quantity;
				await _basketItemWriteRepository.SaveAsync();
			}
		}

		public Basket? GetUserActiveBaseket
		{
			get
			{
				Basket? basket = ContextUser().Result;
				return basket;
			}
		}
	}
}
