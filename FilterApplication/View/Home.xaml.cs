using Application.Interfaces.Views;
using Models.Enums.View;

namespace FilterApplication.View
{
	/// <summary>
	/// Страница "Главная". Описывается основная логика взаимодействия
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

