using Application.Interfaces.Services;
using Models.Enums.Station;
using System.Collections.Concurrent;

namespace Persistence.Services
{
	/// <summary>
	/// Служба константных параметров, реализующая интерфейс <see cref="IConstParameterService"/>.
	/// Предоставляет доступ к различным константным параметрам, связанным с процессами обработки.
	/// </summary>
	public class ConstParameterService : IConstParameterService
	{
		public ConstParameterService() {
			PassageAshInactiveZonesThreeFields = new ConcurrentDictionary<int, double>
			{
				[1] = 0.023,
				[2] = 0.022,
				[3] = 0.020,
				[4] = 0.002
			};
			PassageAshInactiveZonesFourFields = new ConcurrentDictionary<int, double>
			{
				[1] = 0.01,
				[2] = 0.009,
				[3] = 0.008,
				[4] = 0.001
			};
			PassageAshInactiveZones = new ConcurrentDictionary<int, ConcurrentDictionary<int, double>>
			{
				[3] = PassageAshInactiveZonesThreeFields,
				[4] = PassageAshInactiveZonesFourFields
			};
			SquareVelocityDeviationAverageValueThreeFieldsCentralSupply = new ConcurrentDictionary<int, double>
			{
				[1] = 0.150,
				[2] = 0.115
			};
			SquareVelocityDeviationAverageValueFourFieldsCentralSupply = new ConcurrentDictionary<int, double>
			{
				[1] = 0.120,
				[2] = 0.096
			};
			SquareVelocityDeviationAverageValueCentralSupply = new ConcurrentDictionary<int, ConcurrentDictionary<int, double>>
			{
				[3] = SquareVelocityDeviationAverageValueThreeFieldsCentralSupply,
				[4] = SquareVelocityDeviationAverageValueFourFieldsCentralSupply
			};
			SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.100,
				[0.4] = 0.079,
				[0.8] = 0.064
			};
			SquareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.084,
				[0.4] = 0.070,
				[0.8] = 0.060
			};
			SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.068,
				[0.4] = 0.053,
				[0.8] = 0.042
			};
			SquareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.053,
				[0.4] = 0.047,
				[0.8] = 0.042
			};
			SquareVelocityDeviationAverageValueSupplyBelowOneGrid = new ConcurrentDictionary<int, ConcurrentDictionary<double, double>>
			{
				[3] = SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid,
				[4] = SquareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid
			};
			SquareVelocityDeviationAverageValueSupplyBelowTwoGrid = new ConcurrentDictionary<int, ConcurrentDictionary<double, double>>
			{
				[3] = SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid,
				[4] = SquareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid
			};
			SquareVelocityDeviationAverageValueSupplyBelow = new ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>>
			{
				[1] = SquareVelocityDeviationAverageValueSupplyBelowOneGrid,
				[2] = SquareVelocityDeviationAverageValueSupplyBelowTwoGrid
			};
			ProportionCarriedAshDuringSlagRemoval = new ConcurrentDictionary<SlagRemoval, double>
			{
				[SlagRemoval.SolidSlagRemoval] = 0.95,
				[SlagRemoval.LiquidSlagRemoval] = 0.95
			};
			PassageAshSemiActiveZones = 0.05;
			СoeffIncreasePassageWeakenedElectricField = 2.0;
			СoefficientElectrodeType = 1.0;
			MechanicalUnderBurningFuel = 1.0;
		}
		public ConcurrentDictionary<int, double> PassageAshInactiveZonesThreeFields { get; }
		public ConcurrentDictionary<int, double> PassageAshInactiveZonesFourFields { get; }
		public ConcurrentDictionary<int, ConcurrentDictionary<int, double>> PassageAshInactiveZones { get; }
		public ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueThreeFieldsCentralSupply { get; }
		public ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueFourFieldsCentralSupply { get; }
		public ConcurrentDictionary<int, ConcurrentDictionary<int, double>> SquareVelocityDeviationAverageValueCentralSupply { get; }
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid { get; }
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid { get; }
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid { get; }
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid { get; }
		public ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowOneGrid { get; }
		public ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowTwoGrid { get; }
		public ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>> SquareVelocityDeviationAverageValueSupplyBelow { get; }
		public double PassageAshSemiActiveZones { get; }
		public double СoeffIncreasePassageWeakenedElectricField { get; }
		public double СoefficientElectrodeType { get; }
		public double MechanicalUnderBurningFuel { get; }
		public ConcurrentDictionary<SlagRemoval, double> ProportionCarriedAshDuringSlagRemoval { get; }
	}
}
