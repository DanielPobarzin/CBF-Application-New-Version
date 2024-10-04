using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Delete
{
	public class DeleteFilterCommandHandler : IRequestHandler<DeleteFilterCommand, Response<int>>
	{
		private readonly IRepositoryAsync<Filter> _repository;
		public DeleteFilterCommandHandler(IRepositoryAsync<Filter> repository)
		{
			_repository = repository;
		}
		public async Task<Response<int>> Handle(DeleteFilterCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var filter = await _repository.GetByIdAsync(command.ID) ?? throw new DataException($"Filter Not Found.");
				await _repository.DeleteAsync(filter);
				return new Response<int>(filter.ID, true);
			}
			catch (Exception ex)
			{
				return new Response<int>(ex.Message);
			}


		}
	}
}
