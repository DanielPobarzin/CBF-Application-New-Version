using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Delete
{
	/// <summary>
	/// Обработчик команды для удаления фильтра.
	/// </summary>
	public class DeleteFilterCommandHandler : IRequestHandler<DeleteFilterCommand, Response<int>>
	{
		private readonly IRepositoryAsync<Filter> _repository;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DeleteFilterCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с фильтрами.</param>
		public DeleteFilterCommandHandler(IRepositoryAsync<Filter> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Обрабатывает команду на удаление фильтра.
		/// </summary>
		/// <param name="command">Команда, содержащая идентификатор фильтра для удаления.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с идентификатором удаленного фильтра.</returns>
		/// <exception cref="DataException">Выбрасывается, если фильтр не найден.</exception>
		public async Task<Response<int>> Handle(DeleteFilterCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var filter = await _repository.GetByIdAsync(command.Id) ?? throw new DataException($"Filter Not Found.");
				await _repository.DeleteAsync(filter);
				return new Response<int>(filter.Id, true);
			}
			catch (Exception ex)
			{
				return new Response<int>(ex.Message);
			}
		}
	}
}
