using Application.Interfaces.Services;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Enums.Station;
using Serilog;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Persistance.Services
{
	public class CalculateService : ICalculateService
	{
		private readonly Lazy<RelayCommand> _calculateCommand;
		private readonly ICurrentParameterDTO _currentParameter;
		private readonly IConstParameterService _constParameters;
		private readonly IValueConverter _valueConverter;
		public ObservableCollection<DefinedFilterParameters> Results { get; set; }
		public event Action<ConcurrentBag<DefinedFilterParameters>> ResultsLoaded;

		public CalculateService(IValueConverter valueConverter, ICurrentParameterDTO currentParameterDTO, IConstParameterService constParameters) {

			_valueConverter = valueConverter;
			_currentParameter = currentParameterDTO;
			_constParameters = constParameters;
			Results = new();
			_calculateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await StartInitAsync(parameter)));
		}
		public RelayCommand CalculateCommand => _calculateCommand.Value;
		private async Task StartInitAsync(object parameter)
		{
			// TODO: Добавить валиадцию исходных данных

			await RunCalculationAsync();
		}
		private async Task RunCalculationAsync()
		{
			try
			{
				Results.Clear();
				var results = new ConcurrentBag<DefinedFilterParameters>();
				var calculationTasks = _currentParameter.SelectedFuels.Select(fuel => Task.Run(() =>
				{
					var result = Calculate(fuel);

					// Заменить на валидацию результата DefinedCalculationResult
					if (result != null &&
						!double.IsInfinity(result.DegreeAshCapture) &&
						!double.IsNaN(result.DegreeAshCapture) &&
						result.DegreeAshCapture != 0)
					{
						results.Add(result);
					}
				}));

				await Task.WhenAll(calculationTasks).ConfigureAwait(false);
				System.Windows.Application.Current.Dispatcher.Invoke(() => ResultsLoaded?.Invoke(results));
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
		private void HandleError(Exception ex)
		{
			MessageBox.Show($"Возникла ошибка при выполнении расчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			Log.Error("An error occurred: {0}", ex.Message);
		}
	}
}
