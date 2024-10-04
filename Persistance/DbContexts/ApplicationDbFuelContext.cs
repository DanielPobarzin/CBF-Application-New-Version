using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.Resources;
using Persistance.Configurations.EntityTypeConfiguration;

namespace Persistance.DbContexts
{
	public class ApplicationDbFuelContext : DbContext
	{
		public DbSet<Fuel> Fuels { get; set; }
		public ApplicationDbFuelContext(DbContextOptions<ApplicationDbFuelContext> options)
			: base(options) { }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new FuelConfig());
			base.OnModelCreating(builder);
		}
	}
}
