using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Application.Interfaces.Services
{
	public interface ICurrentParameterDto : INotifyPropertyChanged
	{
		Filter SelectedFilter { get; set; }
		ObservableCollection<Fuel> SelectedFuels { get; set; }
		Station CurrentPropertyStation { get; set; }
	}
}
