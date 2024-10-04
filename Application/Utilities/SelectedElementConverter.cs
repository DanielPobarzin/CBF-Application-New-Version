using Models.Entities.HeatPowerPlant.EGM_Filters;
using System.Globalization;
using System.Windows.Data;

namespace Application.Utilities
{
	public class SelectedFilterConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var filter = parameter as Filter;
			return filter != null && filter == value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is true ? parameter : Binding.DoNothing;
		}
	}
}
