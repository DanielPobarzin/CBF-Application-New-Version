using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;
using System.Windows;

namespace Application.Features.Fuels.Queries.GetAll
{
	public class GetAllFuelsQueryHandler : IRequestHandler<GetAllFuelsQuery, Response<GetAllFuelsViewModel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;
		public GetAllFuelsQueryHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
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
					.ProjectTo<FuelLookupDTO>(_mapper.ConfigurationProvider)
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
