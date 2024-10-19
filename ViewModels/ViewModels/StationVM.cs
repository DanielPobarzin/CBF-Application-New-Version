using Application.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Station;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	/// <summary>
	/// Представляет модель представления для станции.
	/// </summary>
	public class StationVM : ViewModelBase, IStationViewModel
	{
		private readonly ICurrentParameterDTO _parameters;
		private readonly ICommandService _commands;
		private readonly Lazy<RelayCommand> _selectCommand;
		private Station _currentPropertyStation;

		/// <summary>
		/// Получает или задает текущую станцию.
		/// </summary>
		public Station CurrentPropertyStation
		{
			get { return _currentPropertyStation; }
			set
			{
				if (_currentPropertyStation != value)
				{
					_currentPropertyStation = value;
					_parameters.CurrentPropertyStation = _currentPropertyStation;
					OnPropertyChanged(nameof(CurrentPropertyStation));
				}
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="StationVM"/>.
		/// </summary>
		/// <param name="commands">Сервис команд для управления действиями.</param>
		/// <param name="parameters">Текущие параметры DTO.</param>
		public StationVM(ICommandService commands, ICurrentParameterDTO parameters)
		{
			_parameters = parameters;
			_commands = commands;
			CurrentPropertyStation = new();
			_selectCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await SelectSchemeBunkerPatritionsAsync(parameter)));
		}

		/// <summary>
		/// Получает команду для выбора схемы бункерных перегородок.
		/// </summary>
		public RelayCommand SelectSchemeBunkerPatritionsCommand => _selectCommand.Value;

		/// <summary>
		/// Получает команду для закрытия формы данных.
		/// </summary>
		public RelayCommand CloseFormDataCommand => _commands.CloseFormDataCommand;

		/// <summary>
		/// Получает команду для открытия формы данных.
		/// </summary>
		public RelayCommand OpenFormDataCommand => _commands.OpenFormDataCommand;

		/// <summary>
		/// Получает команду для сохранения текущей станции.
		/// </summary>
		public RelayCommand SavePropertyStationCommand => _commands.SavePropertyStationCommand;

		/// <summary>
		/// Получает доступные варианты удаления шлака.
		/// </summary>
		public Dictionary<string, SlagRemoval> SlagRemovalOptions =>
			Enum.GetValues(typeof(SlagRemoval))
				.Cast<SlagRemoval>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription()))
				.ToDictionary(x => x.GetDescription(), x => x);

		/// <summary>
		/// Получает доступные варианты насосов для дыма.
		/// </summary>
		public List<int> SmokePumpsOptions => new List<int> { 1, 2, 3 };

		/// <summary>
		/// Получает доступные варианты количества решеток.
		/// </summary>
		public List<int> NumberGridsOptions => new List<int> { 1, 2 };

		/// <summary>
		/// Получает доступные варианты типов подачи дымовых газов.
		/// </summary>
		public Dictionary<string, TypeFlueGasSupply> TypeFlueGasSupplyOptions =>
			Enum.GetValues(typeof(TypeFlueGasSupply))
				.Cast<TypeFlueGasSupply>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription()))
				.ToDictionary(x => x.GetDescription(), x => x);

		/// <summary>
		/// Получает доступные варианты схем бункерных перегородок.
		/// </summary>
		public List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions =>
			Enum.GetValues(typeof(SchemeBunkerPartitions))
				.Cast<SchemeBunkerPartitions>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription())).ToList();
		private async Task SelectSchemeBunkerPatritionsAsync(object parameter)
		{
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