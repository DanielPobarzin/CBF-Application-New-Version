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
		private int currentRow = 1;
		public ExportService(ICalculateService calculateService, ICurrentParameterDTO currentParameters)
		{
			_calculateService = calculateService;
			_currentParameters = currentParameters;
			_exportToExcelCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await DialogExportToExcelAsync(parameter)));
		}
		public RelayCommand ExportToExcelCommand => _exportToExcelCommand.Value;
		private async Task DialogExportToExcelAsync(object obj)
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
			using (var excelPackage = new ExcelPackage())
			{
				try
				{
					await GetTemplateExportFileAsync(excelPackage);
					await WriteInitDataAsync(excelPackage);
					await WriteDefinedDataAsync(excelPackage);

					excelPackage.SaveAs(new FileInfo(filePath));
					MessageBox.Show("Экспорт завершен успешно!", "Экспорт данных", 
									MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex) 
				{
					MessageBox.Show($"Невозможно совершить экспорт.", "Экспорт данных", 
									MessageBoxButton.OK, MessageBoxImage.Error);
					Log.Error(ex.Message);
				}
			}
			
		}
		private async Task GetTemplateExportFileAsync(ExcelPackage excelPackage)
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
							valueCell.Value = properties[i].PropertyType.IsEnum
							? GetEnumDescription((Enum)properties[i].GetValue(instance))
							: properties[i].GetValue(instance);
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
		private async Task FillResultsAsync(ExcelWorksheet worksheet, Type type, object instance)
		{
			int currentRow = 0;
			await Task.Run(() =>
			{
				var properties = type.GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					if (properties[i].GetCustomAttribute<DescriptionAttribute>() != null)
					{
						currentRow++;
						var nameCell = worksheet.Cells[currentRow, 1];
						var valueCell = worksheet.Cells[currentRow, 2];
						worksheet.Cells.AutoFitColumns();
						nameCell.Value = properties[i].GetCustomAttribute<DescriptionAttribute>().Description;
						if (properties[i].PropertyType.IsGenericType &&
							 properties[i].PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
						{
							var dictionary = properties[i].GetValue(instance) as IDictionary<string, double>;
							foreach (var keyValue in dictionary)
							{
								currentRow++;
								worksheet.Cells[currentRow, 1].Value = keyValue.Key;
								StyleCell(worksheet.Cells[currentRow, 1]);
								worksheet.Cells[currentRow, 2].Value = keyValue.Value;
								StyleCell(worksheet.Cells[currentRow, 2]);
							}
						}
						else
						{
							valueCell.Value = properties[i].GetValue(instance);
						}
						StyleCell(nameCell);
						StyleCell(valueCell);
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
		private static string GetEnumDescription(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			if (field != null)
			{
				if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
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
