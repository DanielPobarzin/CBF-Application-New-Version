using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using AutoMapper;
using Models.Commands;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Serilog;
using System.Collections.ObjectModel;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	/// <summary>
	/// Представляет модель представления для управления фильтрами.
	/// </summary>
	public class FilterVm : ViewModelBase, IFilterViewModel
	{
		private readonly ICrudService<Filter> _crudService;
		private readonly ICurrentParameterDto _parameters;
		private readonly IMapper _mapper;
		private readonly Lazy<RelayCommand> _selectCommand;
		private ObservableCollection<Filter> models;
		private Filter selectedFilter;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FilterVm"/>.
		/// </summary>
		/// <param name="crudService">Сервис для выполнения операций CRUD с фильтрами.</param>
		/// <param name="mapper">Объект для маппинга данных.</param>
		/// <param name="parameters">Текущие параметры, связанные с фильтрами.</param>
		public FilterVm(ICrudService<Filter> crudService, IMapper mapper, ICurrentParameterDto parameters)
		{
			_parameters = parameters;
			_mapper = mapper;
			_crudService = crudService;
			_crudService.EntitiesLoaded += OnFiltersLoaded;
			GetAllCommand.Execute(this);
			_selectCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await SelectFilterAsync(parameter)));
			models = new ObservableCollection<Filter>();
			selectedFilter = new Filter();
		}

		/// <summary>
		/// Получает или задает коллекцию фильтров.
		/// </summary>
		public ObservableCollection<Filter> Filters
		{
			get => models;
			set
			{
				if (models == value) return;
				models = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Получает или задает выбранный фильтр.
		/// </summary>
		public Filter SelectedFilter
		{
			get => selectedFilter;
			set
			{
				if (selectedFilter == value) return;
				_parameters.SelectedFilter = value;
				selectedFilter = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Получает команду для выбора фильтра.
		/// </summary>
		public RelayCommand SelectCommand => _selectCommand.Value;

		/// <summary>
		/// Получает команду для получения всех фильтров.
		/// </summary>
		public RelayCommand GetAllCommand => _crudService.GetAllCommand;

		/// <summary>
		/// Получает команду для удаления выбранного фильтра.
		/// </summary>
		public RelayCommand DeleteCommand => _crudService.DeleteCommand;

		/// <summary>
		/// Получает команду для обновления выбранного фильтра.
		/// </summary>
		public RelayCommand UpdateCommand => _crudService.UpdateCommand;

		/// <summary>
		/// Получает команду для создания нового фильтра.
		/// </summary>
		public RelayCommand CreateCommand => _crudService.CreateCommand;

		/// <summary>
		/// Получает команду для общего вставки данных.
		/// </summary>
		public RelayCommand GeneralInsertCommand => _crudService.GeneralInsertCommand;

		private async void OnFiltersLoaded(List<Filter> filters)
		{
			await HandleFiltersLoadedAsync(filters).ConfigureAwait(false);
		}
		private async Task HandleFiltersLoadedAsync(IEnumerable<Filter> filters)
		{
			Filters.Clear();
			var filtersList = await Task.Run(() =>
			{
				var list = filters.ToList();
				list.Sort((f1, f2) => f1.Id.CompareTo(f2.Id));
				return list;
			});
			foreach (var filter in filtersList)
			{
				Filters.Add(_mapper.Map<Filter>(filter));
			}
			Log.Information("Filter type data has been uploaded");
		}
		private Task SelectFilterAsync(object filterName)
		{
			if (filterName is not string brandFilter) return Task.CompletedTask;
			var selectFilter = Filters.FirstOrDefault(e => e.BrandFilter == brandFilter);
			if (selectFilter != null)
				SelectedFilter = selectFilter;
			return Task.CompletedTask;
		}
	}
}

