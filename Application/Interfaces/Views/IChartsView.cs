using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IChartsView
	{
		Representation View { get; }
		void SetViewModel(IChartViewModel viewModel);
	}
}
