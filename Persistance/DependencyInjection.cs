using System.Windows.Data;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utilities;
using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Ninject.Modules;
using Persistence.Behaviours;
using Persistence.DbContexts;
using Persistence.DTOs;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence;

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
		// Регистрация сервиса констант.
		Bind<IConstParameterService>().To<ConstParameterService>().InSingletonScope();

		// Регистрация служб взаимодействия с репозиториями данных в области видимости Transient.
		Bind<ICrudService<Fuel>>().To<FuelDataService>().InTransientScope();
		Bind<ICrudService<Filter>>().To<FilterDataService>().InTransientScope();

		// Регистрация службы экспорта данных в Excel в области видимости Transient.
		Bind<IExportService>().To<ExportService>().InTransientScope();

		// Регистрация службы расчета данных в области видимости Singleton.
		Bind<ICalculateService>().To<CalculateService>().InSingletonScope();

		// Регистрация службы основных команд навигации и состояния в области видимости Singleton.
		Bind<ICommandService>().To<CommandService>().InSingletonScope();

		// Привязывает контекст базы данных для фильтров с использованием SQLite в области видимости Transient.
		Bind<ApplicationDbFilterContext>().ToMethod(_ =>
			new ApplicationDbFilterContext(new DbContextOptionsBuilder<ApplicationDbFilterContext>()
				.UseSqlite("Data Source=DataFilters.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
				.Options)).InTransientScope();

		// Привязывает контекст базы данных для топлива с использованием SQLite в области видимости Transient.
		Bind<ApplicationDbFuelContext>().ToMethod(_ =>
			new ApplicationDbFuelContext(new DbContextOptionsBuilder<ApplicationDbFuelContext>()
				.UseSqlite("Data Source=DataFuels.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
				.Options)).InTransientScope();

		// Привязывает репозитории для асинхронной работы с сущностями в области видимости Transient.
		Bind(typeof(IRepositoryWithContextAsync<,>)).To(typeof(RepositoryAsync<,>)).InTransientScope();
		Bind(typeof(IRepositoryAsync<Fuel>)).To<FuelRepository>().InTransientScope();
		Bind(typeof(IRepositoryAsync<Filter>)).To<FilterRepository>().InTransientScope();

		// Привязывает объект передачи данных текущих параметров к его реализации в области видимости Singleton.
		Bind(typeof(ICurrentParameterDto)).To<CurrentParameterDto>().InSingletonScope();

		// Привязывает поведение анимации к его реализации в области видимости Thread.
		Bind(typeof(IAnimationBehaviour)).To<AnimationBehaviour>().InThreadScope();

		// Привязывает конвертер значений цвета к его реализации при внедрении в <see cref="CalculateService"/> в области видимости Singleton.
		Bind<IValueConverter>().To<RandomColorConverter>().WhenInjectedInto<CalculateService>().InSingletonScope();
	}
}