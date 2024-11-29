using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Interfaces.ViewModels;
using Application.Parameters;

namespace FilterApplication.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private INavigationViewModel _viewModel;
		private double _previousWidth;
		public MainWindow()
		{
			InitializeComponent();
		}
		public void SetViewModel(INavigationViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
		private void MovingWin(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState != MouseButtonState.Pressed) return;
			var command = _viewModel.MoveWindowCommand;
			if (command.CanExecute(this))
			{
				Dispatcher.Invoke(() => command.Execute(this));
			}
		}
		private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
		{
			Task.Run(() =>
			{
				var parameters = new NavigationMenuParameter
				{
					CloseMenu = MenuClose,
					OpenMenu = MenuOpen,
					Panel = NavigationGrid
				};

				switch (ResponsiveWindow.ActualWidth)
				{
					case < 810 when _previousWidth >= 810:
						Dispatcher.Invoke(() => _viewModel.CloseNavigationMenuCommand.Execute(parameters));
						break;
					case >= 810 when _previousWidth < 810:
						Dispatcher.Invoke(() => _viewModel.OpenNavigationMenuCommand.Execute(parameters));
						break;
				}

				_previousWidth = ResponsiveWindow.ActualWidth;
			});
		}
	}
}
