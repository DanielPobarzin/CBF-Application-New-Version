using Models.Enums.View;
using Models.Interfaces.ViewModels;

namespace Models.Interfaces.Views
{
	public interface IFuelsView
	{
		Represantation View { get; }
		void SetViewModel(IFuelViewModel viewModel);
	}
}
