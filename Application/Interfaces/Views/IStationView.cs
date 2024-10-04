using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IStationView
	{
		Represantation View { get; }
		void SetViewModel(IStationViewModel viewModel);
	}
}
