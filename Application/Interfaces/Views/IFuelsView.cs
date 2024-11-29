using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IFuelsView
	{
		Representation View { get; }
		void SetViewModel(IFuelViewModel viewModel);
	}
}
