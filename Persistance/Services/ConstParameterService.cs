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
		private static readonly ConcurrentDictionary<int, double> passageAshInactiveZonesThreeFields;
		private static readonly ConcurrentDictionary<int, double> passageAshInactiveZonesFourFields;
		private static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, double>> passageAshInactiveZones;
		private static readonly ConcurrentDictionary<int, double> squareVelocityDeviationAverageValueThreeFieldsCentralSupply;
		private static readonly ConcurrentDictionary<int, double> squareVelocityDeviationAverageValueFourFieldsCentralSupply;
		private static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, double>> squareVelocityDeviationAverageValueCentralSupply;
		private static readonly ConcurrentDictionary<double, double> squareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid;
		private static readonly ConcurrentDictionary<double, double> squareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid;
		private static readonly ConcurrentDictionary<double, double> squareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid;
		private static readonly ConcurrentDictionary<double, double> squareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid;
		private static readonly ConcurrentDictionary<int, ConcurrentDictionary<double, double>> squareVelocityDeviationAverageValueSupplyBelowOneGrid;
		private static readonly ConcurrentDictionary<int, ConcurrentDictionary<double, double>> squareVelocityDeviationAverageValueSupplyBelowTwoGrid;
		private static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>> squareVelocityDeviationAverageValueSupplyBelow;
		private static readonly double passageAshSemiActiveZones;
		private static readonly double coefficientIncreasePassageWeakenedElectricField;
		private static readonly double coefficientElectrodeType;
		private static readonly double mechanicalUnderBurningFuel;
		private static readonly ConcurrentDictionary<SlagRemoval, double> proportionCarriedAshDuringSlagRemoval;

		/// <summary>
		/// Статический конструктор для инициализации статических полей класса <see cref="ConstParameterService"/>.
		/// </summary>
		static ConstParameterService() {

			passageAshInactiveZonesThreeFields = new ConcurrentDictionary<int, double>
			{
				[1] = 0.023,
				[2] = 0.022,
				[3] = 0.020,
				[4] = 0.002
			};
			passageAshInactiveZonesFourFields = new ConcurrentDictionary<int, double>
			{
				[1] = 0.01,
				[2] = 0.009,
				[3] = 0.008,
				[4] = 0.001
			};
			passageAshInactiveZones = new ConcurrentDictionary<int, ConcurrentDictionary<int, double>>
			{
				[3] = passageAshInactiveZonesThreeFields,
				[4] = passageAshInactiveZonesFourFields
			};
			squareVelocityDeviationAverageValueThreeFieldsCentralSupply = new ConcurrentDictionary<int, double>
			{
				[1] = 0.150,
				[2] = 0.115
			};
			squareVelocityDeviationAverageValueFourFieldsCentralSupply = new ConcurrentDictionary<int, double>
			{
				[1] = 0.120,
				[2] = 0.096
			};
			squareVelocityDeviationAverageValueCentralSupply = new ConcurrentDictionary<int, ConcurrentDictionary<int, double>>
			{
				[3] = squareVelocityDeviationAverageValueThreeFieldsCentralSupply,
				[4] = squareVelocityDeviationAverageValueFourFieldsCentralSupply
			};
			squareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.100,
				[0.4] = 0.079,
				[0.8] = 0.064
			};
			squareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.084,
				[0.4] = 0.070,
				[0.8] = 0.060
			};
			squareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.068,
				[0.4] = 0.053,
				[0.8] = 0.042
			};
			squareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid = new ConcurrentDictionary<double, double>
			{
				[0] = 0.053,
				[0.4] = 0.047,
				[0.8] = 0.042
			};
			squareVelocityDeviationAverageValueSupplyBelowOneGrid = new ConcurrentDictionary<int, ConcurrentDictionary<double, double>>
			{
				[3] = squareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid,
				[4] = squareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid
			};
			squareVelocityDeviationAverageValueSupplyBelowTwoGrid = new ConcurrentDictionary<int, ConcurrentDictionary<double, double>>
			{
				[3] = squareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid,
				[4] = squareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid
			};
			squareVelocityDeviationAverageValueSupplyBelow = new ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>>
			{
				[1] = squareVelocityDeviationAverageValueSupplyBelowOneGrid,
				[2] = squareVelocityDeviationAverageValueSupplyBelowTwoGrid
			};
			proportionCarriedAshDuringSlagRemoval = new ConcurrentDictionary<SlagRemoval, double>
			{
				[SlagRemoval.SolidSlagRemoval] = 0.95,
				[SlagRemoval.LiquidSlagRemoval] = 0.95
			};
			passageAshSemiActiveZones = 0.05;
			coefficientIncreasePassageWeakenedElectricField = 2.0;
			coefficientElectrodeType = 1.0;
			mechanicalUnderBurningFuel = 1.0;
		}
		public ConcurrentDictionary<int, double> PassageAshInactiveZonesThreeFields => passageAshInactiveZonesThreeFields;
		public ConcurrentDictionary<int, double> PassageAshInactiveZonesFourFields => passageAshInactiveZonesFourFields;
		public ConcurrentDictionary<int, ConcurrentDictionary<int, double>> PassageAshInactiveZones => passageAshInactiveZones;
		public ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueThreeFieldsCentralSupply => squareVelocityDeviationAverageValueThreeFieldsCentralSupply;
		public ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueFourFieldsCentralSupply => squareVelocityDeviationAverageValueFourFieldsCentralSupply;
		public ConcurrentDictionary<int, ConcurrentDictionary<int, double>> SquareVelocityDeviationAverageValueCentralSupply => squareVelocityDeviationAverageValueCentralSupply;
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid => squareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid;
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid => squareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid;
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid => squareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid;
		public ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid => squareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid;
		public ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowOneGrid => squareVelocityDeviationAverageValueSupplyBelowOneGrid;
		public ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowTwoGrid => squareVelocityDeviationAverageValueSupplyBelowTwoGrid;
		public ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>> SquareVelocityDeviationAverageValueSupplyBelow => squareVelocityDeviationAverageValueSupplyBelow;
		public double PassageAshSemiActiveZones => passageAshSemiActiveZones;
		public double СoeffIncreasePassageWeakenedElectricField => coefficientIncreasePassageWeakenedElectricField;
		public double СoefficientElectrodeType => coefficientElectrodeType;
		public double MechanicalUnderBurningFuel => mechanicalUnderBurningFuel;
		public ConcurrentDictionary<SlagRemoval, double> ProportionCarriedAshDuringSlagRemoval => proportionCarriedAshDuringSlagRemoval;
	}
}
