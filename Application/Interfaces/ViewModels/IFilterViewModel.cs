using Models.Commands;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using System.Collections.ObjectModel;

namespace Application.Interfaces.ViewModels
{
	public interface IFilterViewModel
    {
		RelayCommand GetAllCommand { get; }
		RelayCommand DeleteCommand { get; }
		RelayCommand UpdateCommand { get; }
		RelayCommand CreateCommand { get; }
		RelayCommand SelectCommand { get; }
		RelayCommand GeneralInsertCommand { get; }
		ObservableCollection<Filter> Filters { get; }
		Filter SelectedFilter { get; set; }
	}
}
