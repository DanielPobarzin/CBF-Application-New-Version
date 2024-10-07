using Application.Extensions;
using Application.Interfaces.Services;
using Application.Parameters;
using AutoMapper;
using Models.Commands;
using Models.Entities.CalculationFilterEfficiency;
using Models.Enums.Station;
using Persistance.DTOs;

namespace Persistance.Services
{
	public class ChartsBuilderService : IChartsBuilderService
    {
        private readonly ICalculateService _calculateService;
        private readonly ICurrentParameterDTO _currentParameterDTO;
		private readonly IConstParameterService _constParameters;
		private readonly Lazy<RelayCommand> _buildCommand;
		private readonly Lazy<RelayCommand> _drawCommand;

		private CalculateService _calculateServiceForCharts;
		private ICurrentParameterDTO _currentParameterDTOForCharts;

		public ChartsBuilderService(ICalculateService calculateService, ICurrentParameterDTO currentParameterDTO, IConstParameterService constParameters)
        {
			_calculateService = calculateService;
            _currentParameterDTO = currentParameterDTO;
            _constParameters = constParameters;
			_buildCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await BuildChartAsync(parameter)));
			_drawCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await DrawChartAsync(parameter)));
		}
	
		public RelayCommand BuildCommand => _buildCommand.Value;
		public RelayCommand DrawCommand => _drawCommand.Value;
		public ConcurrentObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;
		public double Step => 0.001;
		public double MinValueRange => 1.15;
		public double MaxValueRange => 1.45;
		public ConcurrentObservableCollection<ChartWithVariousAirSuction> ResultsWithVariousAirSuction { get; set; }

		private async Task BuildChartAsync(object parameter)
		{
			var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<CurrentParameterDTO, CurrentParameterDTO>();
			});
			var mapper = config.CreateMapper();
			_currentParameterDTOForCharts = mapper.Map<CurrentParameterDTO>(_currentParameterDTO);
			_calculateServiceForCharts = new(null, _currentParameterDTOForCharts, _constParameters);
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
		private async Task DrawChartAsync(object parameter)
		{
			foreach( var fuel in _currentParameterDTOForCharts.SelectedFuels)
			{
				var dataChart =new ChartWithVariousAirSuction();
				for (double airSuction = MinValueRange; airSuction <= MaxValueRange; airSuction += Step)
				{
					var result = new DefinedFilterParameters();
					
					_currentParameterDTOForCharts.CurrentPropertyStation.AirSuction = airSuction;
					result.UseFuel = fuel.BrandFuel;
					result.VolumetricGasConsumption = _currentParameterDTOForCharts.CurrentPropertyStation.FuelConsumption *
					(fuel.TheoreticalVolumeGas + 1.016 * (_currentParameterDTOForCharts.CurrentPropertyStation.AirSuction - 1) *
					fuel.TheoreticalAirVolume) * (273 + _currentParameterDTOForCharts.CurrentPropertyStation.ExhaustGasTemperature) / 273;

					// Расчет скорости дымовых газов
					result.FlueGasVelocity = result.VolumetricGasConsumption /
						(_currentParameterDTOForCharts.CurrentPropertyStation.NumberSmokePumps * _currentParameterDTOForCharts.SelectedFilter.AreaActiveSection);

					// Расчет эффективной напряженности электрического поля
					result.EffectiveStrength = fuel.CoefficientReverseCrown * fuel.ElectricFieldStrength;

					// Расчет скорости дрейфа частиц золы
					result.TrateDriftAshParticles = 0.25 * Math.Pow(result.EffectiveStrength, 2) * fuel.MedianDiameterAsh;

					// Расчет коэффициента высоты электрода
					result.HeightCoefficientElectrode = 7.5 / _currentParameterDTOForCharts.SelectedFilter.ElectrodeHeight;

					// Расчет коэффициента вторичного уноса уловленной золы
					result.CoeffSecondaryEntrainmentTrappedAsh = result.HeightCoefficientElectrode * _constParameters.СoefficientElectrodeType *
						_currentParameterDTOForCharts.SelectedFilter.СoefficientShakingMode * (1 - 0.25 * (result.FlueGasVelocity - 1));

					// Расчет параметра золоулавливания при равномерном поле скоростей
					result.ParameterAshCollectionUNIFORMVelocityField = 0.2 * result.CoeffSecondaryEntrainmentTrappedAsh *
						Math.Sqrt(result.TrateDriftAshParticles / result.FlueGasVelocity) * _currentParameterDTOForCharts.SelectedFilter.NumberFields *
						_currentParameterDTOForCharts.SelectedFilter.ActiveFieldLength / _currentParameterDTOForCharts.SelectedFilter.DistanceCPDevices;

					// Расчет просокока золы при равномерном поле скоростей
					result.AshEmissionUniformVelocityField = Math.Exp(-result.ParameterAshCollectionUNIFORMVelocityField);

					// Расчет степени золоулавливания при равномерном поле скоростей
					result.DegreeAshCaptureUNIFORMVelocityField = 1 - result.AshEmissionUniformVelocityField;

					// Расчет коэффициента относительного увеличения влияния неравномерности
					result.CoeffRelativeIncreaseInfluenceUnevenness = 0.125 * (1 + result.ParameterAshCollectionUNIFORMVelocityField) *
						result.ParameterAshCollectionUNIFORMVelocityField;

					// Расчет относительной высоты подъемной шахты
					result.RelativeHeightLiftingShaft = FindClosestValue(_currentParameterDTOForCharts.CurrentPropertyStation.HeightLiftShaft / _currentParameterDTOForCharts.SelectedFilter.ElectrodeHeight,
						new double[] { 0, 0.4, 0.8 });

					// Расчет квадрата отклонения скорости от среднего значения
					result.SquareVelocityDeviationAverageValue = (_currentParameterDTOForCharts.CurrentPropertyStation.TypeFlueGasSupply == TypeFlueGasSupply.FlueGasSupplyFromBelow) ?
						_constParameters.SquareVelocityDeviationAverageValueSupplyBelow
						[_currentParameterDTOForCharts.CurrentPropertyStation.NumberGrids]
						[_currentParameterDTOForCharts.SelectedFilter.NumberFields]
						[result.RelativeHeightLiftingShaft] : _constParameters.SquareVelocityDeviationAverageValueCentralSupply[_currentParameterDTOForCharts.SelectedFilter.NumberFields]
						[_currentParameterDTOForCharts.CurrentPropertyStation.NumberGrids];

					// Расчет проскока золы через электрофильтр с учетом неравномерности поля
					result.PassageAshTakingAccountUNEVENNESSFieldVelocity = (1 + result.CoeffRelativeIncreaseInfluenceUnevenness *
						Math.Pow(result.SquareVelocityDeviationAverageValue, 2)) * result.AshEmissionUniformVelocityField;

					// Расчет проскока золы через неактивные зоны
					result.PassageAshInactiveZones = _constParameters.PassageAshInactiveZones[_currentParameterDTOForCharts.SelectedFilter.NumberFields]
						[(int)_currentParameterDTOForCharts.CurrentPropertyStation.SchemeBunkerPartitions];

					// Расчет проскока золы через электрофильтр с учетом протечек газов через зоны
					result.PassageAshTakingAccountGasLeaksZones = (1 - result.PassageAshInactiveZones - _constParameters.PassageAshSemiActiveZones) *
						result.PassageAshTakingAccountUNEVENNESSFieldVelocity + _constParameters.PassageAshSemiActiveZones * result.PassageAshTakingAccountUNEVENNESSFieldVelocity *
						_constParameters.СoeffIncreasePassageWeakenedElectricField + result.PassageAshInactiveZones;

					// Расчет степени золоулавливания золы
					result.DegreeAshCapture = 1 - result.PassageAshTakingAccountGasLeaksZones;
					dataChart.BrandFuel = result.UseFuel;
					dataChart.AirSuctionAndDegreeAshConsuption[_currentParameterDTOForCharts.CurrentPropertyStation.AirSuction] = result.DegreeAshCapture;
				}
				ResultsWithVariousAirSuction.Add(dataChart);
			}
		}

	}

}
	
