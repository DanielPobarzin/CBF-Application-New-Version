using Application.Extensions;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;

namespace Application.Interfaces.ViewModels
{
	public interface ICalculateViewModel
    {
		RelayCommand CalculateCommand { get; }
		RelayCommand ExportToExcelCommand { get; }
		ConcurrentObservableCollection<DefinedFilterParameters> Results { get; }
	}
}
