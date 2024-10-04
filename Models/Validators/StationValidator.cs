using FluentValidation;
using Models.Entities.HeatPowerPlant.StationProperty;

namespace Models.Validators
{
	public class StationValidator : AbstractValidator<Station>
	{
		public StationValidator()
		{
			RuleFor(x => x.Mill)
				.Matches("^[a-zA-Z0-9а-яА-ЯёЁ\\s]+$").WithMessage("Имя модели мельницы не должно содержать специальных символов.");

			RuleFor(x => x.FuelConsumption)
				.NotEmpty()
				.GreaterThanOrEqualTo(0).WithMessage("Расход топлива не может быть меньше нуля.");

			RuleFor(x => x.ExhaustGasTemperature)
				.NotEmpty()
				.GreaterThan(-273.15).WithMessage("Температура отработавших газов должна быть выше абсолютного нуля.");

			RuleFor(x => x.NumberSmokePumps)
				.NotEmpty()
				.GreaterThanOrEqualTo(0).WithMessage("Количество дымососов не может быть меньше нуля.");

			RuleFor(x => x.AirSuction)
				.NotEmpty()
				.GreaterThan(0).WithMessage("Величина присососов воздуха должна быть положительным числом.");

			RuleFor(x => x.NumberGrids)
				.NotEmpty()
				.GreaterThanOrEqualTo(0).WithMessage("Количество решеток не должно быть отрицательным.");

			RuleFor(x => x.HeightLiftShaft)
				.NotEmpty()
				.GreaterThanOrEqualTo(0).WithMessage("Высота подъемной шахты должна быть положительной.");
		}
	}
}
