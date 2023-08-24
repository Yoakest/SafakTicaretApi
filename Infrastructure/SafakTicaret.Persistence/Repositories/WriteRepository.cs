using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SafakTicaret.Application.Abstractions.Hubs;
using SafakTicaret.Application.Repositories;
using SafakTicaret.Domain.Entities.Common;
using SafakTicaret.Persistence.Contexts;

namespace SafakTicaret.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		readonly private SafakTicaretDbContext _context;
		readonly IProductHubService _productHubService;

		public WriteRepository(
			SafakTicaretDbContext context,
			IProductHubService productHubService
			)
		{
			_context = context;
			_productHubService = productHubService;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}
		public async Task<bool> AddListAsync(List<T> datas)
		{
			await Table.AddRangeAsync(datas);
			return true;
		}

		public bool Remove(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}
		public bool RemoveList(List<T> datas)
		{
			Table.RemoveRange(datas);
			return true;
		}
		public async Task<bool> Remove(string id)
		{
			T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
			return Remove(model);
		}

		public bool Update(T model)
		{
			EntityEntry<T> entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}

		public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


	}
}
