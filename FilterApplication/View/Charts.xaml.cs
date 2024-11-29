using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Charts.xaml
	/// </summary>
	public partial class Charts : IChartsView
	{
		private IChartViewModel _viewModel;
		public Representation View => Representation.Charts;
		public Charts()
		{
			InitializeComponent();
		}
		public void SetViewModel(IChartViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
	}
}
