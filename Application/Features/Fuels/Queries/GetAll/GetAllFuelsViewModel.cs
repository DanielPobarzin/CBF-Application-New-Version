namespace Application.Features.Fuels.Queries.GetAll
{
	/// <summary>
	/// Объект модели представления данных по топливу.
	/// </summary>
	public class GetAllFuelsViewModel
    {
		public required IList<FuelLookupDto> Fuels { get; set; }
	}
}
