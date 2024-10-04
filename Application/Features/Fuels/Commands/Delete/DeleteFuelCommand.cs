using Application.Wrappers;
using MediatR;

namespace Application.Features.Fuels.Commands.Delete
{
	public class DeleteFuelCommand : IRequest<Response<int>>
	{
		public int ID { get; set; }
	}
}
