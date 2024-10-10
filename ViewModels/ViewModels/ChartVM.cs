using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace ViewModels.ViewModels
{
	public class ChartVM : ViewModelBase, IChartViewModel
	{
		private readonly IChartsBuilderService _chartsBuilderService;
		private readonly ICalculateService _calculateService;
		public ChartVM(ICalculateService calculateService, IChartsBuilderService chartsBuilderService)
		{
			_calculateService = calculateService;
			_chartsBuilderService = chartsBuilderService;
		}
		public ObservableCollection<Dictionary<string, Dictionary<double, double>>> DependencyDegreeAshConsumptionAirSuction { get; set; }
		public ObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;
	}
}
