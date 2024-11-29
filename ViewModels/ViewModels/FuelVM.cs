using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using AutoMapper;
using Models.Commands;
using Models.Entities.HeatPowerPlant.Resources;
using Serilog;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	/// <summary>
	/// Представляет модель представления для управления топливом.
	/// </summary>
	public class FuelVm : ViewModelBase, IFuelViewModel
	{
		private readonly ICrudService<Fuel> _crudService;
		private readonly ICurrentParameterDto _parameters;
		private readonly IMapper _mapper;

		/// <summary>
		/// Коллекция всех видов топлива.
		/// </summary>
		public ObservableCollection<Fuel> Fuels { get; set; }

		/// <summary>
		/// Коллекция выбранных для расчета видов топлива.
		/// </summary>
		public ObservableCollection<Fuel> SelectedFuels { get; set; }
		
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FuelVm"/>.
		/// </summary>
		/// <param name="crudService">Сервис для выполнения операций CRUD с топливом.</param>
		/// <param name="mapper">Объект для маппинга данных.</param>
		/// <param name="parameters">Текущие параметры, связанные с топливом.</param>
		public FuelVm(ICrudService<Fuel> crudService, IMapper mapper, ICurrentParameterDto parameters)
		{
			_mapper = mapper;
			_parameters = parameters;
			_crudService = crudService;
			_crudService.EntitiesLoaded += OnFuelsLoaded;
			GetAllCommand.Execute(this);
			Fuels = new ObservableCollection<Fuel>();
			SelectedFuels = new ObservableCollection<Fuel>();
			SelectedFuels.CollectionChanged += OnSelectedFuelsChanged;
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

		private void OnSelectedFuelsChanged(object? sender, NotifyCollectionChangedEventArgs e)
			=> _parameters.SelectedFuels = SelectedFuels;

		private async void OnFuelsLoaded(List<Fuel> models)
		{
			await HandleFuelsLoadedAsync(models).ConfigureAwait(false);
		}

		private async Task HandleFuelsLoadedAsync(IEnumerable<Fuel> models)
		{
			Fuels.Clear();
			var fuelsList = await Task.Run(() =>
			{
				var list = models.ToList();
				list.Sort((f1, f2) => f1.Id.CompareTo(f2.Id));
				return list;
			});
			foreach (var fuel in fuelsList)
			{
				Fuels.Add(_mapper.Map<Fuel>(fuel));
			}
			Log.Information("Fuel type data has been uploaded");
		}
	}
}
