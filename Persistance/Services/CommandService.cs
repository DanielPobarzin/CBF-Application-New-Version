using Application.Interfaces.Services;
using Application.Parameters;
using Models.Commands;
using System.Windows;
using System.Windows.Controls;

namespace Persistance.Services
{
	public class CommandService : ICommandService
	{
		private readonly Lazy<RelayCommand> _closeCommand;
		private readonly Lazy<RelayCommand> _maxCommand;
		private readonly Lazy<RelayCommand> _moveWindowCommand;
		private readonly Lazy<RelayCommand> _closeNavigationMenuCommand;
		private readonly Lazy<RelayCommand> _openNavigationMenuCommand;
		private readonly Lazy<RelayCommand> _closeFromDataCommand;
		private readonly Lazy<RelayCommand> _openFormDataCommand;
		private readonly Lazy<RelayCommand> _savePropertyStationCommand;

		private readonly IAnimationBehaviour _animationBehaviour;

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
		public RelayCommand CloseCommand => _closeCommand.Value;
		public RelayCommand MaxCommand => _maxCommand.Value;
		public RelayCommand MoveWindowCommand => _moveWindowCommand.Value;
		public RelayCommand CloseNavigationMenuCommand => _closeNavigationMenuCommand.Value;
		public RelayCommand OpenNavigationMenuCommand => _openNavigationMenuCommand.Value;
		public RelayCommand CloseFormDataCommand => _closeFromDataCommand.Value;
		public RelayCommand OpenFormDataCommand => _openFormDataCommand.Value;
		public RelayCommand SavePropertyStationCommand => _savePropertyStationCommand.Value;
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
														   TimeSpan.FromSeconds(1));
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
														   TimeSpan.FromSeconds(1));
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
