using System.Windows;

namespace Models.Interfaces.Services
{
	public interface IAnimationBehaviour
	{
		Task AnimatePropertyAsync(FrameworkElement element, string property, double fromValue, double toValue, TimeSpan duration);
	}
}
