using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SafakTicaret.API.Extensions;
using SafakTicaret.API.Filter;
using SafakTicaret.Application;
using SafakTicaret.Application.Validators.Products;
using SafakTicaret.Infrastructure;
using SafakTicaret.Infrastructure.Filters;
using SafakTicaret.Infrastructure.Services.Storage.LocalStorage;
using SafakTicaret.Persistence;
using SafakTicaret.SignalR;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
// Add services to the container.
Logger log = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("logs/log.txt")
	.WriteTo.MSSqlServer(
	builder.Configuration.GetConnectionString("MSSql"),
	"logs"
	)
	.Enrich.FromLogContext()
	.CreateLogger();


builder.Host.UseSerilog(log);
builder.Services.AddCors(options =>
options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
));

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplictionServices();
builder.Services.AddSignalRServices();

builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage<AzureStorage>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer("Admin", option =>
	{
		option.TokenValidationParameters = new()
		{
			ValidateAudience = true,
			ValidateIssuer = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,

			ValidAudience = builder.Configuration["Token:Web"],
			ValidIssuer = builder.Configuration["Token:Api"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
			LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
			NameClaimType = ClaimTypes.Name //JWT üzerinden Name claim'ine karþýlýk gelen deðeri (Ýþlemi yapan kullanýcýnýn adý) Use.Identiy.Nmae property'sine atanýyor.
		};

	});


builder.Services.AddControllers(options =>
{
	options.Filters.Add<ValidationFilter>();
	options.Filters.Add<RolePermissionFilter>();
})
	.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
	.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.ConfigureExeptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
	var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
	LogContext.PushProperty("user_name", username);
	await next();
});


app.MapControllers();
app.MapHubs();

app.Run();