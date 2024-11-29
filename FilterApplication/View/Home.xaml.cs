using Application.Interfaces.Views;
using Models.Enums.View;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Home.xaml
	/// </summary>
	public partial class Home : IHomeView
	{
		public Representation View => Representation.Home;
		public Home()
		{
			InitializeComponent();
		}
	}
}

