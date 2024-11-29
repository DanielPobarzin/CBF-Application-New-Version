using Application.Parameters;

namespace Application.Interfaces.ViewModels
{
	public interface IChartViewModel
	{
		IEnumerable<ConcentrationStatisticsReport> AllData { get; set; }
		IEnumerable<ConcentrationStatistics> Data { get; set; }
	}
}
