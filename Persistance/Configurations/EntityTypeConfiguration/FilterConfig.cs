using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Persistence.Configurations.EntityTypeConfiguration
{
	/// <summary>
	/// Конфигурация сущности <see cref="Filter"/> для использования с Entity Framework.
	/// </summary>
	public class FilterConfig : IEntityTypeConfiguration<Filter>
	{
		/// <summary>
		/// Настраивает параметры сущности <see cref="Filter"/> в контексте базы данных.
		/// </summary>
		/// <param name="builder">Объект <see cref="EntityTypeBuilder{Filter}"/>, используемый для настройки сущности.</param>
		public void Configure(EntityTypeBuilder<Filter> builder)
		{
			builder.HasKey(filter => filter.Id);
			builder.HasIndex(filter => filter.Id).IsUnique();
			builder.Property(filter => filter.BrandFilter).HasMaxLength(250);
			builder.Property(filter => filter.CoefficientShakingMode).HasColumnName("СoefficientShakingMode");
			builder.Ignore(filter => filter.Error);
		}
	}
}
