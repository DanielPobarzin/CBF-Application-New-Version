using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetAll;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Models.Commands;
using Models.Entities.HeatPowerPlant.Resources;
using Serilog;
using System.Collections.ObjectModel;

namespace Persistence.Services
{
	/// <summary>
	/// Служба для работы с данными топлива, реализующая интерфейс <see cref="ICrudService{Fuel}"/>.
	/// </summary>
	public class FuelDataService : ICrudService<Fuel>
	{
		private readonly Lazy<RelayCommand> _getAllCommand;
		private readonly Lazy<RelayCommand> _deleteCommand;
		private readonly Lazy<RelayCommand> _updateCommand;
		private readonly Lazy<RelayCommand> _createCommand;
		private readonly Lazy<RelayCommand> _generalInsertCommand;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private ObservableCollection<Fuel> BackupCollectionFuel { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FuelDataService"/>.
		/// </summary>
		/// <param name="mediator">Медиатор для обработки команд.</param>
		/// <param name="mapper">Маппер для преобразования объектов.</param>
		public FuelDataService(IMediator mediator, IMapper mapper)
		{
			BackupCollectionFuel = new ObservableCollection<Fuel>();
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
		/// Получает команду для получения всех данных о топливе.
		/// </summary>
		public RelayCommand GetAllCommand => _getAllCommand.Value;

		/// <summary>
		/// Получает команду для удаления данных о топливе.
		/// </summary>
		public RelayCommand DeleteCommand => _deleteCommand.Value;

		/// <summary>
		/// Получает команду для обновления данных о топливе.
		/// </summary>
		public RelayCommand UpdateCommand => _updateCommand.Value;

		/// <summary>
		/// Получает команду для создания новых данных о топливе.
		/// </summary>
		public RelayCommand CreateCommand => _createCommand.Value;

		/// <summary>
		/// Получает команду для общего вставления данных о топливе.
		/// </summary>
		public RelayCommand GeneralInsertCommand => _generalInsertCommand.Value;

		/// <summary>
		/// Событие, которое вызывается при загрузке сущностей.
		/// </summary>
		public event Action<List<Fuel>>? EntitiesLoaded;
		private async Task GetAll()
		{
			var fuels = new List<Fuel>();
			var query = new GetAllFuelsQuery();

			Log.Information("Getting fuel data ...");
			var vm = await _mediator.Send(query);
			foreach (var fuel in vm.Data.Fuels)
			{
				fuels.Add(_mapper.Map<Fuel>(fuel));
				BackupCollectionFuel.Add(_mapper.Map<Fuel>(fuel));
			}
			EntitiesLoaded?.Invoke(fuels);
		}
		private async Task Delete(object parameter)
		{
			
			if (parameter is Fuel fuelDto)
			{
				var command = new DeleteFuelCommand
				{
					Id = fuelDto.Id
				};
				Log.Information("Deleting fuel data ...");
				await _mediator.Send(command);
			}
		}
		private async Task Update(object parameter)
		{
			if (parameter is Fuel fuelDto)
			{
				var command = _mapper.Map<UpdateFuelCommand>(fuelDto);
				Log.Information("Updating fuel data ...");
				await _mediator.Send(command);
			}
		}
		private async Task Create(object parameter)
		{
			if (parameter is not Fuel fuelDto) return;
			var command = _mapper.Map<CreateFuelCommand>(fuelDto);
			Log.Information("Creating fuel data ...");
			await _mediator.Send(command);
		}
		private async Task GeneralInsert(object parameter)
		{
			if (parameter is not ObservableCollection<Fuel> fuelDto) return;
			await Task.Run(() =>
			{
				var newItems = fuelDto
					.Where(n => BackupCollectionFuel
						.All(o => o.BrandFuel != n.BrandFuel))
					.ToList();
				foreach (var newItem in newItems)
				{
					CreateCommand.Execute(newItem);
					BackupCollectionFuel.Add(newItem);
				}
			});
			await Task.Run(() =>
			{
				var deletedItems = BackupCollectionFuel
					.Where(o => fuelDto
						.All(n => n.Id != o.Id))
					.ToList();
				foreach (var deletedItem in deletedItems)
				{
					DeleteCommand.Execute(deletedItem);
					BackupCollectionFuel.Remove(deletedItem);
				}
			});
			await Task.Run(() =>
			{
				var updatedItems = fuelDto
					.Where(n => BackupCollectionFuel
						.Any(o => o.Id == n.Id && PropertiesChanged(o, n)))
					.ToList();
				foreach (var updatedItem in updatedItems)
				{
					UpdateCommand.Execute(updatedItem);
					var oldItem = BackupCollectionFuel.FirstOrDefault(o => o.Id == updatedItem.Id);

					if (oldItem == null) continue;
					var index = BackupCollectionFuel.IndexOf(oldItem);
					BackupCollectionFuel[index] = updatedItem;
				}
			});
		}
		private static bool PropertiesChanged<T>(T oldItem, T newItem)
		{
			var properties = typeof(T)
				.GetProperties(System.Reflection.BindingFlags.Public 
				               | System.Reflection.BindingFlags.Instance 
				               | System.Reflection.BindingFlags.FlattenHierarchy);

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

