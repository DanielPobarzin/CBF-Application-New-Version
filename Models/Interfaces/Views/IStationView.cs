using Models.Enums.View;
using Models.Interfaces.ViewModels;

namespace Models.Interfaces.Views
{
	public interface IStationView
	{
		Represantation View { get; }
		void SetViewModel(IStationViewModel viewModel);
	}
}
