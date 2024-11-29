using Models.Commands;

namespace Application.Interfaces.Services
{
	public interface ICommandService
	{
		RelayCommand CloseCommand { get; }
		RelayCommand MaxCommand { get; }
		RelayCommand MoveWindowCommand { get; }
		RelayCommand CloseNavigationMenuCommand { get; }
		RelayCommand OpenNavigationMenuCommand { get; }
		RelayCommand CloseFormDataCommand { get; }
		RelayCommand OpenFormDataCommand { get; }
	}
}
