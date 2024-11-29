namespace Application.Features.EGM_Filters.Queries.GetAll
{
	/// <summary>
	/// Модель представления для получения всех фильтров.
	/// </summary>
	public class GetAllFiltersViewModel
	{
		public IList<FilterLookupDto>? Filters { get; set; }
	}
}
