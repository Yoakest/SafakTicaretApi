using SafakTicaret.Domain.Entities.Common;

namespace SafakTicaret.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<bool> AddAsync(T model);
		Task<bool> AddListAsync(List<T> datas);

		Task<bool> Remove(string id);
		bool Remove(T model);
		bool RemoveList(List<T> datas);

		bool Update(T model);

		Task<int> SaveAsync();
	}
}
