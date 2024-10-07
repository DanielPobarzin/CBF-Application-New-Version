using Application.Extensions;
using Application.Parameters;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;

namespace Application.Interfaces.Services
{
	public interface IChartsBuilderService
	{
		RelayCommand BuildCommand { get; }
		RelayCommand DrawCommand { get; }
		ConcurrentObservableCollection<DefinedFilterParameters> Results { get; }
		double Step { get; }
		double MinValueRange { get; }
		double MaxValueRange { get; }
		ConcurrentObservableCollection<ChartWithVariousAirSuction> ResultsWithVariousAirSuction { get;}
	}
}

