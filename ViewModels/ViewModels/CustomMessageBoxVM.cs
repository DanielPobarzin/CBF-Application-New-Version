using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Models.Commands;
using Ninject;

namespace ViewModels.ViewModels
{
	public class CustomMessageBoxVM : ICustomMessageBoxViewModel
	{
		private readonly IKernel _serviceProvider;
		private readonly ICustomMessageBoxService _messageService;
		public CustomMessageBoxVM(IKernel serviceProvider, ICustomMessageBoxService messageService)
		{
			_serviceProvider = serviceProvider;
			_messageService = messageService;
		}
		public RelayCommand OkCommand => _messageService.OkCommand;
		public RelayCommand CloseCommand => _messageService.CloseCommand;
		public RelayCommand CancelCommand => _messageService.CancelCommand;
	}
}


