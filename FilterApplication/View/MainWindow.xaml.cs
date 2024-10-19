using Application.Interfaces.ViewModels;
using Application.Parameters;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FilterApplication
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
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
			Task.Run(() =>
			{
				if (e.ButtonState == MouseButtonState.Pressed)
				{
					var command = _viewModel.MoveWindowCommand;
					if (command.CanExecute(this))
					{
						Dispatcher.Invoke(() => command.Execute(this));
					}
				}
			});
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

				if (ResponsiveWindow.ActualWidth < 810 && _previousWidth >= 810)
				{
					Dispatcher.Invoke(() => _viewModel.CloseNavigationMenuCommand.Execute(parameters));
				}
				else if (ResponsiveWindow.ActualWidth >= 810 && _previousWidth < 810)
				{

					Dispatcher.Invoke(() => _viewModel.OpenNavigationMenuCommand.Execute(parameters));
				}

				_previousWidth = ResponsiveWindow.ActualWidth;
			});
		}
	}
}
