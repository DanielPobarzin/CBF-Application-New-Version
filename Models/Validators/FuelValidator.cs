using FluentValidation;
using Models.Entities.HeatPowerPlant.Resources;

namespace Models.Validators
{
	public class FuelValidator : AbstractValidator<Fuel>
	{
		public FuelValidator()
		{
			RuleFor(fuel => fuel.BrandFuel)
				.NotEmpty().WithMessage("Поле 'Бренд топлива' не может быть пустым.")
				.MaximumLength(50).WithMessage("Поле 'Бренд топлива' не может превышать 50 символов.");

			RuleFor(x => x.Type)
				.NotEmpty().WithMessage("Поле 'Марка топлива' не может быть пустым.")
				.MaximumLength(10).WithMessage("Поле 'Тип топлива' не может превышать 10 символов.");

			RuleFor(fuel => fuel.LowerHeatCombustion)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Низшая теплота сгорания должна быть положительной.");

			RuleFor(fuel => fuel.SulfurContent)
				.NotNull()
				.InclusiveBetween(0, 100).WithMessage("Содержание серы должно быть от 0 до 100%.");

			RuleFor(fuel => fuel.AshContent)
				.NotNull()
				.InclusiveBetween(0, 100).WithMessage("Содержание золы должно быть от 0 до 100%.");

			RuleFor(fuel => fuel.Humidity)
				.NotNull()
				.InclusiveBetween(0, 100).WithMessage("Влажность должна быть от 0 до 100%.");

			RuleFor(fuel => fuel.NContent)
				.NotNull()
				.InclusiveBetween(0, 100).WithMessage("Содержание азота должно быть от 0 до 100%.");

			RuleFor(fuel => fuel.TheoreticalAirVolume)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Теоретический объем воздуха не должен быть отрицательным.");

			RuleFor(fuel => fuel.TheoreticalVolumeGas)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Теоретический объем газа не должен быть отрицательным.");

			RuleFor(fuel => fuel.TheoreticalVolumeWaterVapor)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Теоретический объем водяных паров не должен быть отрицательным.");

			RuleFor(fuel => fuel.MedianDiameterAsh)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Медианный диаметр золы не должен быть отрицательным.");

			RuleFor(fuel => fuel.ElectricalResistanceAsh)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Электрическое сопротивление золы не должно быть отрицательным.");

			RuleFor(fuel => fuel.ElectricFieldStrength)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Напряженность электрического поля не должна быть отрицательной.");
			RuleFor(fuel => fuel.CoefficientReverseCrown)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Коэффициент, учитывающий влияние обратной короны не должен быть отрицательным.");
		}
	}
}
