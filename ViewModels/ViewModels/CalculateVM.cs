using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Serilog;
using System.Collections.ObjectModel;
using ViewModels.Utilities;

namespace ViewModels.ViewModels;

/// <summary>
/// Представляет модель представления для вычислений.
/// </summary>
public class CalculateVm : ViewModelBase, ICalculateViewModel
{
	private readonly ICalculateService _calculateService;
	private readonly IExportService _exportService;
	private string _logOutput;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CalculateVm"/>.
	/// </summary>
	/// <param name="calculateService">Сервис для выполнения вычислений.</param>
	/// <param name="exportService">Сервис для экспорта данных.</param>
	public CalculateVm(ICalculateService calculateService, IExportService exportService)
	{
		_calculateService = calculateService;
		_exportService = exportService;
		_logOutput = string.Empty;
		Results = new ObservableCollection<DefinedFilterParameters>();

		_calculateService.ResultsLoaded += OnResultsLoaded;
		_calculateService.LogUpdated += OnLogUpdated;
	}

	/// <summary>
	/// Получает или задает вывод логов.
	/// </summary>
	public string LogOutput
	{
		get => _logOutput;
		set
		{
			if (_logOutput == value) return;
			_logOutput = value;
			OnPropertyChanged();
		}
	}

	public bool IsValidInputData => _calculateService.IsValidInputData;
	private void OnLogUpdated()
	{
		LogOutput = _calculateService.LogOutput;
	}

	/// <summary>
	/// Получает команду для выполнения вычислений.
	/// </summary>
	public RelayCommand CalculateCommand => _calculateService.CalculateCommand;

	/// <summary>
	/// Получает команду для экспорта данных в Excel.
	/// </summary>
	public RelayCommand ExportToExcelCommand => _exportService.ExportToExcelCommand;

	/// <summary>
	/// Получает коллекцию результатов вычислений.
	/// </summary>
	public ObservableCollection<DefinedFilterParameters> Results { get; }

	private void OnResultsLoaded(IEnumerable<DefinedFilterParameters> passengers)
	{
		try
		{
			System.Windows.Application.Current.Dispatcher.Invoke(() =>
			{
				Results.Clear();
				foreach (var passenger in passengers)
				{
					Results.Add(passenger);
				}
			});
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
		}
	}
}