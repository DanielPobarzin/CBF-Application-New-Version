using Application.Interfaces.Views;
using Models.Enums.View;
using System.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Home.xaml
	/// </summary>
	public partial class Home : UserControl, IHomeView
	{
		public Represantation View => Represantation.Home;
		public Home()
		{
			InitializeComponent();
		}
	}
}

