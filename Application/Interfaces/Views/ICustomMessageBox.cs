using Application.Interfaces.ViewModels;
using Models.Enums.Message;

namespace Application.Interfaces.Views
{
	public interface ICustomMessageBox
	{
		void SetViewModel(ICustomMessageBoxViewModel viewModel);
		void ShowMessageDialog(Message typeOfMessage, string message, string title);
	}
}
