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
	public class FilterVM : ViewModelBase, IFilterViewModel
	{
		private readonly ICrudService<Filter> _crudService;
		private readonly ICurrentParameterDTO _parameters;
		private readonly IMapper _mapper;
		private readonly Lazy<RelayCommand> _selectCommand;
		private ObservableCollection<Filter> filters;
		private Filter selectedFilter;
		public ObservableCollection<Filter> Filters
		{
			get { return filters; }
			set
			{
				if (filters != value)
				{
					filters = value;
					OnPropertyChanged(nameof(Filters));
				}
			}
		}
		public Filter SelectedFilter
		{
			get { return selectedFilter; }
			set
			{
				if (selectedFilter != value)
				{
					_parameters.SelectedFilter = value;
					selectedFilter = value;
					OnPropertyChanged(nameof(SelectedFilter));
				}
			}
		}
		public FilterVM(ICrudService<Filter> crudService, IMapper mapper, ICurrentParameterDTO parameters)
		{
			_parameters = parameters;
			_mapper = mapper;
			_crudService = crudService;
			_crudService.EntitiesLoaded += OnFiltersLoaded;
			GetAllCommand.Execute(this);
			_selectCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await SelectFilterAsync(parameter)));
			Filters = new();
			SelectedFilter = new();
		}
		public RelayCommand SelectCommand => _selectCommand.Value;
		public RelayCommand GetAllCommand => _crudService.GetAllCommand;
		public RelayCommand DeleteCommand => _crudService.DeleteCommand;
		public RelayCommand UpdateCommand => _crudService.UpdateCommand;
		public RelayCommand CreateCommand => _crudService.CreateCommand;
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
				list.Sort((f1, f2) => f1.ID.CompareTo(f2.ID));
				return list;
			});
			foreach (var filter in filtersList)
			{
				Filters.Add(_mapper.Map<Filter>(filter));
			}
			Log.Information($"Filter type data has been uploaded");
		}
		private async Task SelectFilterAsync(object filterName)
		{
			if (filterName is string brandFilter)
			{
				var selectFilter = Filters.FirstOrDefault(e => e.BrandFilter == brandFilter);
				if (selectFilter != null)
					SelectedFilter = selectFilter;
			}
		}
	}
}
