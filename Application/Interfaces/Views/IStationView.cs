using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IStationView
	{
		Representation View { get; }
		void SetViewModel(IStationViewModel viewModel);
	}
}
