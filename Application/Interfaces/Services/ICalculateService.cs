using Application.Extensions;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Interfaces.Services
{
	public interface ICalculateService
	{
		RelayCommand CalculateCommand { get; }
		ConcurrentObservableCollection<DefinedFilterParameters> Results { get; set; }
	}
}
