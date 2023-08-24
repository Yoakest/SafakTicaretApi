using Microsoft.EntityFrameworkCore;
using SafakTicaret.Application.Repositories;
using SafakTicaret.Domain.Entities.Common;
using SafakTicaret.Persistence.Contexts;
using System.Linq.Expressions;

namespace SafakTicaret.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{

		private readonly SafakTicaretDbContext _context;
		public ReadRepository(SafakTicaretDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll(bool tracking = true)
		{
			IQueryable<T> query = Table.AsQueryable();
			if (!tracking)
			{
				query = query.AsNoTracking();
			}
			return query;
		}

		public async Task<T> GetByIdAsync(string id, bool tracking = true)
		{
			IQueryable<T> query = Table.AsQueryable();
			if (!tracking)
			{
				query = query.AsNoTracking();
			}
			return await query.FirstOrDefaultAsync(data => data.Id.Equals(Guid.Parse(id)));
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
		{
			IQueryable<T> query = Table.AsQueryable();
			if (!tracking)
			{
				query = Table.AsNoTracking();
			}
			return await query.FirstOrDefaultAsync(method);
		}


		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
		{
			IQueryable<T> query = Table.Where(method);
			if (!tracking)
			{
				query = Table.AsNoTracking();
			}
			return query;
		}
	}
}
