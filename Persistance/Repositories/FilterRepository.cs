using AutoMapper;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
	/// <summary>
	/// Репозиторий для работы с фильтрами в базе данных.
	/// Наследуется от <see cref="RepositoryAsync{TEntity, TContext}"/>.
	/// </summary>
	public class FilterRepository : RepositoryAsync<Filter, ApplicationDbFilterContext>
	{
		private ApplicationDbFilterContext _context;
		private IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FilterRepository"/>.
		/// </summary>
		/// <param name="context">Контекст базы данных, используемый для доступа к фильтрам.</param>
		/// <param name="mapper">Объект для маппинга между сущностями и DTO.</param>
		public FilterRepository(ApplicationDbFilterContext context, IMapper mapper) : base(context)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
