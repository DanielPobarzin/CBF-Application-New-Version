using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Commands;
using Ninject;
using Serilog;
using System.Windows.Controls;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	public class NavigationVM : ViewModelBase, INavigationViewModel
	{
		private readonly ICommandService _commandService;
		private readonly IKernel _serviceProvider;

		private readonly Lazy<RelayCommand> _homeCommand;
		private readonly Lazy<RelayCommand> _filtersCommand;
		private readonly Lazy<RelayCommand> _fuelsCommand;
		private readonly Lazy<RelayCommand> _stationsCommand;
		private readonly Lazy<RelayCommand> _calculateCommand;
		private readonly Lazy<RelayCommand> _chartsCommand;
		
		private object _currentView;
		public object Current
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnPropertyChanged(nameof(Current));
				
			}
		}
		public NavigationVM (IKernel serviceProvider, ICommandService commandService)
		{
			_serviceProvider = serviceProvider;
			_commandService = commandService;

			_homeCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToHomeAsync()));
			_filtersCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToFiltersAsync()));
			_fuelsCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToFuelsAsync()));
			_stationsCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToStationAsync()));
			_calculateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToCalculateAsync()));
			_chartsCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await NavigateToChartsAsync()));
			_currentView = _serviceProvider.Get<IHomeView>() as UserControl;
			CurrentPageChanged += UpdatePage;
		}
		public RelayCommand CloseNavigationMenuCommand => _commandService.CloseNavigationMenuCommand;
		public RelayCommand OpenNavigationMenuCommand => _commandService.OpenNavigationMenuCommand;
		public RelayCommand CloseCommand => _commandService.CloseCommand;
		public RelayCommand MaxCommand => _commandService.MaxCommand;
		public RelayCommand MoveWindowCommand => _commandService.MoveWindowCommand;
		public RelayCommand HomeCommand => _homeCommand.Value;
		public RelayCommand FiltersCommand => _filtersCommand.Value;
		public RelayCommand FuelsCommand => _fuelsCommand.Value;
		public RelayCommand StationsCommand => _stationsCommand.Value;
		public RelayCommand CalculateCommand => _calculateCommand.Value;
		public RelayCommand ChartsCommand => _chartsCommand.Value;

		private async Task NavigateToHomeAsync()
		{
			await NavigateToAsync<IHomeView>();
		}
		private async Task NavigateToFiltersAsync()
		{
			await NavigateToAsync<IFiltersView>();
		}
		private async Task NavigateToFuelsAsync()
		{
			await NavigateToAsync<IFuelsView>();
		}
		private async Task NavigateToStationAsync()
		{
			await NavigateToAsync<IStationView>();
		}
		private async Task NavigateToCalculateAsync()
		{
			await NavigateToAsync<ICalculateView>();
		}

		private async Task NavigateToChartsAsync()
		{
			await NavigateToAsync<IChartsView>();
		}

		public async Task NavigateToAsync<T>() where T : class
		{

			if (_serviceProvider.Get<T>() is not UserControl view)
			{
				Log.Error($"Could not get a representation for the {typeof(T).Name} type");
				throw new InvalidOperationException($"Could not get a representation for the {typeof(T).Name} type");
			}
			await System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				_currentView = view;
				CurrentPageChanged?.Invoke(this, EventArgs.Empty);
			}));

			await Task.CompletedTask.ConfigureAwait(false);
		}
		private event EventHandler CurrentPageChanged;
		private void UpdatePage(object? sender, EventArgs e)
		{
			System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				Current = _currentView;
			}));
		}
	}
}
