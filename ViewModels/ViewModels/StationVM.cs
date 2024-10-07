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
		private readonly Lazy<RelayCommand> _selectCommand;
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
			_selectCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await SelectSchemeBunkerPatritionsAsync(parameter)));
		}
		public RelayCommand SelectSchemeBunkerPatritionsCommand => _selectCommand.Value;
		public RelayCommand CloseFormDataCommand => _commands.CloseFormDataCommand;
		public RelayCommand OpenFormDataCommand => _commands.OpenFormDataCommand;
		public RelayCommand SavePropertyStationCommand => _commands.SavePropertyStationCommand;
		public Dictionary<string, SlagRemoval> SlagRemovalOptions =>
			   Enum.GetValues(typeof(SlagRemoval))
				   .Cast<SlagRemoval>()
				   .ToDictionary(x => x.GetDescription(), x => x);
		public List<int> SmokePumpsOptions => new List<int> { 1, 2, 3 };
		public List<int> NumberGridsOptions => new List<int> { 1, 2 };
		public List<string> TypeFlueGasSupplyOptions =>
			Enum.GetValues(typeof(TypeFlueGasSupply)).Cast<TypeFlueGasSupply>()
				.Select(x => x.GetDescription())
				.ToList();
		public List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions => Enum.GetValues(typeof(SchemeBunkerPartitions)).Cast<SchemeBunkerPartitions>().ToList();
		private async Task SelectSchemeBunkerPatritionsAsync(object parameter)
		{
			System.Windows.MessageBox.Show($"{SlagRemovalOptions["Твердое шлакоудаление"]}");
			if (parameter != null && parameter is SchemeBunkerPartitions scheme)
			{
				await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
				{
					_currentPropertyStation.SchemeBunkerPartitions = scheme;
				});
			}
		}
	}
}