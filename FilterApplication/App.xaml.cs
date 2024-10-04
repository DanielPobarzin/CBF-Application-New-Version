using Application;
using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using FilterApplication.View;
using MediatR;
using Ninject;
using Ninject.Modules;
using Persistance;
using Persistance.DbContexts;
using Persistance.Services;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using ViewModels.ViewModels;

namespace FilterApplication
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();
		public static IKernel Kernel { get; private set; }
		public App()
		{
				try
				{
					Kernel = new StandardKernel();
					Kernel.Load(new AppModule());
					Configure(Kernel);
				}
				catch (Exception ex)
				{
					Log.Fatal(ex, "An error occurred while app initialization");
					Log.CloseAndFlush();
					Current.Shutdown();
				}

		}

		private void Configure(IKernel kernel)
		{
			using (var scope = kernel.BeginBlock())
			{
				var dbFuelContext = scope.Get<ApplicationDbFuelContext>();
				dbFuelContext.Database.EnsureCreated();
				var dbFilterContext = scope.Get<ApplicationDbFilterContext>();
				dbFilterContext.Database.EnsureCreated();
			}
		}
		private void PreloadViews()
		{
			Log.Information("Initialization of all application windows...");
			Kernel.Get<IHomeView>();
			Kernel.Get<IFiltersView>().SetViewModel(Kernel.Get<IFilterViewModel>());
			Kernel.Get<IFuelsView>().SetViewModel(Kernel.Get<IFuelViewModel>());
			Kernel.Get<IStationView>().SetViewModel(Kernel.Get<IStationViewModel>());
			Kernel.Get<ICalculateView>().SetViewModel(Kernel.Get<ICalculateViewModel>());
			Kernel.Get<ICustomMessageBox>().SetViewModel(Kernel.Get<ICustomMessageBoxViewModel>());
			Kernel.Get<IChartsView>();

			Log.Information("All application windows have been initialized");
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			using (var loadingVisualize = new Resources.Helpers.SplashScreen("Загрузка..."))
			{
					loadingVisualize.SetSplashInitialized();
					
				try
				{
					Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.WriteTo.Console(theme: SystemConsoleTheme.Colored, restrictedToMinimumLevel: LogEventLevel.Debug)
					.CreateLogger();

					SQLitePCL.Batteries.Init();
#if DEBUG
					AllocConsole();
#endif
					PreloadViews();
					Log.Information("Start application...");
					Kernel.Get<MainWindow>().SetViewModel(Kernel.Get<INavigationViewModel>());
				}
				catch (Exception ex)
				{
					Log.Fatal(ex, "An error occured while app start");
				}
			}
			Kernel.Get<MainWindow>().Show();
			Log.Information("Application started");
			return;
		}
		protected override void OnExit(ExitEventArgs e)
		{
			Log.Information("Close application...");
			Log.CloseAndFlush();
			base.OnExit(e);
			Console.ReadLine();
		}
	}

	public class AppModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Load(new ApplicationModule());
			Kernel.Load(new PersistenceModule());

			Bind<ContentControl>().ToSelf().InSingletonScope();

			Bind<IHomeView>().To<Home>().InSingletonScope();
			Bind<IFiltersView>().To<Filter>().InSingletonScope();
			Bind<IFuelsView>().To<Fuel>().InSingletonScope();
			Bind<IStationView>().To<Station>().InSingletonScope();
			Bind<ICalculateView>().To<Calculate>().InSingletonScope();
			Bind<IChartsView>().To<Charts>().InSingletonScope();
			Bind<ICustomMessageBox>().To<CustomMessageBox>().InTransientScope();

			Bind<ICalculateService>().To<CalculateService>().InSingletonScope();
			Bind<ICommandService>().To<CommandService>().InSingletonScope();
			Bind<IServiceProvider>().ToMethod(ctx => ctx.Kernel.Get<IKernel>());
			
			Bind<IFilterViewModel>().To<FilterVM>().InSingletonScope();
			Bind<IFuelViewModel>().To<FuelVM>().InSingletonScope();
			Bind<IStationViewModel>().To<StationVM>().InSingletonScope();
			Bind<INavigationViewModel>().To<NavigationVM>().InSingletonScope();
			Bind<ICalculateViewModel>().To<CalculateVM>().InSingletonScope();
			Bind<ICustomMessageBoxViewModel>().To<CustomMessageBoxVM>().InTransientScope();

			Bind<IMediator>().To<Mediator>().InSingletonScope();
			Bind<MainWindow>().ToSelf().InSingletonScope();
		}
	}
}