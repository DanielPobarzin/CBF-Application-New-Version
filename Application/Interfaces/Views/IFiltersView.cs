using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IFiltersView
	{
		Represantation View { get; }
		void SetViewModel(IFilterViewModel viewModel);
	}
}
