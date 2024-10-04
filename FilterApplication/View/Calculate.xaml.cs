using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using System.Windows.Controls;

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