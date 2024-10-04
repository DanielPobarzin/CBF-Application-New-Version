using Application.Wrappers;
using MediatR;

namespace Application.Features.Fuels.Queries.GetAll
{
	public class GetAllFuelsQuery : IRequest<Response<GetAllFuelsViewModel>>
    {

    }
}
