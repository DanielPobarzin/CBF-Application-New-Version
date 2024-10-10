using Application.Interfaces.Services;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;

namespace Persistance.Services
{
	public class ChartsBuilderService : IChartsBuilderService
    {
        private readonly ICalculateService _calculateService;
       public ChartsBuilderService (ICalculateService calculateService)
       {
            _calculateService = calculateService;
       }
        public ObservableCollection<Dictionary<string, Dictionary<double, double>>> DependencyDegreeAshConsumptionAirSuction { get; set; }
        public ObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;
    }
}
