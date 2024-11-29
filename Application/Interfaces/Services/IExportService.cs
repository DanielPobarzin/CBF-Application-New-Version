using Models.Commands;

namespace Application.Interfaces.Services
{
	public interface IExportService
	{
		RelayCommand ExportToExcelCommand { get;}
	}
}
