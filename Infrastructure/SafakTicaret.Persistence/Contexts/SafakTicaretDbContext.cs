using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SafakTicaret.Domain.Entities;
using SafakTicaret.Domain.Entities.Common;
using SafakTicaret.Domain.Entities.Identity;

namespace SafakTicaret.Persistence.Contexts
{
	public class SafakTicaretDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public SafakTicaretDbContext(DbContextOptions options) : base(options)
		{ }

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<UploadFile> UploadFiles { get; set; }
		public DbSet<UploadFileProductImage> UploadFileProductImages { get; set; }
		public DbSet<UploadFileInvoice> UploadFileInvoices { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }
		public DbSet<CompletedOrder> CompletedOrders { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Endpoint> Endpoints { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Order>()
				.HasKey(b => b.Id);

			builder.Entity<Order>()
				.HasIndex(o => o.OrderCode)
				.IsUnique();

			builder.Entity<Basket>()
				.HasOne(b => b.Order)
				.WithOne(o => o.Basket)
				.HasForeignKey<Order>(b => b.Id);

			builder.Entity<Order>()
				.HasOne(o => o.CompletedOrder)
				.WithOne(c => c.Order)
				.HasForeignKey<CompletedOrder>(c => c.OrderId);

			base.OnModelCreating(builder);
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			IEnumerable<EntityEntry<BaseEntity>> entities = ChangeTracker.Entries<BaseEntity>();
			DateTime now = DateTime.Now;

			foreach (var entity in entities)
			{
				switch (entity.State)
				{
					case EntityState.Added:
						entity.Entity.CreatedDate = now;
						break;
					case EntityState.Modified:
						entity.Entity.UpdatedDate = now;
						break;
					case EntityState.Deleted:
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

	}
}
