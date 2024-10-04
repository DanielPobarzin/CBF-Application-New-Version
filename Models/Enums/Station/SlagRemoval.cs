using System.ComponentModel;

namespace Models.Enums.Station
{
	public enum SlagRemoval
	{
		[Description("Твердое шлакоудаление")]
		SolidSlagRemoval = 1,
		[Description("Жидкое шлакоудаление")]
		LiquidSlagRemoval = 2
	}
}
