using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Station.xaml
	/// </summary>
	public partial class Station : IStationView
	{
		private IStationViewModel _viewModel;
		public Representation View => Representation.Station;
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
