using Application.Interfaces.Services;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;

namespace Application.Interfaces.ViewModels
{
    public interface IChartViewModel
    {
		//ObservableCollection<Dictionary<string, Dictionary<double, double>>> DependencyDegreeAshConsumptionAirSuction { get; set; }
		ObservableCollection<DefinedFilterParameters> Results { get; }
	}
}
