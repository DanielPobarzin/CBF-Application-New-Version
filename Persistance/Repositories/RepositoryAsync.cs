using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
	/// <summary>
	/// Репозиторий для асинхронной работы с сущностями типа <typeparamref name="T"/> в контексте <typeparamref name="TContext"/>.
	/// </summary>
	/// <typeparam name="T">Тип сущности, с которой работает репозиторий.</typeparam>
	/// <typeparam name="TContext">Тип контекста базы данных, производный от <see cref="DbContext"/>.</typeparam>
	public class RepositoryAsync<T, TContext> : IRepositoryWithContextAsync<T, TContext>
		where T : class
		where TContext : DbContext
	{
		private readonly TContext _dbContext;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="RepositoryAsync{T, TContext}"/>.
		/// </summary>
		/// <param name="dbContext">Контекст базы данных для доступа к сущностям.</param>
		public RepositoryAsync(TContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// Получает сущность по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор искомой сущности.</param>
		/// <returns>Асинхронная задача, возвращающая сущность типа <typeparamref name="T"/>.</returns>
		public virtual async Task<T> GetByIdAsync(int id)
		{
			return (await _dbContext.Set<T>().FindAsync(id))!;
		}

		/// <summary>
		/// Добавляет новую сущность в базу данных.
		/// </summary>
		/// <param name="entity">Сущность, которую необходимо добавить.</param>
		/// <returns>Асинхронная задача, возвращающая добавленную сущность.</returns>
		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		/// <summary>
		/// Обновляет существующую сущность в базе данных.
		/// </summary>
		/// <param name="entity">Сущность, которую необходимо обновить.</param>
		/// <returns>Асинхронная задача.</returns>
		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		/// <summary>
		/// Удаляет сущность из базы данных.
		/// </summary>
		/// <param name="entity">Сущность, которую необходимо удалить.</param>
		/// <returns>Асинхронная задача.</returns>
		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		/// <summary>
		/// Получает все сущности из базы данных.
		/// </summary>
		/// <returns>Асинхронная задача, возвращающая кортеж из перечисления сущностей и их общего количества.</returns>
		public async Task<(IEnumerable<T>, int)> GetAllAsync()
		{
			var connections = await _dbContext.Set<T>().ToListAsync();
			return (connections, connections.Count);
		}

		/// <summary>
		/// Выполняет массовую вставку сущностей в базу данных.
		/// </summary>
		/// <param name="entities">Перечисление сущностей, которые необходимо добавить.</param>
		/// <returns>Асинхронная задача.</returns>
		public async Task GeneralInsertAsync(IEnumerable<T> entities)
		{
			foreach (T row in entities)
			{
				await AddAsync(row);
			}
		}

		/// <summary>
		/// Получает контекст базы данных.
		/// </summary>
		/// <returns>Контекст базы данных типа <typeparamref name="TContext"/>.</returns>
		public TContext GetDbContext()
		{
			return _dbContext;
		}
	}

}
