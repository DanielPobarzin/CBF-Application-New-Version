using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Application.Utilities
{
	public class RandomColorConverter : IValueConverter
	{
		private Random random = new Random();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			byte red = (byte)random.Next(180, 256);
			byte green = (byte)random.Next(180, 256);
			byte blue = (byte)random.Next(180, 256);
			return new SolidColorBrush(Color.FromRgb(red, green, blue));
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
