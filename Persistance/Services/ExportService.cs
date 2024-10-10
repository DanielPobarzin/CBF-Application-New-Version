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

namespace Persistance.Services
{
	public class ExportService : IExportService
	{
		private readonly Lazy<RelayCommand> _exportToExcelCommand;
		private readonly ICalculateService _calculateService;
		private readonly ICurrentParameterDTO _currentParameters;
		private int currentRow;
		public ExportService(ICalculateService calculateService, ICurrentParameterDTO currentParameters)
		{
			_calculateService = calculateService;
			_currentParameters = currentParameters;
			_exportToExcelCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await DialogExportToExcelAsync(parameter)));
		}
		public RelayCommand ExportToExcelCommand => _exportToExcelCommand.Value;
		private async Task DialogExportToExcelAsync(object obj)
		{
			currentRow = 1;
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
				try
				{
					await LoadExistingWorksheetsAsync(excelPackage);
					await ExportInitialDataAsync(excelPackage);
					await ExportCalculatedDataAsync(excelPackage);
					excelPackage.SaveAs(new FileInfo(filePath));
					MessageBox.Show("Экспорт завершен успешно!", "Экспорт данных", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex) 
				{
					MessageBox.Show($"Невозможно совершить экспорт.", "Экспорт данных", MessageBoxButton.OK, MessageBoxImage.Error);
					Log.Error(ex.Message);
				}
			}
			
		}
		
		private async Task LoadExistingWorksheetsAsync(ExcelPackage excelPackage)
		{
			var existingFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, @"Resources\Templates\Template.xlsx"));
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
			foreach (var result in _calculateService.Results)
			{
				var worksheet = CreateWorksheet(excelPackage, result.UseFuel);
				worksheet.Cells.AutoFitColumns();
				//await FillPropertiesAsync(worksheet, typeof(DefinedFilterParameters), _currentParameters.SelectedFilter);
			}
		}

		private async Task ExportInitialDataAsync(ExcelPackage excelPackage)
		{
			var worksheet = CreateWorksheet(excelPackage, "Исходные данные");
			worksheet.Cells.AutoFitColumns();
			await FillPropertiesAsync(worksheet, typeof(Filter), _currentParameters.SelectedFilter);
			await FillPropertiesAsync(worksheet, typeof(Station), _currentParameters.CurrentPropertyStation);
			await FillPropertiesAsync(worksheet, typeof(Fuel), _currentParameters.SelectedFuels);
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
				for (int i = 0; i < properties.Length; i++)
				{
					if (properties[i].GetCustomAttribute<DescriptionAttribute>() != null)
					{
						currentRow++;
						var cell = worksheet.Cells[currentRow, 1];
						worksheet.Cells.AutoFitColumns();
						cell.Value = properties[i].GetCustomAttribute<DescriptionAttribute>().Description;
						StyleCell(cell);

						if (instance != null && type != typeof(Fuel))
						{
							var valueCell = worksheet.Cells[currentRow, 2];
							if (!properties[i].PropertyType.IsEnum)
							{
								valueCell.Value = properties[i].GetValue(instance);
							}
							else valueCell.Value = GetEnumDescription((Enum)properties[i].GetValue(instance));
							StyleCell(valueCell);
						}
						else if (type == typeof(Fuel))
						{
							int currentColumn = 2;
							foreach (var fuel in _currentParameters.SelectedFuels)
							{
								var valueCell = worksheet.Cells[currentRow, currentColumn];
								valueCell.Value = properties[i].GetValue(fuel);
								StyleCell(valueCell);
								currentColumn++;
							}
						}
					}
				}
				currentRow++;
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
		private static string GetEnumDescription(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			if (field != null)
			{
				DescriptionAttribute attribute =
					Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
				if (attribute != null)
				{
					return attribute.Description;
				}
			}
			return value.ToString(); 
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
