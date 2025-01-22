using Application.Wrappers;
using MediatR;

namespace Application.Features.EGM_Filters.Queries.GetAll
{
	/// <summary>
	/// Запрос для получения всех фильтров.
	/// </summary>
	public class GetAllFiltersQuery : IRequest<Response<GetAllFiltersViewModel>> { }
}
