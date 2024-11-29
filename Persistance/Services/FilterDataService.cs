using Application.Features.EGM_Filters.Commands.Create;
using Application.Features.EGM_Filters.Commands.Delete;
using Application.Features.EGM_Filters.Commands.Update;
using Application.Features.EGM_Filters.Queries.GetAll;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Models.Commands;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Serilog;
using System.Collections.ObjectModel;

namespace Persistence.Services
{
	/// <summary>
	/// Служба для работы с данными фильтров, реализующая интерфейс <see cref="ICrudService{Filter}"/>.
	/// </summary>
	public class FilterDataService : ICrudService<Filter>
	{
		private readonly Lazy<RelayCommand> _getAllCommand;
		private readonly Lazy<RelayCommand> _deleteCommand;
		private readonly Lazy<RelayCommand> _updateCommand;
		private readonly Lazy<RelayCommand> _createCommand;
		private readonly Lazy<RelayCommand> _generalInsertCommand;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private ObservableCollection<Filter> BackupCollectionFilter { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FilterDataService"/>.
		/// </summary>
		/// <param name="mediator">Медиатор для обработки команд.</param>
		/// <param name="mapper">Маппер для преобразования объектов.</param>
		public FilterDataService(IMediator mediator, IMapper mapper)
		{
			BackupCollectionFilter = new ObservableCollection<Filter>();
			_mediator = mediator;
			_mapper = mapper;
			_getAllCommand = new Lazy<RelayCommand>(() => new RelayCommand(async _ 
				=> await GetAll()));
			_deleteCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await Delete(parameter)));
			_updateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await Update(parameter)));
			_createCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await Create(parameter)));
			_generalInsertCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) 
				=> await GeneralInsert(parameter)));
		}

		/// <summary>
		/// Получает команду для получения всех фильтров.
		/// </summary>
		public RelayCommand GetAllCommand => _getAllCommand.Value;

		/// <summary>
		/// Получает команду для удаления фильтра.
		/// </summary>
		public RelayCommand DeleteCommand => _deleteCommand.Value;

		/// <summary>
		/// Получает команду для обновления фильтра.
		/// </summary>
		public RelayCommand UpdateCommand => _updateCommand.Value;

		/// <summary>
		/// Получает команду для создания нового фильтра.
		/// </summary>
		public RelayCommand CreateCommand => _createCommand.Value;

		/// <summary>
		/// Получает команду для общего вставления фильтра.
		/// </summary>
		public RelayCommand GeneralInsertCommand => _generalInsertCommand.Value;

		/// <summary>
		/// Событие, которое вызывается при загрузке сущностей.
		/// </summary>
		public event Action<List<Filter>>? EntitiesLoaded;

		private async Task GetAll()
		{
			var filters = new List<Filter>();
			var query = new GetAllFiltersQuery();

			Log.Information("Getting filters data ...");
			var vm = await _mediator.Send(query);
			if (vm.Data.Filters != null)
				foreach (var filter in vm.Data.Filters)
				{
					filters.Add(_mapper.Map<Filter>(filter));
					BackupCollectionFilter.Add(_mapper.Map<Filter>(filter));
				}

			EntitiesLoaded?.Invoke(filters);
		}
		private async Task Delete(object parameter)
		{
			if (parameter is not Filter filterDto) return;
			var command = new DeleteFilterCommand
			{
				Id = filterDto.Id
			};
			Log.Information("Deleting filter data ...");
			await _mediator.Send(command);
		}
		private async Task Update(object parameter)
		{
			if (parameter is not Filter filterDto) return;
			var command = _mapper.Map<UpdateFilterCommand>(filterDto);
			Log.Information("Updating filter data ...");
			await _mediator.Send(command);
		}
		private async Task Create(object parameter)
		{
			if (parameter is not Filter filterDto) return;
			var command = _mapper.Map<CreateFilterCommand>(filterDto);
			Log.Information("Creating filter data ...");
			await _mediator.Send(command);
		}
		private async Task GeneralInsert(object parameter)
		{
			if (parameter is ObservableCollection<Filter> filterDto)
			{
				var newItems = filterDto
					.Where(n => BackupCollectionFilter
						.All(o => o.BrandFilter != n.BrandFilter))
					.ToList();
				foreach (var newItem in newItems)
				{
					CreateCommand.Execute(newItem);
					BackupCollectionFilter.Add(newItem);
				}
				var deletedItems = BackupCollectionFilter
					.Where(o => filterDto
						.All(n => n.Id != o.Id))
					.ToList();
				foreach (var deletedItem in deletedItems)
				{
					DeleteCommand.Execute(deletedItem);
					BackupCollectionFilter.Remove(deletedItem);
				}
				var updatedItems = filterDto.Where(n => BackupCollectionFilter.Any(o => o.Id == n.Id &&
				PropertiesChanged(o, n))).ToList();
				foreach (var updatedItem in updatedItems)
				{
					UpdateCommand.Execute(updatedItem);
					var oldItem = BackupCollectionFilter.FirstOrDefault(o => o.Id == updatedItem.Id);
					if (oldItem == null) continue;
					var index = BackupCollectionFilter.IndexOf(oldItem);
					BackupCollectionFilter[index] = updatedItem;
				}
			}
			await Task.CompletedTask;
		}
		private static bool PropertiesChanged<T>(T oldItem, T newItem)
		{
			var properties = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);

			foreach (var property in properties)
			{
				if (!property.CanRead || !property.CanWrite) continue;
				var oldValue = property.GetValue(oldItem);
				var newValue = property.GetValue(newItem);

				if (Equals(oldValue, newValue)) continue;
				Log.Information($"Property '{property.Name}' changed from '{oldValue}' to '{newValue}'");
				return true;
			}
			return false;
		}
	}
}