using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;
using System.Windows;

namespace Application.Features.Fuels.Queries.GetAll
{
	/// <summary>
	/// Обработчик запроса для получения всех видов топлива.
	/// </summary>
	public class GetAllFuelsQueryHandler : IRequestHandler<GetAllFuelsQuery, Response<GetAllFuelsViewModel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="GetAllFuelsQueryHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с данными о топливе.</param>
		/// <param name="mapper">Объект для преобразования данных.</param>
		public GetAllFuelsQueryHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Обрабатывает запрос на получение всех видов топлива.
		/// </summary>
		/// <param name="request">Запрос на получение данных о топливе.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с моделью данных о всех видах топлива.</returns>
		/// <exception cref="DataException">Выбрасывается, если топлива не найдено.</exception>
		public async Task<Response<GetAllFuelsViewModel>> Handle(GetAllFuelsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var fuels = await _repository.GetAllAsync();
				if (fuels.Item2 == 0) throw new DataException($"Fuels Not Found.");

				var fuelDtos = new GetAllFuelsViewModel
				{
					Fuels = fuels.Item1
					.AsQueryable()
					.ProjectTo<FuelLookupDto>(_mapper.ConfigurationProvider)
					.ToList()
				};

				return new Response<GetAllFuelsViewModel>(fuelDtos, true, fuels.Item2);
			}
			catch (Exception ex) 
			{
				MessageBox.Show($"{ex.Message}");
				return new Response<GetAllFuelsViewModel>(ex.Message);
			}
			
			
		}
	}
}
