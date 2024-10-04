using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.Resources;

namespace Models.Interfaces.DbContexts
{
	public interface IFuelsDbContext
	{
		DbSet<Fuel> Fuels { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
	