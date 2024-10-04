using Models.Commands;
using Models.Enums.Message;

namespace Application.Interfaces.Services
{
	public interface ICustomMessageBoxService
    {
		RelayCommand OkCommand { get; }
		RelayCommand CancelCommand { get; }
		RelayCommand CloseCommand { get; }
		bool Dialog { get; set; }
		void Show(Message typeOfMessage, string message, string title);
	}
}
