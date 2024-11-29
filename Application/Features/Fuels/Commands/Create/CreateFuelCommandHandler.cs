using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Create
{
	/// <summary>
	/// Обработчик запроса для создания топлива.
	/// </summary>
	public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, Response<Fuel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CreateFuelCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с данными о топливе.</param>
		/// <param name="mapper">Объект для преобразования данных.</param>
		public CreateFuelCommandHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Обрабатывает запрос на создание топлива.
		/// </summary>
		/// <param name="command">Запрос на добавление новых данных о топливе.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с моделью данных.</returns>
		/// <exception cref="DataException">Выбрасывается, если топливо найдено.</exception>
		public async Task<Response<Fuel>> Handle(CreateFuelCommand command, CancellationToken cancellationToken)
		{
			var fuel = await _repository.GetByIdAsync(command.Id);
			if (fuel != null) throw new DataException($"Fuel has already been added.");
			await _repository.AddAsync(_mapper.Map<Fuel>(command));
			return new Response<Fuel>(_mapper.Map<Fuel>(command), true);
		}
	}
}
