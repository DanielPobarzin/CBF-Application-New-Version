using Application.Interfaces.Services;
using Persistance.Behaviorus;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для SplashScreen.xaml
	/// </summary>
	public partial class SplashScreen : Window
	{
		private AnimationBehaviour _animationBehaviour;
		public SplashScreen()
		{
			InitializeComponent();
			_animationBehaviour = new AnimationBehaviour();
			this.Loaded += SplashScreen_Loaded;
		}

		private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
		{
			await _animationBehaviour.AnimatePropertyAsync(Loading, "(FrameworkElement.Width)",
				Loading.ActualWidth, Loading.MaxWidth, TimeSpan.FromSeconds(5));
		}
	}
}