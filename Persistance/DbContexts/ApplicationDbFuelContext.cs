using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.Resources;
using Persistence.Configurations.EntityTypeConfiguration;

namespace Persistence.DbContexts
{
	/// <summary>
	/// Контекст базы данных для управления топливами.
	/// </summary>
	public class ApplicationDbFuelContext : DbContext
	{
		/// <summary>
		/// Получает или устанавливает набор топлив.
		/// </summary>
		public DbSet<Fuel> Fuels { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ApplicationDbFuelContext"/> 
		/// с заданными параметрами конфигурации.
		/// </summary>
		/// <param name="options">Параметры конфигурации для контекста базы данных.</param>
		public ApplicationDbFuelContext(DbContextOptions<ApplicationDbFuelContext> options)
			: base(options) { }

		/// <summary>
		/// Конфигурирует модель, создавая ее на основе заданного строителя.
		/// </summary>
		/// <param name="builder">Строитель модели, используемый для настройки.</param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new FuelConfig());
			base.OnModelCreating(builder);
		}
	}
}