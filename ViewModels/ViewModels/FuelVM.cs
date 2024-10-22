using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using AutoMapper;
using Models.Commands;
using Models.Entities.HeatPowerPlant.Resources;
using Serilog;
using System.Collections.ObjectModel;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	/// <summary>
	/// Представляет модель представления для управления топливом.
	/// </summary>
	public class FuelVM : ViewModelBase, IFuelViewModel
	{
		private readonly ICrudService<Fuel> _crudService;
		private readonly ICurrentParameterDTO _parameters;
		private readonly IMapper _mapper;
		private ObservableCollection<Fuel> fuels;
		private ObservableCollection<Fuel> selectedFuels;

		/// <summary>
		/// Получает или задает коллекцию топлива.
		/// </summary>
		public ObservableCollection<Fuel> Fuels
		{
			get { return fuels; }
			set
			{
				if (fuels != value)
				{
					fuels = value;
					OnPropertyChanged(nameof(Fuels));
				}
			}
		}

		/// <summary>
		/// Получает или задает коллекцию выбранного топлива.
		/// </summary>
		public ObservableCollection<Fuel> SelectedFuels
		{
			get { return selectedFuels; }
			set
			{
				if (selectedFuels != value)
				{
					_parameters.SelectedFuels = value;
					selectedFuels = value;
					OnPropertyChanged(nameof(SelectedFuels));
				}
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FuelVM"/>.
		/// </summary>
		/// <param name="crudService">Сервис для выполнения операций CRUD с топливом.</param>
		/// <param name="mapper">Объект для маппинга данных.</param>
		/// <param name="parameters">Текущие параметры, связанные с топливом.</param>
		public FuelVM(ICrudService<Fuel> crudService, IMapper mapper, ICurrentParameterDTO parameters)
		{
			_parameters = parameters;
			_mapper = mapper;
			_crudService = crudService;
			_crudService.EntitiesLoaded += OnFuelsLoaded;
			GetAllCommand.Execute(this);
			fuels = new();
			SelectedFuels = new();
		}

		/// <summary>
		/// Получает команду для получения всех топлив.
		/// </summary>
		public RelayCommand GetAllCommand => _crudService.GetAllCommand;

		/// <summary>
		/// Получает команду для удаления выбранного топлива.
		/// </summary>
		public RelayCommand DeleteCommand => _crudService.DeleteCommand;

		/// <summary>
		/// Получает команду для обновления выбранного топлива.
		/// </summary>
		public RelayCommand UpdateCommand => _crudService.UpdateCommand;

		/// <summary>
		/// Получает команду для создания нового топлива.
		/// </summary>
		public RelayCommand CreateCommand => _crudService.CreateCommand;

		/// <summary>
		/// Получает команду для общего вставки данных.
		/// </summary>
		public RelayCommand GeneralInsertCommand => _crudService.GeneralInsertCommand;

		private async void OnFuelsLoaded(List<Fuel> fuels)
		{
			await HandleFuelsLoadedAsync(fuels).ConfigureAwait(false);
		}

		private async Task HandleFuelsLoadedAsync(IEnumerable<Fuel> fuels)
		{
			Fuels.Clear();
			var fuelsList = await Task.Run(() =>
			{
				var list = fuels.ToList();
				list.Sort((f1, f2) => f1.ID.CompareTo(f2.ID));
				return list;
			});
			foreach (var fuel in fuelsList)
			{
				Fuels.Add(_mapper.Map<Fuel>(fuel));
			}
			Log.Information($"Fuel type data has been uploaded");
		}
	}
}
