using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Interfaces.DbContexts
{
	public interface IFiltersDbContext 
	{
		DbSet<Filter> Filters { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
