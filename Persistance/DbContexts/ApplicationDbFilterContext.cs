using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Persistance.Configurations.EntityTypeConfiguration;

namespace Persistance.DbContexts
{
	public class ApplicationDbFilterContext : DbContext
	{
		public DbSet<Filter> Filters { get; set; }
		public ApplicationDbFilterContext(DbContextOptions<ApplicationDbFilterContext> options)
			: base(options) { }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new FilterConfig());
			base.OnModelCreating(builder);
		}
	}
}
