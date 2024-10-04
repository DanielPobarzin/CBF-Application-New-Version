using Models.Commands;

namespace Application.Interfaces.Services
{
	public interface ICrudService<T> 
	{
		RelayCommand GetAllCommand { get; }
		RelayCommand DeleteCommand { get; }
		RelayCommand UpdateCommand { get; }
		RelayCommand CreateCommand { get; }
		RelayCommand GeneralInsertCommand { get; }
	    event Action<List<T>> EntitiesLoaded;
	}
}