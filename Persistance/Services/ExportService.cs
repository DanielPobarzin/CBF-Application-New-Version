using Application.Interfaces.Services;
using Microsoft.Win32;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Serilog;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Persistence.Services
{
	/// <summary>
	/// Служба экспорта данных, реализующая интерфейс <see cref="IExportService"/>.
	/// Предоставляет возможность экспортировать данные в файл Excel.
	/// </summary>
	public class ExportService : IExportService
	{
		private readonly Lazy<RelayCommand> _exportToExcelCommand;
		private readonly ICalculateService _calculateService;
		private readonly ICurrentParameterDto _currentParameters;
		private int currentRow = 1;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ExportService"/>.
		/// </summary>
		/// <param name="calculateService">Сервис для выполнения расчетов.</param>
		/// <param name="currentParameters">Текущие параметры для экспорта.</param>
		public ExportService(ICalculateService calculateService, ICurrentParameterDto currentParameters)
		{
			_calculateService = calculateService;
			_currentParameters = currentParameters;
			_exportToExcelCommand = new Lazy<RelayCommand>(() => new RelayCommand(async _ 
				=> await DialogExportToExcelAsync()));
		}

		/// <summary>
		/// Команда для экспорта данных в Excel.
		/// </summary>
		public RelayCommand ExportToExcelCommand => _exportToExcelCommand.Value;
		private async Task DialogExportToExcelAsync()
		{
			SaveFileDialog saveFileDialog = new()
			{
				Filter = "Excel Files (*.xlsx)|*.xlsx",
				Title = "Сохранить файл Excel",
				FileName = "Результаты",
				AddExtension = true,
				CheckPathExists = true
			};

			if (saveFileDialog.ShowDialog() == true)
			{
				currentRow = 1;
				await ExportToExcelAsync(saveFileDialog.FileName);
			}
		}
		private async Task ExportToExcelAsync(string filePath)
		{
			ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
			using var excelPackage = new ExcelPackage();
			try
			{
				await GetTemplateExportFileAsync(excelPackage);
				await WriteInitDataAsync(excelPackage);
				await WriteDefinedDataAsync(excelPackage);

				await excelPackage.SaveAsAsync(new FileInfo(filePath));
				MessageBox.Show("Экспорт завершен успешно!", "Экспорт данных",
					MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Невозможно совершить экспорт.", "Экспорт данных",
					MessageBoxButton.OK, MessageBoxImage.Error);
				Log.Error(ex.Message);
			}
		}
		private static async Task GetTemplateExportFileAsync(ExcelPackage excelPackage)
		{
			var existingFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, @"Resources\Templates\Template.xlsx"));
			if (existingFile.Exists)
			{
				await Task.Run(() =>
				{
					using var existingPackage = new ExcelPackage(existingFile);
					foreach (var worksheet in existingPackage.Workbook.Worksheets)
					{
						excelPackage.Workbook.Worksheets.Add(worksheet.Name, worksheet);
					}
				});
			}
		}
		private async Task WriteInitDataAsync(ExcelPackage excelPackage)
		{
			var worksheet = CreateWorksheet(excelPackage, "Исходные данные");
			worksheet.Cells.AutoFitColumns();
			await FillPropertiesAsync(worksheet, typeof(Fuel), _currentParameters.SelectedFuels);
			await FillPropertiesAsync(worksheet, typeof(Filter), _currentParameters.SelectedFilter);
			await FillPropertiesAsync(worksheet, typeof(Station), _currentParameters.CurrentPropertyStation);
		}
		private async Task WriteDefinedDataAsync(ExcelPackage excelPackage)
		{
			foreach (var result in _calculateService.Results)
			{
				var worksheet = CreateWorksheet(excelPackage, result.UseFuel);
				worksheet.Cells.AutoFitColumns();
				await FillResultsAsync(worksheet, typeof(DefinedFilterParameters), result);
			}
		}
		private async Task FillPropertiesAsync(ExcelWorksheet worksheet, Type type, object instance)
		{
			await Task.Run(() =>
			{
				var properties = type.GetProperties();
				var classDescription = type.GetCustomAttribute<DescriptionAttribute>()?.Description;
				if (!string.IsNullOrEmpty(classDescription))
				{
					var descriptionCell = worksheet.Cells[currentRow, 1];
					descriptionCell.Value = classDescription;
					worksheet.Cells.AutoFitColumns();
					descriptionCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					StyleCell(descriptionCell, 14);
				}
				foreach (var t in properties)
				{
					if (t.GetCustomAttribute<DescriptionAttribute>() == null) continue;
					currentRow++;
					var cell = worksheet.Cells[currentRow, 1];
					worksheet.Cells.AutoFitColumns();
					var attribute = t.GetCustomAttribute<DescriptionAttribute>();
					cell.Value = attribute?.Description ?? String.Empty;
					StyleCell(cell);

					if (instance != null && type != typeof(Fuel))
					{
						var valueCell = worksheet.Cells[currentRow, 2];
						valueCell.Value = t.PropertyType.IsEnum
							? GetEnumDescription((Enum)t.GetValue(instance)!)
							: t.GetValue(instance);
						StyleCell(valueCell);
					}
					else if (type == typeof(Fuel))
					{
						int currentColumn = 2;
						foreach (var fuel in _currentParameters.SelectedFuels)
						{
							var valueCell = worksheet.Cells[currentRow, currentColumn];
							valueCell.Value = t.GetValue(fuel);
							StyleCell(valueCell);
							currentColumn++;
						}
					}
				}
				currentRow++;
			});
		}
		private async Task FillResultsAsync(ExcelWorksheet worksheet, Type type, object instance)
		{
			var row = 0;
			await Task.Run(() =>
			{
				var properties = type.GetProperties();
				foreach (var t in properties)
				{
					if (t.GetCustomAttribute<DescriptionAttribute>() == null) continue;
					row++;
					var nameCell = worksheet.Cells[row, 1];
					var valueCell = worksheet.Cells[row, 2];
					worksheet.Cells.AutoFitColumns();
					nameCell.Value = t.GetCustomAttribute<DescriptionAttribute>()?.Description;
					if (t.PropertyType.IsGenericType &&
					    t.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
					{
						foreach (var keyValue in (t.GetValue(instance) as IDictionary<string, double>)!)
						{
							row++;
							worksheet.Cells[row, 1].Value = keyValue.Key;
							StyleCell(worksheet.Cells[row, 1]);
							worksheet.Cells[row, 2].Value = keyValue.Value;
							StyleCell(worksheet.Cells[row, 2]);
						}
					}
					else
					{
						valueCell.Value = t.GetValue(instance);
					}
					StyleCell(nameCell);
					StyleCell(valueCell);
				}
			});
		}
		private static ExcelWorksheet CreateWorksheet(ExcelPackage excelPackage, string? name)
		{
			var worksheet = excelPackage.Workbook.Worksheets.Add(name);
			return worksheet;
		}
		private static void StyleCell(ExcelRange cell, int fontSize = 12)
		{
			if (fontSize == 14) cell.Style.Font.Italic = true;
			cell.Style.Font.Name = "Times New Roman";
			cell.Style.Font.Size = fontSize;
			SetCellBorders(cell);
		}
		private static string GetEnumDescription(Enum value)
		{
			var field = value.GetType().GetField(value.ToString());
			if (field == null) return value.ToString();
			if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
			{
				return attribute.Description;
			}
			return value.ToString();
		}
		private static void SetCellBorders(ExcelRange cell)
		{
			cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
		}
	}
}
