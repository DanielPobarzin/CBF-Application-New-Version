using System.Windows;

namespace Application.Interfaces.Services
{
	public interface IAnimationBehaviour
	{
		Task AnimatePropertyAsync(FrameworkElement element, string property, double fromValue, double toValue, TimeSpan duration);
	}
}
