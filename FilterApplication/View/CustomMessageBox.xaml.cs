using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.Message;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для CustomMessageBox.xaml
	/// </summary>
	public partial class CustomMessageBox : Window, ICustomMessageBox
    {
		private ICustomMessageBoxViewModel _viewModel;
		public CustomMessageBox()
        {
            InitializeComponent();
        }
		public void SetViewModel(ICustomMessageBoxViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
		private void MovingWin(object sender, RoutedEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				this.DragMove();
			}
		}
		public void ShowMessageDialog(Message typeOfMessage, string message, string title)
		{
			switch (typeOfMessage)
			{
				case Models.Enums.Message.Message.Dialog:
					Icon.Source = new BitmapImage(new Uri("/Resources/Images/icon_warning.png"));
					Ok.Visibility = Visibility.Visible;
					Cancel.Visibility = Visibility.Visible;
					break;
				case Models.Enums.Message.Message.Warning:
					Icon.Source = new BitmapImage(new Uri("/Resources/Images/icon_warning.png"));
					Ok.Visibility = Visibility.Visible;
					Cancel.Visibility = Visibility.Collapsed;
					break;
				case Models.Enums.Message.Message.Information:
					Icon.Source = new BitmapImage(new Uri("/Resources/Images/icon_information.png"));
					Ok.Visibility = Visibility.Visible;
					Cancel.Visibility = Visibility.Collapsed;
					break;
				case Models.Enums.Message.Message.Error: 
					Icon.Source = new BitmapImage(new Uri("/Resources/Images/icon_error.png"));
					Ok.Visibility = Visibility.Visible;
					Cancel.Visibility = Visibility.Collapsed;
					break;
				default:
					MessageBoxDialog.Text = message;
					this.Title = title;
					break;
			}
			this.ShowDialog();
		}
	}
}
