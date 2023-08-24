using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SafakTicaret.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplictionServices(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ServiceRegistration));
		}
	}
}
