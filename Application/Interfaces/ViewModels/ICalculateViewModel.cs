using Application.Extensions;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Application.Interfaces.ViewModels
{
	public interface ICalculateViewModel
	{
		RelayCommand CalculateCommand { get; }
		RelayCommand ExportToExcelCommand { get; }
		ObservableCollection<DefinedFilterParameters> Results { get; }
		bool IsValidInputData { get; }
		string LogOutput { get; }
	}
}
