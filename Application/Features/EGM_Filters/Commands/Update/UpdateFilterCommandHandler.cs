using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Update
{
	public class UpdateFilterCommandHandler : IRequestHandler<UpdateFilterCommand, Response<Filter>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		private readonly IMapper _mapper;
		public UpdateFilterCommandHandler(IRepositoryAsync<Filter> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<Response<Filter>> Handle(UpdateFilterCommand command, CancellationToken cancellationToken)
		{
			var filter = await _repository.GetByIdAsync(command.ID) ?? throw new DataException($"Filter Not Found.");
			_mapper.Map(command, filter);
			await _repository.UpdateAsync(filter);
			return new Response<Filter>(filter, true);
		}
	}
}
