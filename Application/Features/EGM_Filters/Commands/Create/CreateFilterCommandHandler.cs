using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Create
{
	public class CreateFilterCommandHandler : IRequestHandler<CreateFilterCommand, Response<Filter>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;
		public CreateFilterCommandHandler(IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<Response<Filter>> Handle(CreateFilterCommand command, CancellationToken cancellationToken)
		{
			var filter = await _repository.GetByIdAsync(command.ID);
			if (filter != null) throw new DataException($"Filter has already been added.");
			await _repository.AddAsync(_mapper.Map<Filter>(command));
			return new Response<Filter>(_mapper.Map<Filter>(command), true);
		}
	}
}