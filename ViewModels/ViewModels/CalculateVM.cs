using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Serilog;
using System.Collections.ObjectModel;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	public class CalculateVM : ViewModelBase, ICalculateViewModel
	{
		private readonly ICurrentParameterDTO _parameters;
		private readonly ICalculateService _calculateService;
		private readonly IExportService _exportService;

		public CalculateVM(ICurrentParameterDTO parameters, ICalculateService calculateService, IExportService exportService) 
		{
			_parameters = parameters;
			_calculateService = calculateService;
			_exportService = exportService;
			Results = new();
			_calculateService.ResultsLoaded += OnResultsLoaded;
		}
		public RelayCommand CalculateCommand => _calculateService.CalculateCommand;
		public RelayCommand ExportToExcelCommand => _exportService.ExportToExcelCommand;

		public ObservableCollection<DefinedFilterParameters> Results { get; private set; }

		private void OnResultsLoaded(IEnumerable<DefinedFilterParameters> passengers)
		{
			try
			{
				System.Windows.Application.Current.Dispatcher.Invoke(() =>
				{
					Results.Clear();
					foreach (var passenger in passengers)
					{
						Results.Add(passenger);
					}
				});
			}
			catch (Exception ex) {

				Log.Error(ex.Message);
			}
		
		}
	}
};