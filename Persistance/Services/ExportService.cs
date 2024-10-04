using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Microsoft.Win32;
using Models.Commands;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Message;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Persistance.Services
{
	public class ExportService : IExportService
	{
		private readonly Lazy<RelayCommand> _exportToExcelCommand;
		private readonly ICustomMessageBoxService _messageBoxService;
		private readonly ICalculateViewModel _calculateViewModel;
		private readonly ICurrentParameterDTO _currentParameters;

		public ExportService(ICustomMessageBoxService messageBoxService, ICalculateViewModel calculateViewModel, ICurrentParameterDTO currentParameters)
		{
			_calculateViewModel = calculateViewModel;
			_messageBoxService = messageBoxService;
			_currentParameters = currentParameters;
			_exportToExcelCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await DialogExportToExcelAsync(parameter)));
		}
		public RelayCommand ExportToExcelCommand => _exportToExcelCommand.Value;
		private async Task DialogExportToExcelAsync(object obj)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "Excel Files (*.xlsx)|*.xlsx",
				Title = "Сохранить файл Excel"
			};

			if (saveFileDialog.ShowDialog() == true)
			{
				await ExportToExcelAsync(saveFileDialog.FileName);
			}
		}
		private async Task ExportToExcelAsync(string filePath)
		{
			ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
			using (var excelPackage = new ExcelPackage())
			{
				await LoadExistingWorksheetsAsync(excelPackage);
				await ExportInitialDataAsync(excelPackage);
				await ExportCalculatedDataAsync(excelPackage);

				excelPackage.SaveAs(new FileInfo(filePath));
			}

			_messageBoxService.Show(Message.Information, "Экспорт завершен успешно!", "Экспорт данных");
		}
		private async Task LoadExistingWorksheetsAsync(ExcelPackage excelPackage)
		{
			var existingFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, @"Templates\Template.xlsx"));
			if (existingFile.Exists)
			{
				await Task.Run(() => 
				{
					using (var existingPackage = new ExcelPackage(existingFile))
					{
						foreach (var worksheet in existingPackage.Workbook.Worksheets)
						{
							excelPackage.Workbook.Worksheets.Add(worksheet.Name, worksheet);
						}
					}
				});
			}
		}

		private async Task ExportCalculatedDataAsync(ExcelPackage excelPackage)
		{
			foreach (var result in _calculateViewModel.Results)
			{
				var worksheet = CreateWorksheet(excelPackage, _);
			}
			
			worksheet.Cells.AutoFitColumns();
			await FillPropertiesAsync(worksheet, typeof(Filter), _currentParameters.SelectedFilter, 2);
			await FillPropertiesAsync(worksheet, typeof(Station), _currentParameters.CurrentPropertyStation, 6);
			await FillPropertiesAsync(worksheet, typeof(Fuel), _currentParameters.SelectedFuels, 10);
		}

		private async Task ExportInitialDataAsync(ExcelPackage excelPackage)
		{
			var worksheet = CreateWorksheet(excelPackage, "Исходные данные");
			worksheet.Cells.AutoFitColumns();
			await FillPropertiesAsync(worksheet, typeof(Filter), _currentParameters.SelectedFilter, 2);
			await FillPropertiesAsync(worksheet, typeof(Station), _currentParameters.CurrentPropertyStation, 6);
			await FillPropertiesAsync(worksheet, typeof(Fuel), _currentParameters.SelectedFuels, 10);
		}
		private async Task FillPropertiesAsync(ExcelWorksheet worksheet, Type type, object instance, int startRow)
		{
			await Task.Run(() =>
			{
				var properties = type.GetProperties();
				var classDescription = type.GetCustomAttribute<DescriptionAttribute>()?.Description;
				if (!string.IsNullOrEmpty(classDescription))
				{
					var descriptionCell = worksheet.Cells[startRow - 1, 1];
					descriptionCell.Value = classDescription;
					descriptionCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					StyleCell(descriptionCell, 14);
					worksheet.Cells[startRow - 1, 1, startRow - 1, worksheet.Dimension.End.Column].Merge = true;
				}
				for (int i = 0; i < properties.Length; i++)
				{
					if (properties[i].GetCustomAttribute<DescriptionAttribute>() != null)
					{
						var cell = worksheet.Cells[startRow, i + 1];
						cell.Value = properties[i].Name;
						StyleCell(cell);

						if (instance != null && instance is not Fuel)
						{
							var valueCell = worksheet.Cells[startRow + 1, i + 1];
							valueCell.Value = properties[i].GetValue(instance);
							StyleCell(valueCell);
						}
						else if (instance is Fuel)
						{
							int counter = 0;
							foreach (var fuel in _currentParameters.SelectedFuels)
							{
								var valueCell = worksheet.Cells[startRow + 1 + counter, i + 1];
								valueCell.Value = properties[i].GetValue(fuel);
								StyleCell(valueCell);
								counter ++;
							}
						}
					}
				}
			});
		}

		private ExcelWorksheet CreateWorksheet(ExcelPackage excelPackage, string name)
		{
			var worksheet = excelPackage.Workbook.Worksheets.Add(name);
			return worksheet;
		}

		private void StyleCell(ExcelRange cell, int fontSize = 12)
		{
			if (fontSize == 14) cell.Style.Font.Italic = true;
			cell.Style.Font.Name = "Times New Roman";
			cell.Style.Font.Size = fontSize;
			SetCellBorders(cell);
		}

		private void SetCellBorders(ExcelRange cell)
		{
			cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
			cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
		}
	}
}
