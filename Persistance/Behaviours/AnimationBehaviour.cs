using Application.Interfaces.Services;
using System.Windows;
using System.Windows.Media.Animation;

namespace Persistence.Behaviours;

/// <summary>
/// Реализация поведения анимации для анимации свойств элементов пользовательского интерфейса.
/// </summary>
public class AnimationBehaviour : IAnimationBehaviour
{
	/// <summary>
	/// Анимирует указанное свойство элемента пользовательского интерфейса.
	/// </summary>
	/// <param name="element">Элемент, которому будет применена анимация.</param>
	/// <param name="property">Имя свойства, которое будет анимироваться.</param>
	/// <param name="fromValue">Начальное значение свойства.</param>
	/// <param name="toValue">Конечное значение свойства.</param>
	/// <param name="duration">Длительность анимации.</param>
	/// <returns>Задача, представляющая асинхронную операцию анимации.</returns>
	public async Task AnimatePropertyAsync(FrameworkElement element, string property, double fromValue, double toValue, TimeSpan duration)
	{
		var animation = new DoubleAnimation
		{
			From = fromValue,
			To = toValue,
			Duration = new Duration(duration)
		};

		var taskCompletionSource = new TaskCompletionSource<bool>();

		animation.Completed += (_, _) => taskCompletionSource.SetResult(true);

		var storyboard = new Storyboard();
		storyboard.Children.Add(animation);
		Storyboard.SetTarget(animation, element);
		Storyboard.SetTargetProperty(animation, new PropertyPath(property));

		storyboard.Begin();

		await taskCompletionSource.Task;
	}
}