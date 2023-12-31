﻿using SafakTicaret.Domain.Entities.Common;
using SafakTicaret.Domain.Entities.Identity;

namespace SafakTicaret.Domain.Entities
{
	public class Basket : BaseEntity
	{
		public string UserId { get; set; }
		public AppUser User { get; set; }
		public Order Order { get; set; }
		public ICollection<BasketItem> BasketItems { get; set; }
	}
}
