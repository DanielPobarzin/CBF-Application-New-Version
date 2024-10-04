using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Ninject.Modules;
using Persistance.Behaviorus;
using Persistance.DbContexts;
using Persistance.DTOs;
using Persistance.Repositories;
using Persistance.Services;
using ViewModels.Services.Repositories;

namespace Persistance
{
	public class PersistenceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ICustomMessageBoxService>().To<CustomMessageBoxService>().InTransientScope();
			Bind<IConstParameterService>().To<ConstParameterService>().InSingletonScope();
			Bind<ICrudService<Fuel>>().To<FuelDataService>().InSingletonScope();
			Bind<ICrudService<Filter>>().To<FilterDataService>().InSingletonScope();

			Bind<ApplicationDbFilterContext>().ToMethod(ctx =>
				new ApplicationDbFilterContext(new DbContextOptionsBuilder<ApplicationDbFilterContext>()
					.UseSqlite("Data Source=DataFilters.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
					.Options)).InTransientScope();

			Bind<ApplicationDbFuelContext>().ToMethod(ctx =>
				new ApplicationDbFuelContext(new DbContextOptionsBuilder<ApplicationDbFuelContext>()
					.UseSqlite("Data Source=DataFuels.db",
					b => b.MigrationsAssembly(typeof(ApplicationDbFilterContext).Assembly.FullName))
					.Options)).InTransientScope();

			Bind(typeof(IRepositoryWithContextAsync<,>)).To(typeof(RepositoryAsync<,>)).InTransientScope();
			Bind(typeof(IRepositoryAsync<Fuel>)).To<FuelRepository>().InTransientScope();
			Bind(typeof(IRepositoryAsync<Filter>)).To<FilterRepository>().InTransientScope();

			Bind(typeof(ICurrentParameterDTO)).To<CurrentParameterDTO>().InSingletonScope();
			Bind(typeof(IAnimationBehaviour)).To<AnimationBehaviour>().InThreadScope();
		}
	}
}
