using Application;
using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using FilterApplication.View;
using MediatR;
using Ninject;
using Ninject.Modules;
using Persistence.DbContexts;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using Persistence;
using ViewModels.ViewModels;

namespace FilterApplication
{
	/// <summary>
	/// Основной класс инициализации и запуска проекта 
	/// </summary>
	public partial class App
	{
		[DllImport("kernel32.dll")]

		// Открытие консоли для вывода логов (только для Debug)
		private static extern bool AllocConsole();

		/// <summary>
		/// Провайдер зарегистрированных сервисов и служб
		/// </summary>
		public static IKernel Kernel { get; private set; }

		/// <summary>
		/// Точка входа в программу
		/// </summary>
		/// <remarks>
		/// Инициализация провайдера сервисов и служб, подключение к БД
		/// </remarks>
		public App()
		{
			try
			{
				Kernel = new StandardKernel();
				Kernel.Load(new AppModule());
				ConfigureDbContext(Kernel);
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "An error occurred while app initialization");
				Log.CloseAndFlush();
				Current.Shutdown();
			}

		}

		/// <summary>
		/// Создание контекста базы данных
		/// </summary>
		private static void ConfigureDbContext(IKernel kernel)
		{
			using var scope = kernel.BeginBlock();
			var dbFuelContext = scope.Get<ApplicationDbFuelContext>();
			dbFuelContext.Database.EnsureCreated();
			var dbFilterContext = scope.Get<ApplicationDbFilterContext>();
			dbFilterContext.Database.EnsureCreated();
		}

		/// <summary>
		/// Инициализация и предзагрузка окон и страниц приложения
		/// </summary>
		private static void PreloadViews()
		{
			Log.Information("Initialization of all application windows...");
			Kernel.Get<IHomeView>();
			Kernel.Get<IFiltersView>().SetViewModel(Kernel.Get<IFilterViewModel>());
			Kernel.Get<IFuelsView>().SetViewModel(Kernel.Get<IFuelViewModel>());
			Kernel.Get<IStationView>().SetViewModel(Kernel.Get<IStationViewModel>());
			Kernel.Get<ICalculateView>().SetViewModel(Kernel.Get<ICalculateViewModel>());
			Kernel.Get<IChartsView>().SetViewModel(Kernel.Get<IChartViewModel>());
			Kernel.Get<MainWindow>().SetViewModel(Kernel.Get<INavigationViewModel>());

			Log.Information("All application windows have been initialized");
		}

		/// <summary>
		/// Запуск приложения
		/// </summary>
		protected override void OnStartup(StartupEventArgs e)
		{
			using var process = Process.GetCurrentProcess();
			process.PriorityBoostEnabled = true;
			process.PriorityClass = ProcessPriorityClass.RealTime;
			base.OnStartup(e);
			using (var loadingVisualize = new Resources.Helpers.SplashScreen("Загрузка..."))
			{
				loadingVisualize.SetSplashInitialized();

				try
				{
					Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.WriteTo.Console(theme: SystemConsoleTheme.Colored, restrictedToMinimumLevel: LogEventLevel.Information)
					.WriteTo.File(AppContext.BaseDirectory + @"\Log\[ERROR]_Application_logs.log",
						rollingInterval: RollingInterval.Day,
						rollOnFileSizeLimit: true,
						retainedFileCountLimit: 31,
						shared: true,
						restrictedToMinimumLevel: LogEventLevel.Error)
					.WriteTo.File(AppContext.BaseDirectory + @"\Log\[INFO]_Application_logs.log",
						rollingInterval: RollingInterval.Day,
						rollOnFileSizeLimit: true,
						retainedFileCountLimit: 31,
						shared: true,
						restrictedToMinimumLevel: LogEventLevel.Information)
					.CreateLogger();

					SQLitePCL.Batteries.Init();
#if DEBUG
					AllocConsole();
					PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.All;
#endif
					PreloadViews();
					Log.Information("Start application...");
				}
				catch (Exception ex)
				{
					Log.Fatal(ex, "An error occured while app start");
				}
			}
			Kernel.Get<MainWindow>().Show();
			Log.Information("Application started");
		}

		/// <summary>
		/// Выход из приложения (закрытие)
		/// </summary>
		protected override void OnExit(ExitEventArgs e)
		{
			Log.Information("Close application...");
			Log.CloseAndFlush();
			base.OnExit(e);
			Console.ReadLine();
		}
	}

	/// <summary>
	/// Модуль с регистрацией сервисов
	/// </summary>
	public class AppModule : NinjectModule
	{
		public override void Load()
		{
			// Загрузка модулей с сервисами внутренних слоев приложения
			_ = Kernel ?? throw new ApplicationException();
			Kernel.Load(new ApplicationModule());
			Kernel.Load(new PersistenceModule());

			// Интерпретация 
			Bind<IServiceProvider>().ToMethod(ctx => ctx.Kernel.Get<IKernel>());

			// Регистрация элемента окна, содержащего страницы
			Bind<ContentControl>().ToSelf().InSingletonScope();

			// Регистрация страниц и окна приложения
			Bind<IHomeView>().To<Home>().InSingletonScope();
			Bind<IFiltersView>().To<Filter>().InSingletonScope();
			Bind<IFuelsView>().To<Fuel>().InSingletonScope();
			Bind<IStationView>().To<Station>().InSingletonScope();
			Bind<ICalculateView>().To<Calculate>().InSingletonScope();
			Bind<IChartsView>().To<Charts>().InSingletonScope();
			Bind<MainWindow>().ToSelf().InSingletonScope();

			// Регистрация медиатора 
			Bind<IMediator>().To<Mediator>().InSingletonScope();

			// Регистрация посредников между моделями данных и их представлениями (страницами)
			Bind<IFilterViewModel>().To<FilterVm>().InSingletonScope();
			Bind<IFuelViewModel>().To<FuelVm>().InSingletonScope();
			Bind<IStationViewModel>().To<StationVm>().InSingletonScope();
			Bind<INavigationViewModel>().To<NavigationVm>().InSingletonScope();
			Bind<ICalculateViewModel>().To<CalculateVm>().InSingletonScope();
			Bind<IChartViewModel>().To<ChartVm>().InSingletonScope();
		}
	}
}