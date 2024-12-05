using Persistence.Behaviours;
using System;
using System.Windows;

namespace FilterApplication.View
{
	/// <summary>
	/// Загрузочное окно. Описывается основная логика взаимодействия
	/// </summary>
	public partial class SplashScreen
	{
		private readonly AnimationBehaviour _animationBehaviour;
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