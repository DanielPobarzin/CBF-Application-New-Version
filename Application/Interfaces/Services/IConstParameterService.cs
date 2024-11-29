using Models.Enums.Station;
using System.Collections.Concurrent;

namespace Application.Interfaces.Services
{
	public interface IConstParameterService
	{
		ConcurrentDictionary<int, double> PassageAshInactiveZonesThreeFields { get; }
		ConcurrentDictionary<int, double> PassageAshInactiveZonesFourFields { get;  }
		ConcurrentDictionary<int, ConcurrentDictionary<int, double>> PassageAshInactiveZones {  get; }

		ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueThreeFieldsCentralSupply { get; }
		ConcurrentDictionary<int, double> SquareVelocityDeviationAverageValueFourFieldsCentralSupply { get; }
		ConcurrentDictionary<int, ConcurrentDictionary<int, double>> SquareVelocityDeviationAverageValueCentralSupply { get; }

		ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowOneGrid { get; }
		ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowOneGrid { get; }

		ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueThreeFieldsSupplyBelowTwoGrid { get; }
		ConcurrentDictionary<double, double> SquareVelocityDeviationAverageValueFourFieldsSupplyBelowTwoGrid { get; }

		ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowOneGrid { get; }
		ConcurrentDictionary<int, ConcurrentDictionary<double, double>> SquareVelocityDeviationAverageValueSupplyBelowTwoGrid { get; }
		ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<double, double>>> SquareVelocityDeviationAverageValueSupplyBelow {  get; }

		double PassageAshSemiActiveZones { get; }
		double СoeffIncreasePassageWeakenedElectricField { get; }
		double СoefficientElectrodeType { get; }
		double MechanicalUnderBurningFuel { get; }

		ConcurrentDictionary<SlagRemoval, double> ProportionCarriedAshDuringSlagRemoval {  get; }
	}
}
