using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Models.Entities.CalculationFilterEfficiency;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Enums.Station;
using Persistance.DTOs;
using Serilog;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Persistence.Core;

namespace Persistance.Services
{
	public class ChartsBuilderService : IChartsBuilderService
    {
        private readonly ICalculateService _calculateService;
        private readonly ICurrentParameterDTO _currentParameter;
		private readonly IConstParameterService _constParameters;

		private CurrentParameterDTO _currentParameterDTOForCharts;
		public ChartsBuilderService (ICalculateService calculateService, ICurrentParameterDTO currentParameterDTO, IConstParameterService constParameterService)
       {
            _calculateService = calculateService;
            _currentParameter = currentParameterDTO;
			_constParameters = constParameterService;
			calculateService.ResultsLoaded += RWEERER;

			var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<CurrentParameterDTO, CurrentParameterDTO>();
			});
			var mapper = config.CreateMapper();
			_currentParameterDTOForCharts = mapper.Map<CurrentParameterDTO>(_currentParameter);
			DependencyDegreeAshConsumptionAirSuction = new();
		}
        public ObservableCollection<DependencyData> DependencyDegreeAshConsumptionAirSuction { get; set; }
        public ObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;

		private void RWEERER(IEnumerable<DefinedFilterParameters> ewwewe)
		{
			Task.Run(() =>  RunCalculationAsync());
		}

		private async Task RunCalculationAsync()
		{
			try
			{
				DependencyDegreeAshConsumptionAirSuction.Clear();
				var results = new ConcurrentBag<DependencyData>();
				var fuels = _currentParameter.SelectedFuels.Where(selected => _calculateService.Results.Any(result => result.UseFuel == selected.BrandFuel)).ToList();

				var calculationTasks = fuels.Select(fuel => Task.Run(() =>
				{
					var result = new DependencyData();
					for (double temperature = 1; temperature <= 250; temperature = temperature + 1)
					{
						result.FuelName = _calculateService.Results.FirstOrDefault(x => x.UseFuel == fuel.BrandFuel).UseFuel;
						result.FuelColor = _calculateService.Results.FirstOrDefault(x => x.UseFuel == fuel.BrandFuel).СolorResult;
						result.Data ??= new();
						result.Data.Add(Calculate(fuel, temperature).Key, Calculate(fuel, temperature).Value);
					Log.Information($"{Calculate(fuel, temperature).Key} {Calculate(fuel, temperature).Value}");
					}
					results.Add(result);
				}));
				await Task.WhenAll(calculationTasks).ConfigureAwait(false);
				System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
				{
					foreach (var result in results)
					{
						DependencyDegreeAshConsumptionAirSuction.Add(result);
					}
				}));
			}
			catch (Exception ex)
			{
				
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
		private KeyValuePair<double, double> Calculate(Fuel fuel, double temperature)
		{
			var result = new DefinedFilterParameters();
		
			// Расчет объемного расхода газа
			result.VolumetricGasConsumption = _currentParameter.CurrentPropertyStation.FuelConsumption *
				(fuel.TheoreticalVolumeGas + 1.016 * (_currentParameter.CurrentPropertyStation.AirSuction - 1) *
				fuel.TheoreticalAirVolume) * (273 + temperature) / 273;

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
			return new KeyValuePair<double, double>(temperature, result.DegreeAshCapture);
		}
	}
}
