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
using FluentValidation;
using MediatR;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Validators;
using Ninject.Modules;
using System.Reflection;

namespace Application
{
	/// <summary>
	/// Модуль приложения, который настраивает зависимости с помощью Ninject.
	/// </summary>
	public class ApplicationModule : NinjectModule
	{
		/// <summary>
		/// Загружает привязки зависимостей в контейнер Ninject.
		/// </summary>
		public override void Load()
		{
			// Привязка обработчиков запросов для работы с данными по топливам
			Bind<IRequestHandler<GetAllFuelsQuery, Response<GetAllFuelsViewModel>>>().To<GetAllFuelsQueryHandler>();
			Bind<IRequestHandler<CreateFuelCommand, Response<Fuel>>>().To<CreateFuelCommandHandler>();
			Bind<IRequestHandler<DeleteFuelCommand, Response<int>>>().To<DeleteFuelCommandHandler>();
			Bind<IRequestHandler<UpdateFuelCommand, Response<Fuel>>>().To<UpdateFuelCommandHandler>();

			// Привязка обработчиков запросов для работы с данными по фильтрам
			Bind<IRequestHandler<GetAllFiltersQuery, Response<GetAllFiltersViewModel>>>().To<GetAllFiltersQueryHandler>();
			Bind<IRequestHandler<CreateFilterCommand, Response<Filter>>>().To<CreateFilterCommandHandler>();
			Bind<IRequestHandler<DeleteFilterCommand, Response<int>>>().To<DeleteFilterCommandHandler>();
			Bind<IRequestHandler<UpdateFilterCommand, Response<Filter>>>().To<UpdateFilterCommandHandler>();

			// Привязка поведения конвейера для логирования
			Bind(typeof(IPipelineBehavior<,>)).To(typeof(LoggingBehaviour<,>)).InTransientScope();

			// Привязка маппера с конфигурацией из текущей сборки
			Bind<IMapper>().ToMethod(_ =>
			{
				var config = new MapperConfiguration(cfg =>
				{
					cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
				});
				return config.CreateMapper();
			}).InSingletonScope();

			// Привязка валидации
			Bind<IValidator<Filter>>().To<FilterValidator>().InTransientScope();
			Bind<IValidator<Fuel>>().To<FuelValidator>().InTransientScope();
			Bind<IValidator<Station>>().To<StationValidator>().InTransientScope();
			Bind<IValidator<DefinedFilterParameters>>().To<CalculateValidator>().InTransientScope();
		}
	}
}
