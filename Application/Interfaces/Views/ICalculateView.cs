using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface ICalculateView
	{
		Represantation View { get; }
		void SetViewModel(ICalculateViewModel viewModel);
	}
}
