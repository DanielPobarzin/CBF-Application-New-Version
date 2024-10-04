using Application.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Station;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	public class StationVM : ViewModelBase, IStationViewModel
	{
		private readonly ICurrentParameterDTO _parameters;
		private readonly ICommandService _commands;
		private Station _currentPropertyStation;
		public Station CurrentPropertyStation
		{
			get { return _currentPropertyStation; }
			set
			{
				if (_currentPropertyStation != value)
				{
					_currentPropertyStation = value;
					OnPropertyChanged(nameof(CurrentPropertyStation));
				}
			}
		}
		public StationVM(ICommandService commands, ICurrentParameterDTO parameters)
		{
			_parameters = parameters;
			_commands = commands;
			CurrentPropertyStation = new();
		}
		public RelayCommand CloseFormDataCommand => _commands.CloseFormDataCommand;
		public RelayCommand OpenFormDataCommand => _commands.OpenFormDataCommand;
		public RelayCommand SavePropertyStationCommand => _commands.SavePropertyStationCommand;
		public List<string> SlagRemovalOptions =>
			Enum.GetValues(typeof(SlagRemoval)).Cast<SlagRemoval>()
				.Select(x => x.GetDescription())
				.ToList();
		public List<int> SmokePumpsOptions => new List<int> { 1, 2, 3 };
		public List<int> NumberGridsOptions => new List<int> { 1, 2 };
		public List<string> TypeFlueGasSupplyOptions => 
			Enum.GetValues(typeof(TypeFlueGasSupply)).Cast<TypeFlueGasSupply>()
				.Select(x => x.GetDescription())
				.ToList();
		public List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions => Enum.GetValues(typeof(SchemeBunkerPartitions)).Cast<SchemeBunkerPartitions>().ToList(); 

	}
}

//comboBoxSmokePumps.Items.AddRange(new object[] { 1, 2, 3 });
//comboBoxNumberGrids.Items.AddRange(new object[] { 1, 2 });