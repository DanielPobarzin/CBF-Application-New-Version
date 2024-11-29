using System.ComponentModel;

namespace Models.Enums.Station
{
	public enum SchemeBunkerPartitions
    {
		None = 0,
		[Description("Рисунок №1")]
		WithTwoCurvedPartition = 1,
		[Description("Рисунок №2")]
		WithTwoCurvedAndOneStraightPartition = 2,
		[Description("Рисунок №3")]
		WithFivePartitions = 3,
		[Description("Рисунок №4")]
		ThreeObliquePartitions = 4
	}
}
