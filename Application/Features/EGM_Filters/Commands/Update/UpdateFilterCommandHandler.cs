using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Update
{
	/// <summary>
	/// Обработчик команды для обновления фильтра.
	/// </summary>
	public class UpdateFilterCommandHandler : IRequestHandler<UpdateFilterCommand, Response<Filter>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="UpdateFilterCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с фильтрами.</param>
		/// <param name="mapper">Объект для преобразования данных.</param>
		public UpdateFilterCommandHandler(IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Обрабатывает команду на обновление фильтра.
		/// </summary>
		/// <param name="command">Команда, содержащая данные для обновления фильтра.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с обновленным фильтром.</returns>
		/// <exception cref="DataException">Выбрасывается, если фильтр не найден.</exception>
		public async Task<Response<Filter>> Handle(UpdateFilterCommand command, CancellationToken cancellationToken)
		{
			var filter = await _repository.GetByIdAsync(command.Id) ?? throw new DataException($"Filter Not Found.");
			_mapper.Map(command, filter);
			await _repository.UpdateAsync(filter);
			return new Response<Filter>(filter, true);
		}
	}
}
