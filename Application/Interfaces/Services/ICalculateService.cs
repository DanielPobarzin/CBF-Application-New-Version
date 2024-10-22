using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Interfaces.Services
{
	public interface ICalculateService
	{
		RelayCommand CalculateCommand { get; }
		ObservableCollection<DefinedFilterParameters> Results { get; set; }
		bool IsValidInputData { get; }
		event Action<ConcurrentBag<DefinedFilterParameters>> ResultsLoaded;
		event Action LogUpdated;
		string LogOutput { get; }
	}
}
