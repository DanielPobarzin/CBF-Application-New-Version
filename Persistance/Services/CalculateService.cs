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
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Persistence.Services
{
	/// <summary>
	/// Сервис для выполнения расчетов.
	/// </summary>
	public class CalculateService : ICalculateService
	{
		private readonly Lazy<RelayCommand> _calculateCommand;
		private readonly ICurrentParameterDto _currentParameter;
		private readonly IConstParameterService _constParameters;
		private readonly IValueConverter _valueConverter;
		private readonly IValidator<Fuel> _fuelValidator;
		private readonly IValidator<Filter> _filterValidator;
		private readonly IValidator<Station> _stationValidator;
		private readonly IValidator<DefinedFilterParameters> _calculateValidator;
		private readonly StringBuilder _logOutput;
		public event Action? LogUpdated;
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
		public event Action<ConcurrentBag<DefinedFilterParameters>>? ResultsLoaded;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CalculateService"/>.
		/// </summary>
		/// <param name="valueConverter">Объект для преобразования значений.</param>
		/// <param name="currentParameterDto">Объект текущих параметров.</param>
		/// <param name="constParameters">Сервис для работы с постоянными параметрами.</param>
		/// <param name="fuelValidator">Валидатор для проверки выбранного топлива.</param>
		/// <param name="filterValidator">Валидатор для проверки выбранного фильтра.</param>
		/// <param name="stationValidator">Валидатор для проверки параметров станции.</param>
		/// <param name="calculateValidator">Валидатор для проверки результатов расчетов.</param>
		public CalculateService(IValueConverter valueConverter,
			ICurrentParameterDto currentParameterDto,
			IConstParameterService constParameters,
			IValidator<Fuel> fuelValidator,
			IValidator<Filter> filterValidator,
			IValidator<Station> stationValidator,
			IValidator<DefinedFilterParameters> calculateValidator)
		{
			_valueConverter = valueConverter;
			_currentParameter = currentParameterDto;
			_constParameters = constParameters;
			_fuelValidator = fuelValidator;
			_filterValidator = filterValidator;
			_stationValidator = stationValidator;
			_calculateValidator = calculateValidator;
			Results = new ObservableCollection<DefinedFilterParameters>();
			_calculateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async _ 
				=> await StartInitAsync()));
			_logOutput = new StringBuilder();
		}

		/// <summary>
		/// Команда для запуска расчетов.
		/// </summary>
		public RelayCommand CalculateCommand => _calculateCommand.Value;
		public bool IsValidInputData => ValidationInit();
		private async Task StartInitAsync()
		{
			await RunCalculationAsync();
		}
		private bool ValidationInit()
		{
			if (_filterValidator.Validate(_currentParameter.SelectedFilter) is { IsValid: false } validationResultFilter)
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
					if (_fuelValidator?.Validate(fuel) is not { IsValid: false } validationResultFuel) continue;
					Log.Warning($"Validation failed for fuel {fuel.BrandFuel}");
					AddLog("Validation failed:");
					foreach (var error in validationResultFuel.Errors)
					{
						Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
						AddLog($"{error.ErrorMessage}");
					}
					return false;
				}
			}
			else
			{
				Log.Warning($"Validation failed for fuel:" +
					  $"\n- Не выбрана ни одна модель топлива.");
				AddLog($"Validation failed:" +
					  $"\n- Не выбрана ни одна модель топлива.");
				return false;
			}

			if (_stationValidator.Validate(_currentParameter.CurrentPropertyStation) is not
			    { IsValid: false } validationResultStation) return true;
			{
				Log.Warning("Validation failed for station parameter.");
				AddLog("Validation failed:");
				foreach (var error in validationResultStation.Errors)
				{
					Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
					AddLog($"{error.ErrorMessage}");
				}
				return false;
			}
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
					tasks.AddRange(_currentParameter.SelectedFuels
						.Select(fuel => Task.Run(async () =>
					{
						var result = Calculate(fuel);
						if (await _calculateValidator.ValidateAsync(result)! is { IsValid: false } validationResult)
						{
							// ReSharper disable once AccessToDisposedClosure
							await logSemaphore.WaitAsync();
							try
							{
								AddLog($"Validation failed: {result.UseFuel}");
								Log.Warning("Validation failed: Ошибки при расчете. Возможно, исходные данные некорректны.");
								foreach (var error in validationResult.Errors)
								{
									Log.Warning($"- {error.PropertyName}: {error.ErrorMessage}");
									AddLog($"{error.ErrorMessage}");
								}
							}
							finally
							{
								// ReSharper disable once AccessToDisposedClosure
								logSemaphore.Release();
							}

							return;
						}

						results.Add(result);
					})));
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
			var closest = values[0];
			var minDifference = Math.Abs(target - values[0]);

			foreach (var value in values)
			{
				var difference = Math.Abs(target - value);
				if (!(difference < minDifference)) continue;
				minDifference = difference;
				closest = value;
			}
			return closest;
		}
		private DefinedFilterParameters Calculate(Fuel fuel)
		{
			// ReSharper disable once UseObjectOrCollectionInitializer
			var result = new DefinedFilterParameters();

			result.UseFuel = fuel.BrandFuel;
			result.ColorResult = (Color)_valueConverter.
				Convert(null, typeof(Color), null, CultureInfo.InvariantCulture);

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
			result.CoefficientSecondaryEntrainmentTrappedAsh = result.HeightCoefficientElectrode * _constParameters.СoefficientElectrodeType *
				_currentParameter.SelectedFilter.CoefficientShakingMode * (1 - 0.25 * (result.FlueGasVelocity - 1));

			// Расчет параметра золоулавливания при равномерном поле скоростей
			result.ParameterAshCollectionUniformVelocityField = 0.2 * result.CoefficientSecondaryEntrainmentTrappedAsh *
				Math.Sqrt(result.TrateDriftAshParticles / result.FlueGasVelocity) * _currentParameter.SelectedFilter.NumberFields *
				_currentParameter.SelectedFilter.ActiveFieldLength / _currentParameter.SelectedFilter.DistanceCpDevices;

			// Расчет просокока золы при равномерном поле скоростей
			result.AshEmissionUniformVelocityField = Math.Exp(-result.ParameterAshCollectionUniformVelocityField);

			// Расчет степени золоулавливания при равномерном поле скоростей
			result.DegreeAshCaptureUniformVelocityField = 1 - result.AshEmissionUniformVelocityField;

			// Расчет коэффициента относительного увеличения влияния неравномерности
			result.CoefficientRelativeIncreaseInfluenceUnevenness = 0.125 * (1 + result.ParameterAshCollectionUniformVelocityField) *
				result.ParameterAshCollectionUniformVelocityField;

			// Расчет относительной высоты подъемной шахты
			result.RelativeHeightLiftingShaft = FindClosestValue(_currentParameter.CurrentPropertyStation.HeightLiftShaft / _currentParameter.SelectedFilter.ElectrodeHeight,
				new[] { 0, 0.4, 0.8 });

			// Расчет квадрата отклонения скорости от среднего значения
			result.SquareVelocityDeviationAverageValue = (_currentParameter.CurrentPropertyStation.TypeFlueGasSupply == TypeFlueGasSupply.FlueGasSupplyFromBelow) ?
				_constParameters.SquareVelocityDeviationAverageValueSupplyBelow
				[_currentParameter.CurrentPropertyStation.NumberGrids]
				[_currentParameter.SelectedFilter.NumberFields]
				[result.RelativeHeightLiftingShaft] : _constParameters.SquareVelocityDeviationAverageValueCentralSupply[_currentParameter.SelectedFilter.NumberFields]
				[_currentParameter.CurrentPropertyStation.NumberGrids];

			// Расчет проскока золы через электрофильтр с учетом неравномерности поля
			result.PassageAshTakingAccountUnevennessFieldVelocity = (1 + result.CoefficientRelativeIncreaseInfluenceUnevenness *
				Math.Pow(result.SquareVelocityDeviationAverageValue, 2)) * result.AshEmissionUniformVelocityField;

			// Расчет проскока золы через неактивные зоны
			result.PassageAshInactiveZones = _constParameters.PassageAshInactiveZones[_currentParameter.SelectedFilter.NumberFields]
				[(int)_currentParameter.CurrentPropertyStation.SchemeBunkerPartitions];

			// Расчет проскока золы через электрофильтр с учетом протечек газов через зоны
			result.PassageAshTakingAccountGasLeaksZones = (1 - result.PassageAshInactiveZones - _constParameters.PassageAshSemiActiveZones) *
				result.PassageAshTakingAccountUnevennessFieldVelocity + _constParameters.PassageAshSemiActiveZones * result.PassageAshTakingAccountUnevennessFieldVelocity *
				_constParameters.СoeffIncreasePassageWeakenedElectricField + result.PassageAshInactiveZones;

			// Расчет степени золоулавливания золы
			result.DegreeAshCapture = 1 - result.PassageAshTakingAccountGasLeaksZones;
			if (result.DegreeAshCapture < 0.99)
			{
				var message = $"Степень улавливания золы для топлива типа '{fuel.BrandFuel}' ниже минимально допустимого значения. Желаете продолжить расчет?";
				var dialog = MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (dialog == MessageBoxResult.No)
				{
					return new DefinedFilterParameters();
				}
			}
			// Расчет количества образующейся золы и продуктов механического недожога топлива 
			result.AmountAshFormedProductsMechanicalUnderBurning = 10 * (_currentParameter.CurrentPropertyStation.FuelConsumption *
				(_constParameters.ProportionCarriedAshDuringSlagRemoval[_currentParameter.CurrentPropertyStation.SlagRemoval]) *
				fuel.AshContent + _constParameters.MechanicalUnderBurningFuel * fuel.LowerHeatCombustion / 32.68);

			// Расчет концентрации золы на входе в первое поле
			result.AshConcentrationEntranceToFirstField = result.AmountAshFormedProductsMechanicalUnderBurning / result.VolumetricGasConsumption;

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

			result.AshConcentrationEntranceMthField ??= new Dictionary<string, double>();
			// Расчет концентрации золы по полям
			for (var i = 1; i <= _currentParameter.SelectedFilter.NumberFields; i++)
			{
				result.AshConcentrationEntranceMthField[$"Поле №{i}"] = result.AshConcentrationEntranceToFirstField * Math.Pow(result.PassageAshFirstField, i - 1);
			}

			result.OptimalAshShakingMode ??= new Dictionary<string, double>();
			// Расчет оптимальный режим встряхивания по полям
			foreach (var ashConcentration in result.AshConcentrationEntranceMthField)
			{
				result.OptimalAshShakingMode[ashConcentration.Key] = (16.7 * result.AreaDepositionOneField * result.OptimalValueDustCapacity /
				(result.NumberGasesEnteringOneField * ashConcentration.Value * result.DegreeAshCaptureFirstField));
			}
			return result;
		}
		private void AddLog(string message)
		{
			lock (_logOutput)
			{
				var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
				_logOutput.AppendLine($"[{time} WRN]: {message}");
				LogUpdated?.Invoke();
			}
		}
		private static void HandleError(Exception ex)
		{
			MessageBox.Show($"Возникла ошибка при выполнении расчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			Log.Error("An error occurred: {0}", ex.Message);
		}
	}
}

