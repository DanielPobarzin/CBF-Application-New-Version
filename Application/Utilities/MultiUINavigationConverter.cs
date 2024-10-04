using Application.Parameters;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Application.Utilities
{
	public class MultiUINavigationConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new NavigationMenuParameter
			{
				Panel = values[0] as Grid,
				CloseMenu = values[1] as Button,
				OpenMenu = values[2] as Button
			};
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
