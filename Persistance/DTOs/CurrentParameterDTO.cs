using Application.Interfaces.Services;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Persistence.DTOs
{
	/// <summary>
	/// Представляет текущие параметры, включая выбранный фильтр, выбранные виды топлива 
	/// и текущую станцию.
	/// </summary>
	public class CurrentParameterDto : ICurrentParameterDto
	{
		private Filter _selectedFilter;
		private ObservableCollection<Fuel> _selectedFuels;
		private Station _currentPropertyStation;

		/// <summary>
		/// Создает глубокую копию текущего экземпляра <see cref="CurrentParameterDto"/>.
		/// </summary>
		/// <returns>Новая глубокая копия текущего объекта <see cref="CurrentParameterDto"/>.</returns>
		public CurrentParameterDto DeepCopy()
		{
			return new CurrentParameterDto
			{
				SelectedFilter = this.SelectedFilter,
				SelectedFuels = this.SelectedFuels,
				CurrentPropertyStation = this.CurrentPropertyStation
			};
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CurrentParameterDto"/> 
		/// с пустыми значениями для фильтра, видов топлива и станции.
		/// </summary>
		public CurrentParameterDto()
		{
			_selectedFilter = new Filter();
			_selectedFuels = new ObservableCollection<Fuel>();
			_currentPropertyStation = new Station();
		}

		/// <summary>
		/// Получает или устанавливает выбранный фильтр.
		/// </summary>
		public Filter SelectedFilter
		{
			get => _selectedFilter;
			set
			{
				if (!Equals(_selectedFilter, value))
					_selectedFilter = value;
				OnPropertyChanged(nameof(SelectedFilter));
			}
		}

		/// <summary>
		/// Получает или устанавливает коллекцию топлив.
		/// </summary>
		public ObservableCollection<Fuel> SelectedFuels
		{
			get => _selectedFuels;
			set
			{
				_selectedFuels = value;
				OnPropertyChanged(nameof(SelectedFuels));
			}
		}

		/// <summary>
		/// Получает или устанавливает параметры станции.
		/// </summary>
		public Station CurrentPropertyStation
		{
			get => _currentPropertyStation;
			set
			{
				_currentPropertyStation = value;
				OnPropertyChanged(nameof(CurrentPropertyStation));
			}
		}
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
