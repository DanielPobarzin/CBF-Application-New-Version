using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace Application.Interfaces.Services
{
	public interface ICalculateService
	{
		RelayCommand CalculateCommand { get; }
		ObservableCollection<DefinedFilterParameters> Results { get; set; }
		event Action<ConcurrentBag<DefinedFilterParameters>> ResultsLoaded;
	}
}
