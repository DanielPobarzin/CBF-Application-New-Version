using AutoMapper;
using Models.Entities.HeatPowerPlant.Resources;
using Persistance.DbContexts;
using ViewModels.Services.Repositories;

namespace Persistance.Repositories
{
	public class FuelRepository : RepositoryAsync<Fuel, ApplicationDbFuelContext>
	{
		private ApplicationDbFuelContext _context;
		private IMapper _mapper;
		public FuelRepository(ApplicationDbFuelContext context, IMapper mapper) : base(context)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
