using Application.Wrappers;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Insert
{
	public class InsertFuelsCommand : IRequest<Response<int>>
	{
		public IEnumerable<Fuel> Fuels { get; set; }
	}
}
