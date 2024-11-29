namespace Application.Interfaces.Repositories
{
	public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<(IEnumerable<T>, int)> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task GeneralInsertAsync (IEnumerable<T> entities);
	}
}
