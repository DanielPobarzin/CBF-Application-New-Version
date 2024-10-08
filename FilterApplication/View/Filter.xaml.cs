using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using Persistance.Configurations.TelerikConfiguration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton != null && radioButton.DataContext is Models.Entities.HeatPowerPlant.EGM_Filters.Filter filter)
			{
				_viewModel.SelectedFilter = filter;
			}
		}

		private void filtersGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			var selectedFilter = filtersGrid.SelectedItem as Models.Entities.HeatPowerPlant.EGM_Filters.Filter;
			if (e.Key == Key.Delete && selectedFilter != null)
			{
				MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту строку?",
					"Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.No)
				{
					filtersGrid.CanUserDeleteRows = false;
				}
				else { filtersGrid.CanUserDeleteRows = true; }

			}
		}
	}
}


