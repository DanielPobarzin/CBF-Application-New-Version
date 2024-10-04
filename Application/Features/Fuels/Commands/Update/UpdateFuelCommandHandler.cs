using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Update
{
	public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, Response<Fuel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;
		public UpdateFuelCommandHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<Response<Fuel>> Handle(UpdateFuelCommand command, CancellationToken cancellationToken)
		{
			var fuel = await _repository.GetByIdAsync(command.ID) ?? throw new DataException($"Fuel Not Found.");
			_mapper.Map(command, fuel);
			await _repository.UpdateAsync(fuel);
			return new Response<Fuel>(fuel, true);
		}
	}
}
