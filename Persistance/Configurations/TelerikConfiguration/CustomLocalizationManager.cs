using Telerik.Windows.Controls;
namespace Persistence.Configurations.TelerikConfiguration
{
	/// <summary>
	/// Класс <see cref="CustomLocalizationManager"/> предназначен для переопределения строк локализации.
	/// </summary>
	public class CustomLocalizationManager : LocalizationManager
	{
		/// <summary>
		/// Переопределяет метод получения строки локализации по ключу.
		/// </summary>
		/// <param name="key">Ключ локализации, для которого требуется получить строку.</param>
		/// <returns>Локализованная строка, соответствующая указанному ключу.</returns>
		public override string GetStringOverride(string key)
		{
			return key switch
			{
				"GridViewGroupPanelText" => "Для группировки перетащите заголовок столбца в эту область.",
				//---------------------- RadGridView Filter Dropdown items texts: 
				"GridViewClearFilter" => "Очистить фильтр",
				"GridViewFilterShowRowsWithValueThat" => "Отображение значений с условием:",
				"GridViewFilterSelectAll" => "Показать все",
				"GridViewFilterContains" => "Содержит",
				"GridViewFilterDoesNotContain" => "Не содержит",
				"GridViewFilterEndsWith" => "Заканчивается на",
				"GridViewFilterIsContainedIn" => "Включено в",
				"GridViewFilterIsEqualTo" => "Равно",
				"GridViewFilterIsGreaterThan" => "Больше, чем",
				"GridViewFilterIsGreaterThanOrEqualTo" => "Больше или равно",
				"GridViewFilterIsLessThan" => "Меньше, чем",
				"GridViewFilterIsLessThanOrEqualTo" => "Меньше или равно",
				"GridViewFilterIsNotEqualTo" => "Неравный",
				"GridViewFilterStartsWith" => "Начинается с",
				"GridViewFilterAnd" => "И",
				"GridViewFilter" => "Фильтр",
				"GridViewFilterIsNotContainedIn" => "Не содержится в",
				"GridViewFilterMatchCase" => "Учитывать регистр",
				"GridViewFilterOr" => "Или",
				"GridViewFilterIsNull" => "Равно нулю",
				"GridViewFilterIsNotNull" => "Не равно нулю",
				"GridViewFilterIsEmpty" => "Пуст",
				"GridViewFilterIsNotEmpty" => "Не пуст",
				"GridViewFilterDistinctValueNull" => "[null]",
				"GridViewFilterDistinctValueStringEmpty" => "[пуст]",
				//---------------------- RadGridView items texts: 
				"GridViewSearchPanelTopText" => "Поиск по таблице",
				"GridViewGroupPanelTopText" => "Заголовок группы",
				"GridViewGroupPanelTopTextGrouped" => "Сгруппирован по:",
				"GridViewColumnsSelectionButtonTooltip" => "Выбор столбца",
				"GridViewNewRowPositionButtonTooltip" => "Добавить",
				"GroupColumn" => "Столбец группы",
				"SortAdditionalColumn" => "Сортировка дополнительного столбца",
				"SortColumn" => "Сортировка столбца",
				"GridViewAlwaysVisibleNewRow" => "Добавить новый элемент",
				_ => base.GetStringOverride(key)
			};
		}
    }
}