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
	/// <summary>
	/// Представляет модель представления для навигации между различными представлениями.
	/// </summary>
	public class NavigationVM : ViewModelBase, INavigationViewModel
	{
		private readonly ICommandService _commandService;
		private readonly IKernel _serviceProvider;

		private readonly RelayCommand _homeCommand;
		private readonly RelayCommand _filtersCommand;
		private readonly RelayCommand _fuelsCommand;
		private readonly RelayCommand _stationsCommand;
		private readonly RelayCommand _calculateCommand;
		private readonly RelayCommand _chartsCommand;

		private object _currentView;

		/// <summary>
		/// Получает или задает текущее представление.
		/// </summary>
		public object Current
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnPropertyChanged(nameof(Current));
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="NavigationVM"/>.
		/// </summary>
		/// <param name="serviceProvider">Сервис-провайдер для получения зависимостей.</param>
		/// <param name="commandService">Сервис команд для управления навигацией.</param>
		public NavigationVM(IKernel serviceProvider, ICommandService commandService)
		{
			_serviceProvider = serviceProvider;
			_commandService = commandService;

			_homeCommand = new RelayCommand(async (parameter) => await NavigateToAsync<IHomeView>());
			_filtersCommand = new RelayCommand(async (parameter) => await NavigateToAsync<IFiltersView>());
			_fuelsCommand = new RelayCommand(async (parameter) => await NavigateToAsync<IFuelsView>());
			_stationsCommand = new RelayCommand(async (parameter) => await NavigateToAsync<IStationView>());
			_calculateCommand = new RelayCommand(async (parameter) => await NavigateToAsync<ICalculateView>());
			_chartsCommand = new RelayCommand(async (parameter) => await NavigateToAsync<IChartsView>());
			_currentView = _serviceProvider.Get<IHomeView>() as UserControl;
			CurrentPageChanged += UpdatePage;
		}

		/// <summary>
		/// Получает команду для закрытия навигационного меню.
		/// </summary>
		public RelayCommand CloseNavigationMenuCommand => _commandService.CloseNavigationMenuCommand;

		/// <summary>
		/// Получает команду для открытия навигационного меню.
		/// </summary>
		public RelayCommand OpenNavigationMenuCommand => _commandService.OpenNavigationMenuCommand;

		/// <summary>
		/// Получает команду для закрытия окна.
		/// </summary>
		public RelayCommand CloseCommand => _commandService.CloseCommand;

		/// <summary>
		/// Получает команду для максимизации окна.
		/// </summary>
		public RelayCommand MaxCommand => _commandService.MaxCommand;

		/// <summary>
		/// Получает команду для перемещения окна.
		/// </summary>
		public RelayCommand MoveWindowCommand => _commandService.MoveWindowCommand;

		/// <summary>
		/// Получает команду для навигации на главную страницу.
		/// </summary>
		public RelayCommand HomeCommand => _homeCommand;

		/// <summary>
		/// Получает команду для навигации к фильтрам.
		/// </summary>
		public RelayCommand FiltersCommand => _filtersCommand;

		/// <summary>
		/// Получает команду для навигации к топливу.
		/// </summary>
		public RelayCommand FuelsCommand => _fuelsCommand;

		/// <summary>
		/// Получает команду для навигации к станциям.
		/// </summary>
		public RelayCommand StationsCommand => _stationsCommand;

		/// <summary>
		/// Получает команду для навигации к расчетам.
		/// </summary>
		public RelayCommand CalculateCommand => _calculateCommand;

		/// <summary>
		/// Получает команду для навигации к диаграммам.
		/// </summary>
		public RelayCommand ChartsCommand => _chartsCommand;

		/// <summary>
		/// Асинхронно выполняет навигацию к указанному представлению.
		/// </summary>
		/// <typeparam name="T">Тип представления, к которому нужно перейти.</typeparam>
		/// <returns>Задача, представляющая асинхронную операцию.</returns>
		/// <exception cref="InvalidOperationException">Выбрасывается, если не удается получить представление указанного типа.</exception>
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
