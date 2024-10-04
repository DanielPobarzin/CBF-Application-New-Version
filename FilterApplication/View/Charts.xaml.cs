using Application.Interfaces.Views;
using Models.Enums.View;
using System.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Charts.xaml
	/// </summary>
	public partial class Charts : UserControl, IChartsView
	{
		public Represantation View => Represantation.Charts;
		public Charts()
		{
			InitializeComponent();
		}
	}
}
