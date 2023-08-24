using SafakTicaret.Application.ViewModels.Baskets;
using SafakTicaret.Domain.Entities;

namespace SafakTicaret.Application.Abstractions.Services
{
	public interface IBasketServices
	{
		public Task<List<BasketItem>> GetBasketItemsAsync();
		public Task AddItemToBasketAsync(VMBasket basketItem);
		public Task UpdateQuantityAsync(VMUpdateBasketItem basketItem);
		public Task RemoveBasketItemAsync(string basketItemId);
		public Basket? GetUserActiveBaseket { get; }
	}
}
