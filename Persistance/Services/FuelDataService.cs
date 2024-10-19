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

namespace Persistance.Services
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
		private ObservableCollection<Fuel> backupCollectionFuel { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="FuelDataService"/>.
		/// </summary>
		/// <param name="mediator">Медиатор для обработки команд.</param>
		/// <param name="mapper">Маппер для преобразования объектов.</param>
		public FuelDataService(IMediator mediator, IMapper mapper)
		{
			backupCollectionFuel = new();
			_mediator = mediator;
			_mapper = mapper;
			_getAllCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await GetAll()));
			_deleteCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Delete(parameter)));
			_updateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Update(parameter)));
			_createCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Create(parameter)));
			_generalInsertCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await GeneralInsert(parameter)));
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
		public event Action<List<Fuel>> EntitiesLoaded;
		private async Task<GetAllFuelsViewModel> GetAll()
		{
			var fuels = new List<Fuel>();
			var query = new GetAllFuelsQuery();

			Log.Information($"Getting fuel data ...");
			var vm = await _mediator.Send(query);
			foreach (var fuel in vm.Data.Fuels)
			{
				fuels.Add(_mapper.Map<Fuel>(fuel));
				backupCollectionFuel.Add(_mapper.Map<Fuel>(fuel));
			}
			EntitiesLoaded?.Invoke(fuels);
			return vm.Data;
		}
		private async Task Delete(object parameter)
		{
			
			if (parameter is Fuel fuelDto)
			{
				var command = new DeleteFuelCommand
				{
					ID = fuelDto.ID
				};
				Log.Information($"Deleting fuel data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task Update(object parameter)
		{
			if (parameter is Fuel fuelDto)
			{
				var command = _mapper.Map<UpdateFuelCommand>(fuelDto);
				Log.Information($"Updating fuel data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task Create(object parameter)
		{
			if (parameter is Fuel fuelDto)
			{
				
				var command = _mapper.Map<CreateFuelCommand>(fuelDto);
				Log.Information($"Creating fuel data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task GeneralInsert(object parameter)
		{
			if (parameter is ObservableCollection<Fuel> fuelDto)
			{
				await Task.Run(() =>
				{
					var newItems = fuelDto.Where(n => !backupCollectionFuel.Any(o => o.BrandFuel == n.BrandFuel)).ToList();
					foreach (var newItem in newItems)
					{
						CreateCommand.Execute(newItem);
						backupCollectionFuel.Add(newItem);
					}
				});
				await Task.Run(() =>
				{
					var deletedItems = backupCollectionFuel.Where(o => !fuelDto.Any(n => n.ID == o.ID)).ToList();
					foreach (var deletedItem in deletedItems)
					{
						DeleteCommand.Execute(deletedItem);
						backupCollectionFuel.Remove(deletedItem);
					}
				});
				await Task.Run(() =>
				{
					var updatedItems = fuelDto.Where(n => backupCollectionFuel.Any(o => o.ID == n.ID &&
					PropertiesChanged(o, n))).ToList();
					foreach (var updatedItem in updatedItems)
					{
						UpdateCommand.Execute(updatedItem);
						var oldItem = backupCollectionFuel.FirstOrDefault(o => o.ID == updatedItem.ID);

						if (oldItem != null)
						{
							int index = backupCollectionFuel.IndexOf(oldItem);
							backupCollectionFuel[index] = updatedItem;
						}
					}
				});
			}
			return;
		}
		private bool PropertiesChanged<T>(T oldItem, T newItem)
		{
			var properties = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);

			foreach (var property in properties)
			{
				if (property.CanRead && property.CanWrite)
				{
					var oldValue = property.GetValue(oldItem);
					var newValue = property.GetValue(newItem);

					if (!Equals(oldValue, newValue))
					{
						Log.Information($"Property '{property.Name}' changed from '{oldValue}' to '{newValue}'");
						return true;
					}
				}
			}
			return false;
		}
	}

}

