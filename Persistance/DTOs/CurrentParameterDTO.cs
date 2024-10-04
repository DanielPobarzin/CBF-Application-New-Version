using Application.Interfaces.Services;
using Models.Entities.HeatPowerPlant.EGM_Filters;
using Models.Entities.HeatPowerPlant.Resources;
using Models.Entities.HeatPowerPlant.StationProperty;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Persistance.DTOs
{
	public class CurrentParameterDTO : ICurrentParameterDTO
	{
		private Filter _selectedFilter;
		private ObservableCollection<Fuel> _selectedFuels;
		private Station _currentPropertyStation;

		public CurrentParameterDTO()
		{
			_selectedFilter = new Filter();
			_selectedFuels = new ObservableCollection<Fuel>();
			_currentPropertyStation = new Station();
		}

		public Filter SelectedFilter
		{
			get { return _selectedFilter; }
			set
			{
				if (_selectedFilter != null && _selectedFilter != value)
					_selectedFilter = value;
					OnPropertyChanged(nameof(SelectedFilter));
			}
		}
		public ObservableCollection<Fuel> SelectedFuels
		{
			get { return _selectedFuels; }
			set
			{
				if (_selectedFuels != null && _selectedFuels != value)
					_selectedFuels = value;
					OnPropertyChanged(nameof(SelectedFuels));
			}
		}
		public Station CurrentPropertyStation
		{
			get { return _currentPropertyStation; }
			set
			{
				if (_currentPropertyStation != null && _currentPropertyStation != value)
					_currentPropertyStation = value;
					OnPropertyChanged(nameof(CurrentPropertyStation));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
