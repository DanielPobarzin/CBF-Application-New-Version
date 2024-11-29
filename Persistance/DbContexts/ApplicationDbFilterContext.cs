using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Persistence.Configurations.EntityTypeConfiguration;

namespace Persistence.DbContexts
{
	/// <summary>
	/// Контекст базы данных для управления фильтрами.
	/// </summary>
	public class ApplicationDbFilterContext : DbContext
	{
		/// <summary>
		/// Получает или устанавливает набор фильтров.
		/// </summary>
		public DbSet<Filter> Filters { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ApplicationDbFilterContext"/> 
		/// с заданными параметрами конфигурации.
		/// </summary>
		/// <param name="options">Параметры конфигурации для контекста базы данных.</param>
		public ApplicationDbFilterContext(DbContextOptions<ApplicationDbFilterContext> options)
			: base(options) { }

		/// <summary>
		/// Конфигурирует модель, создавая ее на основе заданного строителя.
		/// </summary>
		/// <param name="builder">Строитель модели, используемый для настройки.</param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new FilterConfig());
			base.OnModelCreating(builder);
		}
	}
}
