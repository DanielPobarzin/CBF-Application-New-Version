using Models.Commands;
using Models.Entities.HeatPowerPlant.Resources;
using System.Collections.ObjectModel;

namespace Application.Interfaces.ViewModels
{
	public interface IFuelViewModel
    {
		RelayCommand GetAllCommand { get; }
		RelayCommand DeleteCommand { get; }
		RelayCommand UpdateCommand { get; }
		RelayCommand CreateCommand { get; }
		RelayCommand GeneralInsertCommand { get; }
		ObservableCollection<Fuel> Fuels { get;}
		ObservableCollection<Fuel> SelectedFuels { get; }
	}
}
