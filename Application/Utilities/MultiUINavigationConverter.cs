using Application.Parameters;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Application.Utilities
{
	/// <summary>
	/// Преобразователь для многозначной привязки, который создает объект <see cref="NavigationMenuParameter"/> из массива значений.
	/// </summary>
	public class MultiUiNavigationConverter : IMultiValueConverter
	{
		/// <summary>
		/// Преобразует массив значений в объект <see cref="NavigationMenuParameter"/>.
		/// </summary>
		/// <param name="values">Массив значений, содержащий элементы интерфейса.</param>
		/// <param name="targetType">Тип, в который нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Объект <see cref="NavigationMenuParameter"/>, содержащий панели и кнопки меню.</returns>
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new NavigationMenuParameter
			{
				Panel = (values[0] as Grid)!,
				CloseMenu = (values[1] as Button)!,
				OpenMenu = (values[2] as Button)!
			};
		}

		/// <summary>
		/// Преобразует значение обратно из целевого значения в массив значений источника данных.
		/// </summary>
		/// <param name="value">Значение, полученное из целевого элемента.</param>
		/// <param name="targetTypes">Массив типов, в которые нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Вызывает исключение <see cref="NotImplementedException"/>.</returns>
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
