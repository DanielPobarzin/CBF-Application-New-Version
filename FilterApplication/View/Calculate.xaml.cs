using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Application.Interfaces.Services;
using System.Windows.Media;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Calculate.xaml
	/// </summary>
	public partial class Calculate : UserControl, ICalculateView
	{
		private ICalculateViewModel _viewModel;
		public Represantation View => Represantation.Calculate;
		public Calculate()
		{
			InitializeComponent();
		}
		public void SetViewModel(ICalculateViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
		
	}
}