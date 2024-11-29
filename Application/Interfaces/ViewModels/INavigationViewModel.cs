using Models.Commands;

namespace Application.Interfaces.ViewModels
{
	public interface INavigationViewModel 
	{
		public RelayCommand HomeCommand { get; }
		public RelayCommand FiltersCommand { get; }
		public RelayCommand FuelsCommand { get; }
		public RelayCommand StationsCommand { get; }
		public RelayCommand CalculateCommand { get; }
		public RelayCommand ChartsCommand { get; }
		public object CurrentView {  get; set; }
		public Task NavigateToAsync<T>() where T : class;
		public RelayCommand CloseNavigationMenuCommand { get; }
		public RelayCommand OpenNavigationMenuCommand { get; }
		public RelayCommand MoveWindowCommand {  get; }	
	}
}
