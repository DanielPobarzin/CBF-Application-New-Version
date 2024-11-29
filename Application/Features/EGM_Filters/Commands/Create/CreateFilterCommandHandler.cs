using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Create
{
	/// <summary>
	/// Обработчик команды для создания нового фильтра.
	/// </summary>
	public class CreateFilterCommandHandler : IRequestHandler<CreateFilterCommand, Response<Filter>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CreateFilterCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с фильтрами.</param>
		/// <param name="mapper">Объект для маппинга данных.</param>
		public CreateFilterCommandHandler(IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Обрабатывает команду на создание нового фильтра.
		/// </summary>
		/// <param name="command">Команда, содержащая данные для создания фильтра.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с созданным фильтром.</returns>
		/// <exception cref="DataException">Выбрасывается, если фильтр с заданным идентификатором уже существует.</exception>
		public async Task<Response<Filter>> Handle(CreateFilterCommand command, CancellationToken cancellationToken)
		{
			var filter = await _repository.GetByIdAsync(command.Id);
			if (filter != null) throw new DataException($"Filter has already been added.");

			await _repository.AddAsync(_mapper.Map<Filter>(command));
			return new Response<Filter>(_mapper.Map<Filter>(command), true);
		}
	}
}