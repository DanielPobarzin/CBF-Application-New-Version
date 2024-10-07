using Application.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using System.Windows.Media;
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
		}
		public RelayCommand CalculateCommand => _calculateService.CalculateCommand;
		public RelayCommand ExportToExcelCommand => _exportService.ExportToExcelCommand;
		public ConcurrentObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;
	}
}
