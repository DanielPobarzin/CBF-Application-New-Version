using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Update
{
	/// <summary>
	/// Обработчик запроса для обновления топлива.
	/// </summary>
	public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, Response<Fuel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="UpdateFuelCommandHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с данными о топливе.</param>
		/// /// <param name="mapper">Преобразование данных о топливе.</param>
		public UpdateFuelCommandHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Обрабатывает запрос на обновление топлива.
		/// </summary>
		/// <param name="command">Запрос на обновление о топливе.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с обновленными данными топлива.</returns>
		/// <exception cref="DataException">Выбрасывается, если топлива не найдено.</exception>
		public async Task<Response<Fuel>> Handle(UpdateFuelCommand command, CancellationToken cancellationToken)
		{
			var fuel = await _repository.GetByIdAsync(command.Id) ?? throw new DataException($"Fuel Not Found.");
			_mapper.Map(command, fuel);
			await _repository.UpdateAsync(fuel);
			return new Response<Fuel>(fuel, true);
		}
	}
}

