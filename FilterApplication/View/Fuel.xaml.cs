using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using Persistance.Configurations.TelerikConfiguration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Fuel.xaml
	/// </summary>
	public partial class Fuel : UserControl, IFuelsView
	{
		private IFuelViewModel _viewModel;
		public Represantation View => Represantation.Fuels;
		public Fuel()
		{
			LocalizationManager.Manager = new CustomLocalizationManager();
			InitializeComponent();
		}
		public void SetViewModel(IFuelViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
		private void SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_viewModel.SelectedFuels.Clear();
			foreach (var fuel in radComboBox.SelectedItems.Cast<Models.Entities.HeatPowerPlant.Resources.Fuel>())
			{
				_viewModel.SelectedFuels.Add(fuel);
				MessageBox.Show(_viewModel.SelectedFuels.Count.ToString());
			}
		}
		private void fuelsGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			var selectedFuel = fuelsGrid.SelectedItem as Models.Entities.HeatPowerPlant.Resources.Fuel;
			if (e.Key == Key.Delete && selectedFuel != null)
			{
				MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту строку?",
					"Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.No)
				{
					fuelsGrid.CanUserDeleteRows = false;
				}
				else { fuelsGrid.CanUserDeleteRows = true; }

			}
		}
	}
}
