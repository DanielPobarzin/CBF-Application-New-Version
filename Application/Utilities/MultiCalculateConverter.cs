using Application.Parameters;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Application.Utilities
{
	public class MultiCalculateConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new CalculateImageParameter
			{
				HeaderCalculating = values[0] as Border,
				ImageLoadCalculating = values[1] as Grid,
				ButtonCalculating = values[2] as ToggleButton
			};
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
