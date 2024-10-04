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

namespace Persistance.Services
{
	public class FilterDataService : ICrudService<Filter>
	{
		private readonly Lazy<RelayCommand> _getAllCommand;
		private readonly Lazy<RelayCommand> _deleteCommand;
		private readonly Lazy<RelayCommand> _updateCommand;
		private readonly Lazy<RelayCommand> _createCommand;
		private readonly Lazy<RelayCommand> _generalInsertCommand;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private ObservableCollection<Filter> backupCollectionFilter { get; set; }

		public FilterDataService(IMediator mediator, IMapper mapper)
		{
			backupCollectionFilter = new();
			_mediator = mediator;
			_mapper = mapper;
			_getAllCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await GetAll()));
			_deleteCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Delete(parameter)));
			_updateCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Update(parameter)));
			_createCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await Create(parameter)));
			_generalInsertCommand = new Lazy<RelayCommand>(() => new RelayCommand(async (parameter) => await GeneralInsert(parameter)));
		}
		public RelayCommand GetAllCommand => _getAllCommand.Value;
		public RelayCommand DeleteCommand => _deleteCommand.Value;
		public RelayCommand UpdateCommand => _updateCommand.Value;
		public RelayCommand CreateCommand => _createCommand.Value;
		public RelayCommand GeneralInsertCommand => _generalInsertCommand.Value;
		public event Action<List<Filter>> EntitiesLoaded;

		private async Task<GetAllFiltersViewModel> GetAll()
		{
			var filters = new List<Filter>();
			var query = new GetAllFiltersQuery();

			Log.Information($"Getting filters data ...");
			var vm = await _mediator.Send(query);
			foreach (var filter in vm.Data.Filters)
			{
				filters.Add(_mapper.Map<Filter>(filter));
				backupCollectionFilter.Add(_mapper.Map<Filter>(filter));
			}
			EntitiesLoaded?.Invoke(filters);
			return vm.Data;
		}
		private async Task Delete(object parameter)
		{

			if (parameter is Filter filterDto)
			{
				var command = new DeleteFilterCommand
				{
					ID = filterDto.ID
				};
				Log.Information($"Deleting filter data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task Update(object parameter)
		{
			if (parameter is Filter filterDto)
			{
				var command = _mapper.Map<UpdateFilterCommand>(filterDto);
				Log.Information($"Updating filter data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task Create(object parameter)
		{
			if (parameter is Filter filterDto)
			{
				var command = _mapper.Map<CreateFilterCommand>(filterDto);
				Log.Information($"Creating filter data ...");
				await _mediator.Send(command);
			}
			return;
		}
		private async Task GeneralInsert(object parameter)
		{
			if (parameter is ObservableCollection<Filter> filterDto)
			{
				var newItems = filterDto.Where(n => !backupCollectionFilter.Any(o => o.BrandFilter == n.BrandFilter)).ToList();
				foreach (var newItem in newItems)
				{
					CreateCommand.Execute(newItem);
					backupCollectionFilter.Add(newItem);
				}
				var deletedItems = backupCollectionFilter.Where(o => !filterDto.Any(n => n.ID == o.ID)).ToList();
				foreach (var deletedItem in deletedItems)
				{
					DeleteCommand.Execute(deletedItem);
					backupCollectionFilter.Remove(deletedItem);
				}
				var updatedItems = filterDto.Where(n => backupCollectionFilter.Any(o => o.ID == n.ID &&
				PropertiesChanged(o, n))).ToList();
				foreach (var updatedItem in updatedItems)
				{
					UpdateCommand.Execute(updatedItem);
					var oldItem = backupCollectionFilter.FirstOrDefault(o => o.ID == updatedItem.ID);
					if (oldItem != null)
					{
						int index = backupCollectionFilter.IndexOf(oldItem);
						backupCollectionFilter[index] = updatedItem;
					}
				}
			}
			await Task.CompletedTask;
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