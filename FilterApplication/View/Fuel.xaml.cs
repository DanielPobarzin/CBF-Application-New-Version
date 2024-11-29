using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using Persistence.Configurations.TelerikConfiguration;
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
	public partial class Fuel : IFuelsView
	{
		private IFuelViewModel _viewModel;
		public Representation View => Representation.Fuels;
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
		
			foreach (var fuel in RadComboBox.SelectedItems.Cast<Models.Entities.HeatPowerPlant.Resources.Fuel>())
			{
				_viewModel.SelectedFuels.Add(fuel);
			}
		}
		private void fuelsGrid_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Delete ||
			    FuelsGrid.SelectedItem is not Models.Entities.HeatPowerPlant.Resources.Fuel ) return;
			var result = MessageBox.Show("Вы уверены, что хотите удалить эту строку?",
				"Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
			FuelsGrid.CanUserDeleteRows = result != MessageBoxResult.No;
		}
	}
}
