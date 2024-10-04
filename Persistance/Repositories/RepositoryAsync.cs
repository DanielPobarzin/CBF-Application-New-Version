using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ViewModels.Services.Repositories
{
	public class RepositoryAsync<T, TContext> : IRepositoryWithContextAsync<T, TContext>
	where T : class
	where TContext : DbContext
	{
		private readonly TContext _dbContext;
		public RepositoryAsync(TContext dbContext)
		{
			_dbContext = dbContext;
		}
		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}
		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
		public async Task<(IEnumerable<T>, int)> GetAllAsync()
		{
			var connections = await _dbContext
				 .Set<T>()
				 .ToListAsync();
			return (connections, connections.Count);
		}
		public async Task GeneralInsertAsync(IEnumerable<T> entities)
		{
			foreach (T row in entities)
			{
				await this.AddAsync(row);
			}
		}
		public TContext GetDbContext()
		{
			return _dbContext;
		}
	}
}
