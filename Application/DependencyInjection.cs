using Application.Behaviours;
using Application.Features.EGM_Filters.Commands.Create;
using Application.Features.EGM_Filters.Commands.Delete;
using Application.Features.EGM_Filters.Commands.Update;
using Application.Features.EGM_Filters.Queries.GetAll;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetAll;
using Application.Mappings;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Ninject.Modules;
using System.Reflection;

namespace Application
{
	public class ApplicationModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRequestHandler<GetAllFuelsQuery, Response<GetAllFuelsViewModel>>>().To<GetAllFuelsQueryHandler>();
			Bind<IRequestHandler<CreateFuelCommand, Response<Fuel>>>().To<CreateFuelCommandHandler>();
			Bind<IRequestHandler<DeleteFuelCommand, Response<int>>>().To<DeleteFuelCommandHandler>();
			Bind<IRequestHandler<UpdateFuelCommand, Response<Fuel>>>().To<UpdateFuelCommandHandler>();

			Bind<IRequestHandler<GetAllFiltersQuery, Response<GetAllFiltersViewModel>>>().To<GetAllFiltersQueryHandler>();
			Bind<IRequestHandler<CreateFilterCommand, Response<Filter>>>().To<CreateFilterCommandHandler>();
			Bind<IRequestHandler<DeleteFilterCommand, Response<int>>>().To<DeleteFilterCommandHandler>();
			Bind<IRequestHandler<UpdateFilterCommand, Response<Filter>>>().To<UpdateFilterCommandHandler>();

			Bind(typeof(IPipelineBehavior<,>)).To(typeof(LoggingBehaviour<,>)).InTransientScope();
			Bind<IMapper>().ToMethod(ctx =>
			{
				var config = new MapperConfiguration(cfg =>
				{
					cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
				});
				return config.CreateMapper();
			}).InSingletonScope();
		}
	}
}
