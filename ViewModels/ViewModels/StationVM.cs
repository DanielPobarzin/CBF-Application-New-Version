using System.ComponentModel;
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
	public class StationVm : ViewModelBase, IStationViewModel
	{
		private readonly ICurrentParameterDto _parameters;
		private readonly ICommandService _commands;
		private readonly Lazy<RelayCommand> _selectCommand;

		/// <summary>
		/// Получает или задает текущие параметры электростанции.
		/// </summary>
		public Station CurrentPropertyStation { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="StationVm"/>.
		/// </summary>
		/// <param name="commands">Сервис команд для управления действиями.</param>
		/// <param name="parameters">Текущие параметры DTO.</param>
		public StationVm(ICommandService commands, ICurrentParameterDto parameters)
		{
			_parameters = parameters;
			_commands = commands;
			CurrentPropertyStation = new Station();
			CurrentPropertyStation.PropertyChanged += OnCurrentPropertyStationChanged;
			_selectCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await SelectSchemeBunkerPartitionsAsync(parameter)));
		}

		/// <summary>
		/// Получает команду для выбора схемы бункерных перегородок.
		/// </summary>
		public RelayCommand SelectSchemeBunkerPartitionsCommand => _selectCommand.Value;

		/// <summary>
		/// Получает команду для закрытия формы данных.
		/// </summary>
		public RelayCommand CloseFormDataCommand => _commands.CloseFormDataCommand;

		/// <summary>
		/// Получает команду для открытия формы данных.
		/// </summary>
		public RelayCommand OpenFormDataCommand => _commands.OpenFormDataCommand;

		/// <summary>
		/// Получает доступные варианты удаления шлака.
		/// </summary>
		public Dictionary<string, SlagRemoval> SlagRemovalOptions =>
			Enum.GetValues(typeof(SlagRemoval))
				.Cast<SlagRemoval>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription()))
				.ToDictionary(x => x.GetDescription()!, x => x);

		/// <summary>
		/// Получает доступные варианты дымососов.
		/// </summary>
		public List<int> SmokePumpsOptions => new() { 1, 2, 3 };

		/// <summary>
		/// Получает доступные варианты количества решеток.
		/// </summary>
		public List<int> NumberGridsOptions => new() { 1, 2 };

		/// <summary>
		/// Получает доступные варианты типов подачи дымовых газов.
		/// </summary>
		public Dictionary<string, TypeFlueGasSupply> TypeFlueGasSupplyOptions =>
			Enum.GetValues(typeof(TypeFlueGasSupply))
				.Cast<TypeFlueGasSupply>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription()))
				.ToDictionary(x => x.GetDescription()!, x => x);

		/// <summary>
		/// Получает доступные варианты схем бункерных перегородок.
		/// </summary>
		public List<SchemeBunkerPartitions> SchemeBunkerPartitionsOptions =>
			Enum.GetValues(typeof(SchemeBunkerPartitions))
				.Cast<SchemeBunkerPartitions>()
				.Where(x => !string.IsNullOrEmpty(x.GetDescription())).ToList();

		private void OnCurrentPropertyStationChanged(object? sender, PropertyChangedEventArgs e) =>
			_parameters.CurrentPropertyStation = CurrentPropertyStation;
		private async Task SelectSchemeBunkerPartitionsAsync(object? parameter)
		{
			if (parameter is SchemeBunkerPartitions scheme)
			{
				await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
				{
					CurrentPropertyStation.SchemeBunkerPartitions = scheme;
				});
			}
		}
	}
}