using Application.Wrappers;
using MediatR;

namespace Application.Features.Fuels.Commands.Delete
{
	/// <summary>
	/// Объект команды для удаления топлива.
	/// </summary>
	public class DeleteFuelCommand : IRequest<Response<int>>
	{
		public int ID { get; set; }
	}
}
