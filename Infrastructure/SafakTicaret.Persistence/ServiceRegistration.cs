using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafakTicaret.Application.Abstractions.Services;
using SafakTicaret.Application.Repositories.BasketItemRepository;
using SafakTicaret.Application.Repositories.BasketRepository;
using SafakTicaret.Application.Repositories.CompletedOrder;
using SafakTicaret.Application.Repositories.CutomerRepository;
using SafakTicaret.Application.Repositories.EndpointRepository;
using SafakTicaret.Application.Repositories.MenuReadRepository;
using SafakTicaret.Application.Repositories.OrderRepository;
using SafakTicaret.Application.Repositories.ProductRepository;
using SafakTicaret.Application.Repositories.UploadFileInvoiceRepository;
using SafakTicaret.Application.Repositories.UploadFileProductImageRepository;
using SafakTicaret.Application.Repositories.UploadFileRepository;
using SafakTicaret.Domain.Entities.Identity;
using SafakTicaret.Persistence.Configurations;
using SafakTicaret.Persistence.Contexts;
using SafakTicaret.Persistence.Repositories;
using SafakTicaret.Persistence.Repositories.BasketConcrete;
using SafakTicaret.Persistence.Repositories.BasketItemConcrete;
using SafakTicaret.Persistence.Repositories.CompletedOrder;
using SafakTicaret.Persistence.Repositories.CustomerConcrete;
using SafakTicaret.Persistence.Repositories.EndpointConcrete;
using SafakTicaret.Persistence.Repositories.MenuConcrete;
using SafakTicaret.Persistence.Repositories.OrderConcrete;
using SafakTicaret.Persistence.Repositories.ProductConcrete;
using SafakTicaret.Persistence.Repositories.UploadFileConcrete;
using SafakTicaret.Persistence.Repositories.UploadFileInvoiceConcrete;
using SafakTicaret.Persistence.Repositories.UploadFileProductImageConcrete;
using SafakTicaret.Persistence.Services;

namespace SafakTicaret.Persistence
{
	public static class ServiceRegistration
	{

		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<SafakTicaretDbContext>(options => options.UseSqlServer(ConnectingConfiguration.ConnectionString));
			services.AddIdentity<AppUser, AppRole>(opt =>
			{
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequiredLength = 0;
				opt.Password.RequireNonAlphanumeric = false;
			})
			.AddEntityFrameworkStores<SafakTicaretDbContext>()
			.AddDefaultTokenProviders();


			services.AddScoped<IMenuReadRepository, MenuReadRepository>();
			services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
			services.AddScoped<IBasketReadRepository, BasketReadRepository>();
			services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
			services.AddScoped<IUploadFileReadRepository, UploadFileReadRepository>();
			services.AddScoped<IUploadFileWriteRepository, UploadFileWriteRepository>();
			services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
			services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
			services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
			services.AddScoped<IUploadFileInvoiceReadRepository, UploadFileInvoiceReadRepository>();
			services.AddScoped<IUploadFileInvoiceWriteRepository, UploadFileInvoiceWriteRepository>();
			services.AddScoped<IUploadFileProductImageReadRepository, UploadFileProductImageReadRepository>();
			services.AddScoped<IUploadFileProductImageWriteRepository, UploadFileProductImageWriteRepository>();



			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IBasketServices, BasketService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
		}
	}
}
