using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using System.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Station.xaml
	/// </summary>
	public partial class Station : UserControl, IStationView
	{
		private IStationViewModel _viewModel;
		public Represantation View => Represantation.Station;
		public Station()
		{
			InitializeComponent();
		}
		public void SetViewModel(IStationViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
	}
}
