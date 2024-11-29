using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Application.Parameters;
using Models.Entities.CalculationFilterEfficiency;
using Serilog;
using System.Collections;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace ViewModels.ViewModels
{
	/// <summary>
	/// Представляет модель представления для графиков концентрации.
	/// </summary>
	public class ChartVm : ViewModelBase, IChartViewModel
	{
		private readonly ICalculateService _calculateService;
		private IEnumerable<ConcentrationStatistics> _data;
		private IEnumerable<ConcentrationStatisticsReport> _allData;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ChartVm"/>.
		/// </summary>
		/// <param name="calculateService">Сервис для выполнения расчетов.</param>
		public ChartVm(ICalculateService calculateService)
		{
			_calculateService = calculateService;
			_calculateService.ResultsLoaded += OnResultsLoaded;
			_data = new List<ConcentrationStatistics> { new() };
			_allData = new List<ConcentrationStatisticsReport> { new() };
			Results = new ObservableCollection<DefinedFilterParameters> { new() };
			GetDataCompleted(AllData);
		}

		/// <summary>
		/// Получает или задает данные концентрации.
		/// </summary>
		public IEnumerable<ConcentrationStatistics> Data
		{
			get => _data;
			set
			{
				_data = value;
				OnPropertyChanged(nameof(Data));
			}
		}

		/// <summary>
		/// Получает или задает все данные отчетов концентрации.
		/// </summary>
		public IEnumerable<ConcentrationStatisticsReport> AllData
		{
			get => _allData;
			set
			{
				_allData = value;
				OnPropertyChanged(nameof(AllData));
			}
		}
		public ObservableCollection<DefinedFilterParameters> Results { get; }
		private static ConcentrationStatisticsReport GetData(DefinedFilterParameters result)
		{
			ConcentrationStatisticsReport data = new()
			{
				FuelName = result.UseFuel,
				FirstFieldConcentration = GetValueOrDefault(result.AshConcentrationEntranceMthField, "Поле №1"),
				SecondFieldConcentration = GetValueOrDefault(result.AshConcentrationEntranceMthField, "Поле №2"),
				ThirdFieldConcentration = GetValueOrDefault(result.AshConcentrationEntranceMthField, "Поле №3"),
				FourthFieldConcentration = GetValueOrDefault(result.AshConcentrationEntranceMthField, "Поле №4")
			};
			if (result.AshConcentrationEntranceMthField != null)
				for (var i = 1; i <= result.AshConcentrationEntranceMthField.Count; i++)
				{
					if (GetValueOrDefault(result.AshConcentrationEntranceMthField, $"Поле №{i}") != 0) continue;
					data.OutConcentration = result.AshConcentrationEntranceToFirstField *
					                        Math.Pow(result.PassageAshFirstField, i - 1);
					break;
				}

			if (data.OutConcentration == 0)
			{
				data.OutConcentration = result.AshConcentrationEntranceToFirstField * Math.Pow(result.PassageAshFirstField, 4);
			}
			return data;
		}
		private void GetDataCompleted(IEnumerable data)
		{
			this.AllData = data as IEnumerable<ConcentrationStatisticsReport> 
			               ?? Enumerable.Empty<ConcentrationStatisticsReport>();

			var concentrationStatisticsReports = this.AllData as ConcentrationStatisticsReport[] ?? this.AllData.ToArray();
			var firstField = from c in concentrationStatisticsReports
							 select new ConcentrationStatistics()
							 {
								 FuelName = c.FuelName,
								 FieldName = "Поле №1",
								 AshConcentration = c.FirstFieldConcentration
							 };
			var secondField = from c in concentrationStatisticsReports
							  select new ConcentrationStatistics()
							  {
								  FuelName = c.FuelName,
								  FieldName = "Поле №2",
								  AshConcentration = c.SecondFieldConcentration
							  };
			var thirdField = from c in concentrationStatisticsReports
							 select new ConcentrationStatistics()
							 {
								 FuelName = c.FuelName,
								 FieldName = "Поле №3",
								 AshConcentration = c.ThirdFieldConcentration
							 };
			var fourthField = from c in concentrationStatisticsReports
							  select new ConcentrationStatistics()
							  {
								  FuelName = c.FuelName,
								  FieldName = "Поле №4",
								  AshConcentration = c.FourthFieldConcentration
							  };
			var outField = from c in concentrationStatisticsReports
						   select new ConcentrationStatistics()
						   {
							   FuelName = c.FuelName,
							   FieldName = "Выход",
							   AshConcentration = c.OutConcentration
						   };

			this.Data = firstField.Concat(secondField).Concat(thirdField).Concat(fourthField).Concat(outField);
		}
		private void OnResultsLoaded(IEnumerable<DefinedFilterParameters> results)
		{
			Results.Clear();
			try
			{
				System.Windows.Application.Current.Dispatcher.Invoke(() =>
				{
					List<ConcentrationStatisticsReport> chartData = new();
					foreach (var result in results)
					{
						chartData.Add(GetData(result));
						Results.Add(result);
					}
					AllData = chartData;
				});
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
			}

		}
		private static double GetValueOrDefault(Dictionary<string, double>? dictionary, string key) =>
			 dictionary != null && dictionary.TryGetValue(key, out var value) ? value : 0;
	}
}

