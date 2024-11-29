using Models.Entities.HeatPowerPlant.EGM_Filters;
using System.Globalization;
using System.Windows.Data;

namespace Application.Utilities
{
	/// <summary>
	/// Преобразователь значений, используемый для привязки модели фильтра.
	/// </summary>
	public class SelectedFilterConverter : IValueConverter
	{
		/// <summary>
		/// Преобразует значение из источника данных в целевое значение для привязки.
		/// </summary>
		/// <param name="value">Значение, полученное из источника данных.</param>
		/// <param name="targetType">Тип, в который нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Возвращает true, если фильтр соответствует значению; в противном случае - false.</returns>
		public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			var filter = parameter as Filter;
			return filter != null && filter == value;
		}

		/// <summary>
		/// Преобразует значение обратно из целевого значения в значение источника данных.
		/// </summary>
		/// <param name="value">Значение, полученное из целевого элемента.</param>
		/// <param name="targetType">Тип, в который нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Возвращает параметр, если значение истинно; в противном случае - Binding.DoNothing.</returns>
		public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return (value is true ? parameter : Binding.DoNothing)!;
		}
	}
}
