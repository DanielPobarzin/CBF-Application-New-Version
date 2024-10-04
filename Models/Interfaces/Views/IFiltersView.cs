using Models.Enums.View;
using Models.Interfaces.ViewModels;

namespace Models.Interfaces.Views
{
	public interface IFiltersView
	{
		Represantation View { get; }
		void SetViewModel(IFilterViewModel viewModel);
	}
}
