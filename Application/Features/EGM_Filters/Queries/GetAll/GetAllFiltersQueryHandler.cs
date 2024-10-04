using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Queries.GetAll
{
	public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, Response<GetAllFiltersViewModel>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;
		public GetAllFiltersQueryHandler (IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
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
					.ProjectTo<FilterLookupDTO>(_mapper.ConfigurationProvider)
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