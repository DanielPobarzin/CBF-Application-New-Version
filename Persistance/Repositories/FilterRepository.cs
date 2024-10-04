using AutoMapper;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Persistance.DbContexts;
using ViewModels.Services.Repositories;

namespace Persistance.Repositories
{
	public class FilterRepository : RepositoryAsync<Filter, ApplicationDbFilterContext>
	{
		private ApplicationDbFilterContext _context;
		private IMapper _mapper;
		public FilterRepository(ApplicationDbFilterContext context, IMapper mapper) : base(context)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
