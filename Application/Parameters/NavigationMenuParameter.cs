using System.Windows.Controls;

namespace Application.Parameters
{
	public class NavigationMenuParameter
	{
		public required Grid Panel { get; set; }
		public required Button OpenMenu { get; set; }
		public required Button CloseMenu { get; set; }
	}
}
