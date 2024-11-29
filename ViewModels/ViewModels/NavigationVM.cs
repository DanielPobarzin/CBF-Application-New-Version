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
	public class NavigationVm : ViewModelBase, INavigationViewModel
	{
		private readonly ICommandService _commandService;
		private readonly IKernel _serviceProvider;
		private object _currentView;

		/// <summary>
		/// Получает или задает текущее представление.
		/// </summary>
		public object CurrentView
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="NavigationVm"/>.
		/// </summary>
		/// <param name="serviceProvider">Сервис-провайдер для получения зависимостей.</param>
		/// <param name="commandService">Сервис команд для управления навигацией.</param>
		public NavigationVm(IKernel serviceProvider, ICommandService commandService)
		{
			_serviceProvider = serviceProvider;
			_commandService = commandService;

			HomeCommand = new RelayCommand(async _
				=> await NavigateToAsync<IHomeView>());
			FiltersCommand = new RelayCommand(async _ 
				=> await NavigateToAsync<IFiltersView>());
			FuelsCommand = new RelayCommand(async _ 
				=> await NavigateToAsync<IFuelsView>());
			StationsCommand = new RelayCommand(async _ 
				=> await NavigateToAsync<IStationView>());
			CalculateCommand = new RelayCommand(async _ 
				=> await NavigateToAsync<ICalculateView>());
			ChartsCommand = new RelayCommand(async _ 
				=> await NavigateToAsync<IChartsView>());
			_currentView = (_serviceProvider.Get<IHomeView>() as UserControl)!;
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
		public RelayCommand HomeCommand { get; }

		/// <summary>
		/// Получает команду для навигации к фильтрам.
		/// </summary>
		public RelayCommand FiltersCommand { get; }

		/// <summary>
		/// Получает команду для навигации к топливу.
		/// </summary>
		public RelayCommand FuelsCommand { get; }

		/// <summary>
		/// Получает команду для навигации к станциям.
		/// </summary>
		public RelayCommand StationsCommand { get; }

		/// <summary>
		/// Получает команду для навигации к расчетам.
		/// </summary>
		public RelayCommand CalculateCommand { get; }

		/// <summary>
		/// Получает команду для навигации к диаграммам.
		/// </summary>
		public RelayCommand ChartsCommand { get; }

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
				CurrentView = view;
			}));

			await Task.CompletedTask.ConfigureAwait(false);
		}
	}
}
