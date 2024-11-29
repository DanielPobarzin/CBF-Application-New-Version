using AutoMapper;
using Models.Entities.HeatPowerPlant.Resources;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
	/// <summary>
	/// Репозиторий для работы с топливами в базе данных.
	/// Наследуется от <see cref="RepositoryAsync{TEntity, TContext}"/>.
	/// </summary>
	public class FuelRepository : RepositoryAsync<Fuel, ApplicationDbFuelContext>
	{
		private ApplicationDbFuelContext _context;
		private IMapper _mapper;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FuelRepository"/>.
		/// </summary>
		/// <param name="context">Контекст базы данных, используемый для доступа к топливам.</param>
		/// <param name="mapper">Объект для маппинга между сущностями и DTO.</param>
		public FuelRepository(ApplicationDbFuelContext context, IMapper mapper) : base(context)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}