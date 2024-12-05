using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using Persistence.Configurations.TelerikConfiguration;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Страница "Фильтры". Описывается основная логика взаимодействия
	/// </summary>
	public partial class Filter : IFiltersView
	{
		private IFilterViewModel _viewModel;
		public Representation View => Representation.Filters;
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

		private void ButtonComboBoxClick(object sender, RoutedEventArgs e)
		{
			ComboBoxFilter.Visibility = ComboBoxFilter.Visibility == 
			                            Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
		}

		private void filtersGrid_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Delete ||
			    FiltersGrid.SelectedItem is not Models.Entities.HeatPowerPlant.EGM_Filters.Filter)
				return;
			var result = MessageBox.Show("Вы уверены, что хотите удалить эту строку?",
				"Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
			FiltersGrid.CanUserDeleteRows = result != MessageBoxResult.No;
		}
	}
}


