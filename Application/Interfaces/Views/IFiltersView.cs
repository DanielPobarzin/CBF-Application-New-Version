using Application.Interfaces.ViewModels;
using Models.Enums.View;

namespace Application.Interfaces.Views
{
	public interface IFiltersView
	{
		Representation View { get; }
		void SetViewModel(IFilterViewModel viewModel);
	}
}
