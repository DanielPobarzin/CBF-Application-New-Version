using System;
using System.IO;
using System.Windows;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для SplashScreen.xaml
	/// </summary>
	public partial class SplashScreen : Window
	{
		public SplashScreen()
		{

			InitializeComponent();
			loading.Source = new Uri(Path.Combine(Environment.CurrentDirectory, @"Resources\Images\0001.gif"));
		}

	}
}
