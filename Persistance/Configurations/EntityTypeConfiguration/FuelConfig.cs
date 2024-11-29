using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities.HeatPowerPlant.Resources;

namespace Persistence.Configurations.EntityTypeConfiguration
{
	/// <summary>
	/// Конфигурация сущности <see cref="Fuel"/> для использования с Entity Framework.
	/// </summary>
	public class FuelConfig : IEntityTypeConfiguration<Fuel>
	{
		/// <summary>
		/// Настраивает параметры сущности <see cref="Fuel"/> в контексте базы данных.
		/// </summary>
		/// <param name="builder">Объект <see cref="EntityTypeBuilder{Fuel}"/>, используемый для настройки сущности.</param>
		public void Configure(EntityTypeBuilder<Fuel> builder)
		{
			builder.HasKey(fuel => fuel.Id);
			builder.HasIndex(fuel => fuel.Id).IsUnique();
			builder.Property(fuel => fuel.BrandFuel).HasMaxLength(250);
			builder.Ignore(fuel => fuel.Error);
			builder.Ignore(fuel => fuel.TypeFuel);
		}
	}
}
	