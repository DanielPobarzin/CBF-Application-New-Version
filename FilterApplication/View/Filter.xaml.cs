using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using Persistance.Configurations.TelerikConfiguration;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Filter.xaml
	/// </summary>
	public partial class Filter : UserControl, IFiltersView
	{
		private IFilterViewModel _viewModel;
		public Represantation View => Represantation.Filters;
		public Filter()
		{
			LocalizationManager.Manager = new CustomLocalizationManager();
			InitializeComponent();
		}
		public void SetViewModel(IFilterViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}

		private void ButtonComboBoxClick(object sender, System.Windows.RoutedEventArgs e)
		{
			if (ComboBoxFilter.Visibility == System.Windows.Visibility.Hidden)
				ComboBoxFilter.Visibility = System.Windows.Visibility.Visible;
			else
				ComboBoxFilter.Visibility = System.Windows.Visibility.Hidden;

		}
	}
}


