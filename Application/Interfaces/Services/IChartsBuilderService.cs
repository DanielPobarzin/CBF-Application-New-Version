using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;

namespace Application.Interfaces.Services
{
	public interface IChartsBuilderService
	{
		//ObservableCollection<Dictionary<string, Dictionary<double, double>>> DependencyDegreeAshConsumptionAirSuction { get; set; }
		ObservableCollection<DefinedFilterParameters> Results {  get; }
	}
}
