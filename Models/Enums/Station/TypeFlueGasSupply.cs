using System.ComponentModel;

namespace Models.Enums.Station
{
	public enum TypeFlueGasSupply
	{
		None = 0,
		[Description("Подвод дымовых газов снизу")]
		FlueGasSupplyFromBelow = 1,
		[Description("Прямой подвод дымовых газов")]
		DirectFlueGasSupply = 2
	}
}
