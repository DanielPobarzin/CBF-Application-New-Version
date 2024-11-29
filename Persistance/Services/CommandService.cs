using Application.Interfaces.Services;
using Application.Parameters;
using Models.Commands;
using System.Windows;
using System.Windows.Controls;

namespace Persistence.Services
{
	/// <summary>
	/// Служба команд, реализующая интерфейс <see cref="ICommandService"/>.
	/// Предоставляет команды для управления состоянием приложения и навигацией.
	/// </summary>
	public class CommandService : ICommandService
	{
		private readonly Lazy<RelayCommand> _closeCommand;
		private readonly Lazy<RelayCommand> _maxCommand;
		private readonly Lazy<RelayCommand> _moveWindowCommand;
		private readonly Lazy<RelayCommand> _closeNavigationMenuCommand;
		private readonly Lazy<RelayCommand> _openNavigationMenuCommand;
		private readonly Lazy<RelayCommand> _closeFromDataCommand;
		private readonly Lazy<RelayCommand> _openFormDataCommand;

		private readonly IAnimationBehaviour _animationBehaviour;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CommandService"/>.
		/// </summary>
		/// <param name="animation">Объект, реализующий интерфейс <see cref="IAnimationBehaviour"/> для анимации.</param>
		public CommandService(IAnimationBehaviour animation)
		{
			_animationBehaviour = animation;
			_closeCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await CloseAppAsync(parameter)));
			_maxCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await MaxAppAsync(parameter)));
			_moveWindowCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await OnMoveWindowAsync(parameter)));
			_closeNavigationMenuCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) =>
			{
				if (parameter is NavigationMenuParameter menuParameter)
				{
					await CloseNavigationMenuAsync(menuParameter.Panel, menuParameter.CloseMenu, menuParameter.OpenMenu);
				}
			}));
			_openNavigationMenuCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) =>
			{
				if (parameter is NavigationMenuParameter menuParameter)
				{
					await OpenNavigationAppAsync(menuParameter.Panel, menuParameter.CloseMenu, menuParameter.OpenMenu);
				}
			}));
			_closeFromDataCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) =>
			{
				if (parameter is NavigationMenuParameter formParameter)
				{
					await CloseFormDataAsync(formParameter.Panel, formParameter.CloseMenu, formParameter.OpenMenu);
				}
			}));
			_openFormDataCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) =>
			{
				if (parameter is NavigationMenuParameter formParameter)
				{
					await OpenFormDataAsync(formParameter.Panel, formParameter.CloseMenu, formParameter.OpenMenu);
				}
			}));
		}
		/// <summary>
		/// Получает команду для закрытия приложения.
		/// </summary>
		public RelayCommand CloseCommand => _closeCommand.Value;

		/// <summary>
		/// Получает команду для максимизации приложения.
		/// </summary>
		public RelayCommand MaxCommand => _maxCommand.Value;

		/// <summary>
		/// Получает команду для перемещения окна.
		/// </summary>
		public RelayCommand MoveWindowCommand => _moveWindowCommand.Value;

		/// <summary>
		/// Получает команду для закрытия навигационного меню.
		/// </summary>
		public RelayCommand CloseNavigationMenuCommand => _closeNavigationMenuCommand.Value;

		/// <summary>
		/// Получает команду для открытия навигационного меню.
		/// </summary>
		public RelayCommand OpenNavigationMenuCommand => _openNavigationMenuCommand.Value;

		/// <summary>
		/// Получает команду для закрытия формы данных.
		/// </summary>
		public RelayCommand CloseFormDataCommand => _closeFromDataCommand.Value;

		/// <summary>
		/// Получает команду для открытия формы данных.
		/// </summary>
		public RelayCommand OpenFormDataCommand => _openFormDataCommand.Value;

		private static async Task CloseAppAsync(object obj)
		{
			if (obj is Window win)
			{
				await win.Dispatcher.InvokeAsync(() => win.Close());
			}
		}
		private async Task CloseNavigationMenuAsync(Grid panel, Button closeMenu, Button openMenu)
		{
			await System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				closeMenu.Visibility = Visibility.Collapsed;
				openMenu.Visibility = Visibility.Visible;
			}));
			await _animationBehaviour.AnimatePropertyAsync(panel, "(FrameworkElement.Width)",
														   panel.ActualWidth, panel.MinWidth,
														   TimeSpan.FromSeconds(0.5));
		}
		private async Task CloseFormDataAsync(Grid panel, Button closeMenu, Button openMenu)
		{
			await System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				closeMenu.Visibility = Visibility.Collapsed;
				openMenu.Visibility = Visibility.Visible;
			}));
			await _animationBehaviour.AnimatePropertyAsync(panel, "(FrameworkElement.Height)",
														   panel.ActualHeight, panel.MinHeight,
														   TimeSpan.FromSeconds(0.6));
		}
		private async Task OpenFormDataAsync(Grid panel, Button closeMenu, Button openMenu)
		{
			await System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				openMenu.Visibility = Visibility.Collapsed;
				closeMenu.Visibility = Visibility.Visible;
			}));
			await _animationBehaviour.AnimatePropertyAsync(panel, "(FrameworkElement.Height)",
														   panel.ActualHeight, panel.MaxHeight,
														   TimeSpan.FromSeconds(0.6));
		}
		private async Task OpenNavigationAppAsync(Grid panel, Button closeMenu, Button openMenu)
		{
			await System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				openMenu.Visibility = Visibility.Collapsed;
				closeMenu.Visibility = Visibility.Visible;
			}));
			await _animationBehaviour.AnimatePropertyAsync(panel, "(FrameworkElement.Width)",
														   panel.ActualWidth, panel.MaxWidth,
														   TimeSpan.FromSeconds(0.5));
		}
		private static async Task MaxAppAsync(object obj)
		{
			if (obj is Window win)
			{
				await win.Dispatcher.InvokeAsync(() =>
				{
					win.WindowState = win.WindowState == WindowState.Normal ?
						WindowState.Maximized : WindowState.Normal;
				});

			}
		}
		private static async Task OnMoveWindowAsync(object parameter)
		{
			if (parameter is Window window)
			{
				await window.Dispatcher.InvokeAsync(() => window.DragMove());
			}
		}
	}
}
