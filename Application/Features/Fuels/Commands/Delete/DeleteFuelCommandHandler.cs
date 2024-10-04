using Application.Exeptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Delete
{
	public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, Response<int>>
	{
		private readonly IRepositoryAsync<Fuel> _repository;
		public DeleteFuelCommandHandler(IRepositoryAsync<Fuel> repository)
		{
			_repository = repository;
		}
		public async Task<Response<int>> Handle(DeleteFuelCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var fuel = await _repository.GetByIdAsync(command.ID) ?? throw new DataException($"Fuel Not Found.");
				await _repository.DeleteAsync(fuel);
				return new Response<int>(fuel.ID, true);
			}
			catch (Exception ex) { 
				return new Response<int>(ex.Message);
			}
			

		}
	}
}
