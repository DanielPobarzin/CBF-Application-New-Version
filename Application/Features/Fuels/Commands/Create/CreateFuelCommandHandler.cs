using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Create
{
	public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, Response<Fuel>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		private readonly IMapper _mapper;

		public CreateFuelCommandHandler(IRepositoryAsync<Fuel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<Response<Fuel>> Handle(CreateFuelCommand command, CancellationToken cancellationToken)
		{
			var fuel = await _repository.GetByIdAsync(command.ID);
			if (fuel != null) throw new DataException($"Fuel has already been added.");
			await _repository.AddAsync(_mapper.Map<Fuel>(command));
			return new Response<Fuel>(_mapper.Map<Fuel>(command), true);
		}
	}
}
