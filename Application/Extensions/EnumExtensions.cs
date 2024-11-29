using System.ComponentModel;
using System.Reflection;

namespace Application.Extensions;

public static class EnumExtensions
{
	/// <summary>
	/// Получает описание для значения перечисления, если оно задано с помощью атрибута <see cref="DescriptionAttribute"/>.
	/// В противном случае возвращает строковое представление значения.
	/// </summary>
	/// <param name="value">Значение перечисления, для которого нужно получить описание.</param>
	/// <returns>Описание значения перечисления или его строковое представление, если описание отсутствует.</returns>
	public static string? GetDescription(this Enum value)
	{
		FieldInfo? fi = value.GetType().GetField(value.ToString());
		if (fi == null) return null;
		var attributes = (DescriptionAttribute[])fi
			.GetCustomAttributes(typeof(DescriptionAttribute), false);
		return attributes.Length > 0 ? attributes[0].Description : null;
	}
}