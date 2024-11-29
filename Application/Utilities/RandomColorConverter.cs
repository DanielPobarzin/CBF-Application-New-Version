using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Application.Utilities
{
	/// <summary>
	/// Преобразователь значений, который возвращает случайный цвет из предопределенного списка.
	/// </summary>
	public class RandomColorConverter : IValueConverter
	{
		private readonly List<Color> colors = new()
		{
		Colors.Red,
		Colors.OrangeRed,
		Colors.Orange,
		Colors.Yellow,
		Colors.LightYellow,
		Colors.LemonChiffon,
		Colors.LightGoldenrodYellow,
		Colors.PaleGoldenrod,
		Colors.Gold,
		Colors.YellowGreen,
		Colors.LightGreen,
		Colors.LimeGreen,
		Colors.SpringGreen,
		Colors.Cyan,
		Colors.LightCyan,
		Colors.Aquamarine,
		Colors.Turquoise,
		Colors.LightSkyBlue,
		Colors.SkyBlue,
		Colors.DodgerBlue,
		Colors.CornflowerBlue,
		Colors.SteelBlue,
		Colors.LightSteelBlue,
		Colors.Peru,
		Colors.SandyBrown,
		Colors.BurlyWood,
		Colors.Wheat,
		Colors.PeachPuff,
		Colors.NavajoWhite,
		Colors.MistyRose,
		Colors.LightCoral,
		Colors.HotPink,
		Colors.DeepPink,
		Colors.Pink,
		Colors.LightPink,
		Colors.Violet,
		Colors.Plum,
		Colors.Orchid,
		Colors.Thistle,
		Colors.Lavender
	};

		private readonly HashSet<int> usedIndices = new();
		private readonly Random random = new();
		private readonly object lockObject = new();

		/// <summary>
		/// Преобразует значение из источника данных в цвет для привязки.
		/// </summary>
		/// <param name="value">Значение, полученное из источника данных.</param>
		/// <param name="targetType">Тип, в который нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Случайный цвет из предопределенного списка или случайный RGB цвет, если все цвета уже использованы.</returns>
		public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			lock (lockObject)
			{
				if (usedIndices.Count >= colors.Count)
				{
					return Color.FromRgb(
						(byte)random.Next(180, 256), 
						(byte)random.Next(180, 256), 
						(byte)random.Next(180, 256)
						);
				}
				int index;
				do
				{
					index = random.Next(colors.Count);
				} while (usedIndices.Contains(index));

				usedIndices.Add(index);
				return colors[index];
			}
		}

		/// <summary>
		/// Преобразует значение обратно из целевого значения в значение источника данных.
		/// </summary>
		/// <param name="value">Значение, полученное из целевого элемента.</param>
		/// <param name="targetType">Тип, в который нужно преобразовать значение.</param>
		/// <param name="parameter">Параметр, используемый для преобразования.</param>
		/// <param name="culture">Информация о культуре, используемая для преобразования.</param>
		/// <returns>Вызывает исключение NotImplementedException.</returns>
		public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
