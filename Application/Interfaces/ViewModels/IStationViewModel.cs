using Models.Commands;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Station;

namespace Application.Interfaces.ViewModels
{
	public interface IStationViewModel
    {
		Station CurrentPropertyStation { get; }
		RelayCommand CloseFormDataCommand { get; }
		RelayCommand OpenFormDataCommand { get; }
		RelayCommand SavePropertyStationCommand { get; }
		RelayCommand SelectSchemeBunkerPatritionsCommand { get; }
		Dictionary<string, SlagRemoval> SlagRemovalOptions { get; }
		List<string> TypeFlueGasSupplyOptions { get; }
		List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions { get; }
		List<int> SmokePumpsOptions { get; }
		List<int> NumberGridsOptions { get; }
	}
}
