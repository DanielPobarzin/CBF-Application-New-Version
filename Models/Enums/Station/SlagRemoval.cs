using System.ComponentModel;

namespace Models.Enums.Station
{
	public enum SlagRemoval
	{
		None = 0,
		[Description("Твердое шлакоудаление")]
		SolidSlagRemoval = 1,
		[Description("Жидкое шлакоудаление")]
		LiquidSlagRemoval = 2
	}
}
