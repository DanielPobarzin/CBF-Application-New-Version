using Application.Interfaces.Services;
using FluentValidation;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Station;
using Serilog;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Persistance.Services
{
	/// <summary>
	/// Сервис для выполнения расчетов.
	/// </summary>
	public class CalculateService : ICalculateService
	{
		private readonly Lazy<RelayCommand> _calculateCommand;
		private readonly ICurrentParameterDTO _currentParameter;
		private readonly IConstParameterService _constParameters;
		private readonly IValueConverter _valueConverter;
		private readonly IValidator<Fuel> _fuelValidator;
		private readonly IValidator<Filter> _filterValidator;
		private readonly IValidator<Station> _stationValidator;
		private readonly IValidator<DefinedFilterParameters> _calculateValidator;
		private readonly StringBuilder _logOutput;
		public event Action LogUpdated;
		/// <summary>
		/// Коллекция с определенными параметрами, полученными в результате расчетов.
		/// </summary>
		public ObservableCollection<DefinedFilterParameters> Results { get; set; }
		/// <summary>
		/// Логирующая строка с выводом сообщений.
		/// </summary>
		public string LogOutput
		{
			get
			{
				lock (_logOutput)
				{
					return _logOutput.ToString();
				}
			}
		}
		/// <summary>
		/// Событие, которое вызывается при загрузке результатов расчетов.
		/// </summary>
		public event Action<ConcurrentBag<DefinedFilterParameters>> ResultsLoaded;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CalculateService"/>.
		/// </summary>
		/// <param name="valueConverter">Объект для преобразования значений.</param>
		/// <param name="currentParameterDTO">Объект текущих параметров.</param>
		/// <param name="constParameters">Сервис для работы с постоянными параметрами.</param>
		/// <param name="fuelValidator">Валидатор для проверки выбранного топлива.</param>
		/// <param name="filterValidator">Валидатор для проверки выбранного фильтра.</param>
		/// <param name="stationValidator">Валидатор для проверки параметров станции.</param>
		/// <param name="calculateValidator">Валидатор для проверки результатов расчетов.</param>
		public CalculateService(IValueConverter valueConverter, 
			ICurrentParameterDTO currentParameterDTO, 
			IConstParameterService constParameters,
			IValidator<Fuel> fuelValidator,
			IValidator<Filter> filterValidator,
			IValidator<Station> stationValidator,
			IValidator<DefinedFilterParameters> calculateValidator)
		{
			_valueConverter = valueConverter;
			_currentParameter = currentParameterDTO;
			_constParameters = constParameters;
			_fuelValidator = fuelValidator;
			_filterValidator = filterValidator;
			_stationValidator = stationValidator;
			_calculateValidator = calculateValidator;
			Results = new();
			_calculateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await StartInitAsync(parameter)));
			_logOutput = new StringBuilder();
		}

		/// <summary>
		/// Команда для запуска расчетов.
		/// </summary>
		public RelayCommand CalculateCommand => _calculateCommand.Value;
		
		private async Task StartInitAsync(object parameter)
		{
			if (ValidationInit())
			{
				await RunCalculationAsync();
			}
		}
		private bool ValidationInit()
		{
			if (_filterValidator?.Validate(_currentParameter.SelectedFilter) is { IsValid: false } validationResultFilter)
			{
				AddLog("Validation failed:");
				foreach (var error in validationResultFilter.Errors)
				{
					Log.Warning($"Validation failed for filter {_currentParameter.SelectedFilter.BrandFilter}:\n - {error.PropertyName}: {error.ErrorMessage}");
					AddLog($"{error.ErrorMessage}");
				}
				return false;
			}
			if (_currentParameter.SelectedFuels.Count != 0)
			{
				foreach (var fuel in _currentParameter.SelectedFuels)
				{
					if (_fuelValidator?.Validate(fuel) is { IsValid: false } validationResultFuel)
					{
						Log.Warning($"Validation failed for fuel {fuel.BrandFuel}");
						AddLog($"Validation failed:");
						foreach (var error in validationResultFuel.Errors)
						{
							Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
							AddLog($"{error.ErrorMessage}");
						}
						return false;
					}
				}
			}else
			{
				Log.Warning($"Validation failed for fuel:" +
					  $"\n- Не выбрана ни одна модель топлива.");
				AddLog($"Validation failed:" +
					  $"\n- Не выбрана ни одна модель топлива.");
				return false;
			}

			if (_stationValidator?.Validate(_currentParameter.CurrentPropertyStation) is { IsValid: false } validationResultStation)
			{
				Log.Warning($"Validation failed for station parameter.");
				AddLog($"Validation failed:");
				foreach (var error in validationResultStation.Errors)
				{
					Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
					AddLog($"{error.ErrorMessage}");
				}
				return false;
			}
			return true;
		}
		private async Task RunCalculationAsync()
		{
			try
			{
				Results.Clear();
				var results = new ConcurrentBag<DefinedFilterParameters>();
				var tasks = new List<Task>();

				using (var logSemaphore = new SemaphoreSlim(1, 1))
				{
					foreach (var fuel in _currentParameter.SelectedFuels)
					{
						tasks.Add(Task.Run(async () =>
						{
							var result = Calculate(fuel);
							if (_calculateValidator?.Validate(result) is { IsValid: false } validationResult)
							{
								await logSemaphore.WaitAsync();
								try
								{
									AddLog($"Validation failed: {result.UseFuel}");
									Log.Warning($"Validation failed: Ошибки при расчете. Возможно, исходные данные некорректны.");
									foreach (var error in validationResult.Errors)
									{
										Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
										AddLog($"{error.ErrorMessage}");
									}
								}
								finally
								{
									logSemaphore.Release();
								}
								return;
							}

							results.Add(result);
						}));
					}
					await Task.WhenAll(tasks);
				}

				System.Windows.Application.Current.Dispatcher.Invoke(() => ResultsLoaded?.Invoke(results));
				foreach (var result in results) { Results.Add(result); }
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}
		private static double FindClosestValue(double target, double[] values)
		{
			double closest = values[0];
			double minDifference = Math.Abs(target - values[0]);

			foreach (var value in values)
			{
				double difference = Math.Abs(target - value);
				if (difference < minDifference)
				{
					minDifference = difference;
					closest = value;
				}
			}
			return closest;
		}
		private DefinedFilterParameters Calculate(Fuel fuel)
		{
			var result = new DefinedFilterParameters();

			result.UseFuel = fuel.BrandFuel;
			result.СolorResult = (Color)_valueConverter.Convert(null, typeof(Color), null, CultureInfo.InvariantCulture);

			// Расчет объемного расхода газа
			result.VolumetricGasConsumption = _currentParameter.CurrentPropertyStation.FuelConsumption *
				(fuel.TheoreticalVolumeGas + 1.016 * (_currentParameter.CurrentPropertyStation.AirSuction - 1) *
				fuel.TheoreticalAirVolume) * (273 + _currentParameter.CurrentPropertyStation.ExhaustGasTemperature) / 273;

			// Расчет скорости дымовых газов
			result.FlueGasVelocity = result.VolumetricGasConsumption /
				(_currentParameter.CurrentPropertyStation.NumberSmokePumps * _currentParameter.SelectedFilter.AreaActiveSection);

			// Расчет эффективной напряженности электрического поля
			result.EffectiveStrength = fuel.CoefficientReverseCrown * fuel.ElectricFieldStrength;

			// Расчет скорости дрейфа частиц золы
			result.TrateDriftAshParticles = 0.25 * Math.Pow(result.EffectiveStrength, 2) * fuel.MedianDiameterAsh;

			// Расчет коэффициента высоты электрода
			result.HeightCoefficientElectrode = 7.5 / _currentParameter.SelectedFilter.ElectrodeHeight;

			// Расчет коэффициента вторичного уноса уловленной золы
			result.CoeffSecondaryEntrainmentTrappedAsh = result.HeightCoefficientElectrode * _constParameters.СoefficientElectrodeType *
				_currentParameter.SelectedFilter.СoefficientShakingMode * (1 - 0.25 * (result.FlueGasVelocity - 1));
			
			// Расчет параметра золоулавливания при равномерном поле скоростей
			result.ParameterAshCollectionUNIFORMVelocityField = 0.2 * result.CoeffSecondaryEntrainmentTrappedAsh *
				Math.Sqrt(result.TrateDriftAshParticles / result.FlueGasVelocity) * _currentParameter.SelectedFilter.NumberFields *
				_currentParameter.SelectedFilter.ActiveFieldLength / _currentParameter.SelectedFilter.DistanceCPDevices;
			
			// Расчет просокока золы при равномерном поле скоростей
			result.AshEmissionUniformVelocityField = Math.Exp(-result.ParameterAshCollectionUNIFORMVelocityField);

			// Расчет степени золоулавливания при равномерном поле скоростей
			result.DegreeAshCaptureUNIFORMVelocityField = 1 - result.AshEmissionUniformVelocityField;
			
			// Расчет коэффициента относительного увеличения влияния неравномерности
			result.CoeffRelativeIncreaseInfluenceUnevenness = 0.125 * (1 + result.ParameterAshCollectionUNIFORMVelocityField) *
				result.ParameterAshCollectionUNIFORMVelocityField;

			// Расчет относительной высоты подъемной шахты
			result.RelativeHeightLiftingShaft = FindClosestValue(_currentParameter.CurrentPropertyStation.HeightLiftShaft / _currentParameter.SelectedFilter.ElectrodeHeight,
				new double[] { 0, 0.4, 0.8 });

			// Расчет квадрата отклонения скорости от среднего значения
			result.SquareVelocityDeviationAverageValue = (_currentParameter.CurrentPropertyStation.TypeFlueGasSupply == TypeFlueGasSupply.FlueGasSupplyFromBelow) ?
				_constParameters.SquareVelocityDeviationAverageValueSupplyBelow
				[_currentParameter.CurrentPropertyStation.NumberGrids]
				[_currentParameter.SelectedFilter.NumberFields]
				[result.RelativeHeightLiftingShaft] : _constParameters.SquareVelocityDeviationAverageValueCentralSupply[_currentParameter.SelectedFilter.NumberFields]
				[_currentParameter.CurrentPropertyStation.NumberGrids];

			// Расчет проскока золы через электрофильтр с учетом неравномерности поля
			result.PassageAshTakingAccountUNEVENNESSFieldVelocity = (1 + result.CoeffRelativeIncreaseInfluenceUnevenness *
				Math.Pow(result.SquareVelocityDeviationAverageValue, 2)) * result.AshEmissionUniformVelocityField;

			// Расчет проскока золы через неактивные зоны
			result.PassageAshInactiveZones = _constParameters.PassageAshInactiveZones[_currentParameter.SelectedFilter.NumberFields]
				[(int)_currentParameter.CurrentPropertyStation.SchemeBunkerPartitions];

			// Расчет проскока золы через электрофильтр с учетом протечек газов через зоны
			result.PassageAshTakingAccountGasLeaksZones = (1 - result.PassageAshInactiveZones - _constParameters.PassageAshSemiActiveZones) *
				result.PassageAshTakingAccountUNEVENNESSFieldVelocity + _constParameters.PassageAshSemiActiveZones * result.PassageAshTakingAccountUNEVENNESSFieldVelocity *
				_constParameters.СoeffIncreasePassageWeakenedElectricField + result.PassageAshInactiveZones;

			// Расчет степени золоулавливания золы
			result.DegreeAshCapture = 1 - result.PassageAshTakingAccountGasLeaksZones;
			if (result.DegreeAshCapture < 0.99)
			{
				var message = $"Степень улавливания золы для топлива типа {fuel.BrandFuel} ниже минимально допустимого значения. Желаете продолжить расчет?";
				MessageBoxResult dialog = MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (dialog == MessageBoxResult.No)
				{
					return new();
				}
			}
			// Расчет количества образующейся золы и продуктов механического недожога топлива 
			result.AmountAshFormedProductsMechanicalUnderburning = 10 * (_currentParameter.CurrentPropertyStation.FuelConsumption *
				(_constParameters.ProportionCarriedAshDuringSlagRemoval[_currentParameter.CurrentPropertyStation.SlagRemoval]) *
				fuel.AshContent + _constParameters.MechanicalUnderburningFuel * fuel.LowerHeatCombustion / 32.68);

			// Расчет концентрации золы на входе в первое поле
			result.AshConcentrationEntranceToFirstField = result.AmountAshFormedProductsMechanicalUnderburning / result.VolumetricGasConsumption;

			// Расчет проскока золы в первом поле
			result.PassageAshFirstField = Math.Pow(result.PassageAshTakingAccountGasLeaksZones, 1.0 / _currentParameter.SelectedFilter.NumberFields);

			// Расчет степени улавливания золы в первом поле
			result.DegreeAshCaptureFirstField = 1 - result.PassageAshFirstField;

			// Расчет оптимального значения пылеемкости
			result.OptimalValueDustCapacity = 3.14 - 0.25 * fuel.ElectricalResistanceAsh;

			// Расчет площади осаждения одного поля
			result.AreaDepositionOneField = _currentParameter.SelectedFilter.TotalDepositionArea / _currentParameter.SelectedFilter.NumberFields;

			// Расчет количества газов, поступающих в одно поле
			result.NumberGasesEnteringOneField = result.VolumetricGasConsumption / _currentParameter.CurrentPropertyStation.NumberSmokePumps;

			// Расчет количества газов, поступающих в одно поле
			result.NumberGasesEnteringOneField = result.VolumetricGasConsumption / _currentParameter.CurrentPropertyStation.NumberSmokePumps;

			result.AshConcentrationEntranceMthField ??= new();
			// Расчет концентрации золы по полям
			for (int i = 1; i <= _currentParameter.SelectedFilter.NumberFields; i++)
			{
				result.AshConcentrationEntranceMthField[$"Поле №{i}"] = (result.AshConcentrationEntranceToFirstField * Math.Pow(result.PassageAshFirstField, i - 1));
			}

			result.OptimalAshShakingMode ??= new();
			// Расчет оптимальный режим встряхивания по полям
			foreach (var AshConcentration in result.AshConcentrationEntranceMthField)
			{
				result.OptimalAshShakingMode[AshConcentration.Key] = (16.7 * result.AreaDepositionOneField * result.OptimalValueDustCapacity /
				(result.NumberGasesEnteringOneField * AshConcentration.Value * result.DegreeAshCaptureFirstField));
			}
			return result;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		private void AddLog(string message)
		{
			lock (_logOutput)
			{
				string time = DateTime.Now.ToString();
				_logOutput.AppendLine($"[{time} WRN]: {message}");
				LogUpdated?.Invoke();
			}
		}
		private void HandleError(Exception ex)
		{
			MessageBox.Show($"Возникла ошибка при выполнении расчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			Log.Error("An error occurred: {0}", ex.Message);
		}
	}
}
