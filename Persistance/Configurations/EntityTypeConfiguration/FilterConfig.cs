using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Persistance.Configurations.EntityTypeConfiguration
{
	public class FilterConfig : IEntityTypeConfiguration<Filter>
	{
		public void Configure(EntityTypeBuilder<Filter> builder)
		{
			builder.HasKey(filter => filter.ID);
			builder.HasIndex(filter => filter.ID).IsUnique();
			builder.Property(filter => filter.BrandFilter).HasMaxLength(250);
			builder.Ignore(filter => filter.Error);
		}
	}
}
