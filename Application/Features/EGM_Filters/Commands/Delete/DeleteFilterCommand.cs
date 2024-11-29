using Application.Wrappers;
using MediatR;

namespace Application.Features.EGM_Filters.Commands.Delete
{
	/// <summary>
	/// Объект команды для удаления фильтра по его ID.
	/// </summary>
	public class DeleteFilterCommand : IRequest<Response<int>>
	{
		public int Id { get; set; }
	}
}
