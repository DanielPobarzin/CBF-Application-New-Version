using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utilities;
using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Ninject.Modules;
using Persistance.Behaviorus;
using Persistance.DbContexts;
using Persistance.DTOs;
using Persistance.Repositories;
using Persistance.Services;
using System.Windows.Data;
using ViewModels.Services.Repositories;

namespace Persistance
{
	/// <summary>
	/// Модуль зависимостей для настройки сервисов и репозиториев с использованием Ninject.
	/// </summary>
	public class PersistenceModule : NinjectModule
	{
		/// <summary>
		/// Загружает зависимости в контейнер Ninject.
		/// </summary>
		public override void Load()
		{

			/// <summary>
			/// Привязывает сервисы к их реализации в области видимости Singleton.
			/// </summary>
			Bind<IConstParameterService>().To<ConstParameterService>().InSingletonScope();
			Bind<ICrudService<Fuel>>().To<FuelDataService>().InSingletonScope();
			Bind<ICrudService<Filter>>().To<FilterDataService>().InSingletonScope();
			Bind<IExportService>().To<ExportService>().InSingletonScope();

			/// <summary>
			/// Привязывает контекст базы данных для фильтров с использованием SQLite в области видимости Transient.
			/// </summary>
			Bind<ApplicationDbFilterContext>().ToMethod(ctx =>
				new ApplicationDbFilterContext(new DbContextOptionsBuilder<ApplicationDbFilterContext>()
					.UseSqlite("Data Source=DataFilters.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
					.Options)).InTransientScope();

			/// <summary>
			/// Привязывает контекст базы данных для топлива с использованием SQLite в области видимости Transient.
			/// </summary>
			Bind<ApplicationDbFuelContext>().ToMethod(ctx =>
				new ApplicationDbFuelContext(new DbContextOptionsBuilder<ApplicationDbFuelContext>()
					.UseSqlite("Data Source=DataFuels.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
					.Options)).InTransientScope();

			/// <summary>
			/// Привязывает репозитории для асинхронной работы с сущностями в области видимости Transient.
			/// </summary>
			Bind(typeof(IRepositoryWithContextAsync<,>)).To(typeof(RepositoryAsync<,>)).InTransientScope();
			Bind(typeof(IRepositoryAsync<Fuel>)).To<FuelRepository>().InTransientScope();
			Bind(typeof(IRepositoryAsync<Filter>)).To<FilterRepository>().InTransientScope();

			/// <summary>
			/// Привязывает DTO текущих параметров к его реализации в области видимости Singleton.
			/// </summary>
			Bind(typeof(ICurrentParameterDTO)).To<CurrentParameterDTO>().InSingletonScope();

			/// <summary>
			/// Привязывает поведение анимации к его реализации в области видимости Singleton.
			/// </summary>
			Bind(typeof(IAnimationBehaviour)).To<AnimationBehaviour>().InSingletonScope();

			/// <summary>
			/// Привязывает конвертер значений к его реализации при внедрении в <see cref="CalculateService"/> в области видимости Singleton.
			/// </summary>
			Bind<IValueConverter>().To<RandomColorConverter>().WhenInjectedInto<CalculateService>().InSingletonScope();
		}
	}
}
