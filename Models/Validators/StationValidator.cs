using FluentValidation;
using Models.Entities.HeatPowerPlant.StationProperty;
using Models.Enums.Station;

namespace Models.Validators
{
	public class StationValidator : AbstractValidator<Station>
	{
		public StationValidator()
		{
			RuleFor(x => x.Mill)
				.Matches("^[a-zA-Z0-9а-яА-ЯёЁ\\s]+$").WithMessage("Имя модели мельницы не должно содержать специальных символов.");

			RuleFor(x => x.FuelConsumption)
				.NotEmpty().WithMessage("Расход топлива не указан.")
				.GreaterThanOrEqualTo(0).WithMessage("Расход топлива не может быть меньше нуля.");

			RuleFor(x => x.ExhaustGasTemperature)
				.NotEmpty().WithMessage("Температура отработавших газов не указана.")
				.GreaterThan(-273.15).WithMessage("Температура отработавших газов должна быть выше абсолютного нуля.");

			RuleFor(x => x.NumberSmokePumps)
				.NotEmpty().WithMessage("Количество дымососов не указано.")
				.GreaterThan(0).WithMessage("Количество дымососов должно быть больше 0.");

			RuleFor(x => x.AirSuction)
				.NotEmpty().WithMessage("Величина присососов воздуха не указана.")
				.GreaterThan(0).WithMessage("Величина присососов воздуха должна быть положительным числом.");

			RuleFor(x => x.NumberGrids)
				.NotEmpty().WithMessage("Количество решеток не указано.")
				.GreaterThan(0).WithMessage("Количество решеток должно быть больше 0.");

			RuleFor(x => x.HeightLiftShaft)
				.NotEmpty().WithMessage("Высота подъемной шахты не указана.")
				.GreaterThanOrEqualTo(0).WithMessage("Высота подъемной шахты должна быть положительной.");

			RuleFor(x => x.SchemeBunkerPartitions)
				.NotEmpty().WithMessage("Не выбрана схема бункерных перегородок.")
				.NotEqual(SchemeBunkerPartitions.None).WithMessage("Выберите необходимую схему бункерных перегородок на странице 'Станция'.");

			RuleFor(x => x.SlagRemoval)
				.NotEmpty().WithMessage("Не выбран тип шлакоудаления.")
				.NotEqual(SlagRemoval.None).WithMessage("Укажите тип шлакудаления на странице 'Станция'.");

			RuleFor(x => x.TypeFlueGasSupply)
			.NotEmpty().WithMessage("Не выбран тип подвода газа.")
			.NotEqual(TypeFlueGasSupply.None).WithMessage("Укажите тип подвода газа на странице 'Станция'.");

		}
	}
}
