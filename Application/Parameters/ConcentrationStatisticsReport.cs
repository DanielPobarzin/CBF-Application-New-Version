namespace Application.Parameters
{
	public class ConcentrationStatisticsReport
	{
		public string? FuelName { get; set; }
		public double FirstFieldConcentration { get; set; } = 0;
		public double SecondFieldConcentration { get; set; } = 0;
		public double ThirdFieldConcentration { get; set; } = 0;
		public double FourthFieldConcentration { get; set; } = 0;
		public double OutConcentration { get; set; } = 0;
	}
}