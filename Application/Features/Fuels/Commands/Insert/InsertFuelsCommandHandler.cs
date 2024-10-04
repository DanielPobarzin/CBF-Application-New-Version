using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Insert
{
	public class InsertFuelsCommandHandler : IRequestHandler<InsertFuelsCommand, Response<int>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;
		public InsertFuelsCommandHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<Response<int>> Handle(InsertFuelsCommand command, CancellationToken cancellationToken)
		{
			var actualEntities = new List<Fuel>(); 
			foreach (var fuel in command.Fuels)
			{
				var foundFuel = await _repository.GetByIdAsync(fuel.ID);
				if (foundFuel == null) 
				{
					actualEntities.Add(fuel);
				}
			}
			await _repository.GeneralInsertAsync(actualEntities);
			return new Response<int>(actualEntities.Count, true);
		}
	}
}
