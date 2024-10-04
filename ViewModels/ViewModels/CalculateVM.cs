using Application.Extensions;
using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using ViewModels.Utilities;

namespace ViewModels.ViewModels
{
	public class CalculateVM : ViewModelBase, ICalculateViewModel
	{
		private readonly ICurrentParameterDTO _parameters;
		private readonly ICalculateService _calculateService;
		public CalculateVM(ICurrentParameterDTO parameters, ICalculateService calculateService) 
		{
			_parameters = parameters;
		}
		public RelayCommand CalculateCommand {  get; set; }
		public RelayCommand ExportToExcelCommand { get; set; }
		public ConcurrentObservableCollection<DefinedFilterParameters> Results { get; set; }
	}
}
