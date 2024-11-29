using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface ICalculateView
	{
		Representation View { get; }
		void SetViewModel(ICalculateViewModel viewModel);
	}
}
