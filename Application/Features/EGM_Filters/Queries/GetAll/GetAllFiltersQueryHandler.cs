using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Queries.GetAll
{
	/// <summary>
	/// Обработчик запроса для получения всех фильтров.
	/// </summary>
	public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, Response<GetAllFiltersViewModel>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="GetAllFiltersQueryHandler"/>.
		/// </summary>
		/// <param name="repository">Репозиторий для работы с фильтрами.</param>
		/// <param name="mapper">Объект для маппинга данных.</param>
		public GetAllFiltersQueryHandler (IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		/// <summary>
		/// Обрабатывает запрос на получение всех фильтров.
		/// </summary>
		/// <param name="request">Запрос на получение фильтров.</param>
		/// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
		/// <returns>Ответ с моделью представления всех фильтров.</returns>
		/// <exception cref="DataException">Выбрасывается, если фильтры не найдены.</exception>
		public async Task<Response<GetAllFiltersViewModel>> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var filters = await _repository.GetAllAsync();
				if (filters.Item2 == 0) throw new DataException($"Filters Not Found.");

				var filterDtos = new GetAllFiltersViewModel
				{
					Filters = filters.Item1
					.AsQueryable()
					.ProjectTo<FilterLookupDto>(_mapper.ConfigurationProvider)
					.ToList()
				};

				return new Response<GetAllFiltersViewModel>(filterDtos, true, filters.Item2);
			}
			catch (Exception ex)
			{
				return new Response<GetAllFiltersViewModel>(ex.Message);
			}
		}
	}
}

