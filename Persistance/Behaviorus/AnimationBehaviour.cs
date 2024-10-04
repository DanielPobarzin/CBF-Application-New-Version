using Application.Interfaces.Services;
using System.Windows;
using System.Windows.Media.Animation;

namespace Persistance.Behaviorus
{
	public class AnimationBehaviour : IAnimationBehaviour
	{
		public async Task AnimatePropertyAsync(FrameworkElement element, string property, double fromValue, double toValue, TimeSpan duration)
		{
			var animation = new DoubleAnimation
			{
				From = fromValue,
				To = toValue,
				Duration = new Duration(duration)
			};

			var taskCompletionSource = new TaskCompletionSource<bool>();

			animation.Completed += (s, e) => taskCompletionSource.SetResult(true);

			Storyboard storyboard = new Storyboard();
			storyboard.Children.Add(animation);
			Storyboard.SetTarget(animation, element);
			Storyboard.SetTargetProperty(animation, new PropertyPath(property));

			storyboard.Begin();

			await taskCompletionSource.Task;
		}
	}
}
