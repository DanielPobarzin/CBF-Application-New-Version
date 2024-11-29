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
		RelayCommand SelectSchemeBunkerPartitionsCommand { get; }
		Dictionary<string, SlagRemoval> SlagRemovalOptions { get; }
		Dictionary<string, TypeFlueGasSupply> TypeFlueGasSupplyOptions { get; }
		List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions { get; }
		List<int> SmokePumpsOptions { get; }
		List<int> NumberGridsOptions { get; }
	}
}
