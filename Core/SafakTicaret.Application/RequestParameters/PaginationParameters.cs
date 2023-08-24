﻿namespace SafakTicaret.Application.RequestParameters
{
	public record PaginationParameters
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
