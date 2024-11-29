using Application.Wrappers;
using MediatR;

namespace Application.Features.Fuels.Queries.GetAll
{
	/// <summary>
	/// Объект запроса на получение данных по топливу.
	/// </summary>
	public class GetAllFuelsQuery : IRequest<Response<GetAllFuelsViewModel>>
    {

    }
}
