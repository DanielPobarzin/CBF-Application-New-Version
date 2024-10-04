using Application.Interfaces.Services;
using Application.Interfaces.Views;
using Models.Commands;
using Models.Enums.Message;
using Ninject;
using System.Windows;

namespace Persistance.Services
{
	public class CustomMessageBoxService : ICustomMessageBoxService
	{
		private readonly Lazy<RelayCommand> _okCommand;
		private readonly Lazy<RelayCommand> _cancelCommand;
		private readonly Lazy<RelayCommand> _closeCommand;
		private readonly IKernel _services;
		private bool _dialog;
		public CustomMessageBoxService(IKernel services)
		{
			_services = services;
			_okCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await OkMessageAsync(parameter)));
			_cancelCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await CancelMessageAsync(parameter)));
			_closeCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await CloseMessageAsync(parameter)));
		}
		public RelayCommand OkCommand => _okCommand.Value;
		public RelayCommand CloseCommand => _closeCommand.Value;
		public RelayCommand CancelCommand => _cancelCommand.Value;
		public bool Dialog
		{
			get
			{
				return _dialog;
			}
			set
			{
				if (_dialog != value)
					_dialog = value;
			}
		}
		public void Show(Message typeOfMessage, string message, string title)
		{
			_services.Get<ICustomMessageBox>().ShowMessageDialog(typeOfMessage, message, title);
		}
		private async Task OkMessageAsync(object obj)
		{
			if (obj is Window win)
			{
				Dialog = true;
				await win.Dispatcher.InvokeAsync(() => win.Close());
			}
		}
		private async Task CancelMessageAsync(object obj)
		{
			if (obj is Window win)
			{
				Dialog = false;
				await win.Dispatcher.InvokeAsync(() => win.Close());
			}
		}
		private async Task CloseMessageAsync(object obj)
		{
			if (obj is Window win)
			{
				await win.Dispatcher.InvokeAsync(() => win.Close());
			}
		}
		
	}
}

