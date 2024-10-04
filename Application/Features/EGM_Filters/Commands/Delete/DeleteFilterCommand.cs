using Application.Wrappers;
using MediatR;

namespace Application.Features.EGM_Filters.Commands.Delete
{
	public class DeleteFilterCommand : IRequest<Response<int>>
	{
		public int ID { get; set; }
	}
}
