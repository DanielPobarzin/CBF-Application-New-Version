using System.Globalization;
using System.Windows.Data;

namespace Application.Utilities
{
	/// <summary>
	/// Конвертер значений, который проверяет, меньше ли заданное значение по сравнению с параметром.
	/// Реализует интерфейс IValueConverter.
	/// </summary>
	public class IsLessThanConverter : IValueConverter
	{
		/// <summary>
		/// Экземпляр конвертера, используемый для повторного использования.
		/// </summary>
		public static readonly IValueConverter Instance = new IsLessThanConverter();

		/// <summary>
		/// Преобразует значение в булево значение, указывающее,
		/// меньше ли оно заданного параметра.
		/// </summary>
		/// <param name="value">Значение, которое нужно проверить.</param>
		/// <param name="targetType">Тип целевого значения (не используется).</param>
		/// <param name="parameter">Параметр для сравнения.</param>
		/// <param name="culture">Информация о культуре (не используется).</param>
		/// <returns>True, если значение меньше параметра; иначе - false.</returns>
		public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			var doubleValue = System.Convert.ToDouble(value);
			var compareToValue = System.Convert.ToDouble(parameter);

			return doubleValue < compareToValue;
		}

		/// <summary>
		/// Не реализовано. Вызывает исключение NotImplementedException.
		/// </summary>
		/// <param name="value">Значение для преобразования.</param>
		/// <param name="targetType">Тип целевого значения (не используется).</param>
		/// <param name="parameter">Параметр для преобразования (не используется).</param>
		/// <param name="culture">Информация о культуре (не используется).</param>
		/// <returns>Не реализовано.</returns>
		public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// Конвертер значений, который проверяет, больше ли заданное значение по сравнению с параметром.
	/// Реализует интерфейс IValueConverter.
	/// </summary>
	public class IsGreaterThanConverter : IValueConverter
	{
		/// <summary>
		/// Экземпляр конвертера, используемый для повторного использования.
		/// </summary>
		public static readonly IValueConverter Instance = new IsGreaterThanConverter();

		/// <summary>
		/// Преобразует значение в булево значение, указывающее,
		/// больше ли оно заданного параметра.
		/// </summary>
		/// <param name="value">Значение, которое нужно проверить.</param>
		/// <param name="targetType">Тип целевого значения (не используется).</param>
		/// <param name="parameter">Параметр для сравнения.</param>
		/// <param name="culture">Информация о культуре (не используется).</param>
		/// <returns>True, если значение больше параметра; иначе - false.</returns>
		public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			var doubleValue = System.Convert.ToDouble(value);
			var compareToValue = System.Convert.ToDouble(parameter);

			return doubleValue > compareToValue;
		}

		/// <summary>
		/// Не реализовано. Вызывает исключение NotImplementedException.
		/// </summary>
		/// <param name="value">Значение для преобразования.</param>
		/// <param name="targetType">Тип целевого значения (не используется).</param>
		/// <param name="parameter">Параметр для преобразования (не используется).</param>
		/// <param name="culture">Информация о культуре (не используется).</param>
		/// <returns>Не реализовано.</returns>
		public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
