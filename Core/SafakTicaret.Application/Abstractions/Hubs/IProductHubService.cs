﻿namespace SafakTicaret.Application.Abstractions.Hubs
{
	public interface IProductHubService
	{
		Task ProductAddedMessageAsync(string message);
	}
}
