using System.Windows;
using System.Windows.Input;

namespace Models.Commands;

/// <summary>
/// Представляет команду, которая может быть выполнена асинхронно.
/// </summary>
/// <remarks>
/// Этот класс реализует интерфейс <see cref="ICommand"/> и позволяет связывать команды с пользовательским интерфейсом,
/// обеспечивая поддержку асинхронного выполнения. Он также позволяет управлять состоянием доступности команды через 
/// метод <see cref="RaiseCanExecuteChanged"/>.
/// </remarks>
public class RelayCommand : ICommand
{
	private readonly Func<object, Task> _execute;
	private readonly Func<object, bool>? _canExecute;

	public event EventHandler? CanExecuteChanged;

	public RelayCommand(Func<object, Task> execute, Func<object, bool>? canExecute = null)
	{
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		_canExecute = canExecute;
	}

	/// <summary>
	/// Определяет, может ли команда быть выполнена с заданным параметром.
	/// </summary>
	/// <param name="parameter">Параметр для проверки доступности команды.</param>
	/// <returns>true, если команда может быть выполнена; в противном случае — false.</returns>
	public bool CanExecute(object? parameter)
	{
		if (_canExecute == null) return true;
		if (parameter != null) return _canExecute(parameter);
		return true;
	}

	/// <summary>
	/// Выполняет команду асинхронно с заданным параметром.
	/// </summary>
	/// <param name="parameter">Параметр, передаваемый в команду.</param>
	public async void Execute(object? parameter)
	{
		if (CanExecute(parameter))
		{
			await Application.Current.Dispatcher.InvokeAsync(async () =>
			{
				await _execute(parameter!);
			});
		}
	}
	public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}