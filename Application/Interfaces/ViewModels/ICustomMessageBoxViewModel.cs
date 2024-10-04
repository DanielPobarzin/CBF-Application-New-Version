using Models.Commands;

namespace Application.Interfaces.ViewModels
{
	public interface ICustomMessageBoxViewModel
	{
		RelayCommand OkCommand { get; }
		RelayCommand CancelCommand { get; }
		RelayCommand CloseCommand { get; }
	}
}
