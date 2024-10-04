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
	public class FuelVM : ViewModelBase, IFuelViewModel
	{
		private readonly ICrudService<Fuel> _crudService;
		private readonly ICurrentParameterDTO _parameters;
		private readonly IMapper _mapper;
		private ObservableCollection<Fuel> fuels;
		private ObservableCollection<Fuel> selectedFuels;
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
		public ObservableCollection<Fuel> SelectedFuels
		{
			get {  return selectedFuels; }
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

		public FuelVM(ICrudService<Fuel> crudService, IMapper mapper, ICurrentParameterDTO parameters)
		{
			_parameters = parameters;
			_mapper = mapper;
			_crudService = crudService;
			_crudService.EntitiesLoaded += OnFuelsLoaded;
			GetAllCommand.Execute(this);
			Fuels = new();
			SelectedFuels = new();
		}

		public RelayCommand GetAllCommand => _crudService.GetAllCommand;
		public RelayCommand DeleteCommand => _crudService.DeleteCommand;
		public RelayCommand UpdateCommand => _crudService.UpdateCommand;
		public RelayCommand CreateCommand => _crudService.CreateCommand;
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
