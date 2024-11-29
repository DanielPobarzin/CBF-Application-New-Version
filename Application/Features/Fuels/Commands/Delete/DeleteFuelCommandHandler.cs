using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Delete
{
	/// <summary>
	/// Обработчик запроса для удаления топлива.
	/// </summary>
	public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, Response<int>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DeleteFuelCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с данными о топливе.</param>
		public DeleteFuelCommandHandler(IRepositoryAsync<Fuel> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Обрабатывает запрос на удаление топлива.
		/// </summary>
		/// <param name="command">Запрос на удаление данных о топливе.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с id удаленных данных топлива.</returns>
		/// <exception cref="DataException">Выбрасывается, если топлива не найдено.</exception>
		public async Task<Response<int>> Handle(DeleteFuelCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var fuel = await _repository.GetByIdAsync(command.Id) ?? throw new DataException($"Fuel Not Found.");
				await _repository.DeleteAsync(fuel);
				return new Response<int>(fuel.Id, true);
			}
			catch (Exception ex) { 
				return new Response<int>(ex.Message);
			}
		}
	}
}