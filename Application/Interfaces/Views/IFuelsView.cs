using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IFuelsView
	{
		Represantation View { get; }
		void SetViewModel(IFuelViewModel viewModel);
	}
}
