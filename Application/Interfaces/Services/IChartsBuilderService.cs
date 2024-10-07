using Models.Commands;

namespace Application.Interfaces.Services
{
	public interface IChartsBuilderService
	{
		RelayCommand BuildCommand { get; }
		RelayCommand DrawCommand { get; }

		event Action BuildCreated;

	}
}
