using Models.Enums.Message;

namespace Application.Interfaces.Services
{
	public interface IMessageService
    {
        void Show(Message message, string typeOfMessege, string title);
    }
}
