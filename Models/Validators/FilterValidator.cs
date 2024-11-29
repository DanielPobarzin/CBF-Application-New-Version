using FluentValidation;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Models.Validators
{
    public class FilterValidator : AbstractValidator<Filter>
	{
		public FilterValidator()
		{
			RuleFor(x => x.BrandFilter)
				.NotEmpty().WithMessage("Модель фильтра не может быть пустой.");

			RuleFor(x => x.AreaActiveSection)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Площадь активного сечения не может быть отрицательной.");

			RuleFor(x => x.ActiveFieldLength)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Активная длина поля не может быть отрицательной.");

			RuleFor(x => x.TotalDepositionArea)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Общая площадь осаждения не может быть отрицательной.");

			RuleFor(x => x.Weight)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Масса не может быть отрицательной.");

			RuleFor(x => x.Length)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Длина не может быть отрицательной.");

			RuleFor(x => x.Height)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Высота не может быть отрицательной.");

			RuleFor(x => x.Width)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Ширина не может быть отрицательной.");

			RuleFor(x => x.ElectrodeHeight)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Высота электрода не может быть отрицательной.");

			RuleFor(x => x.CoefficientShakingMode)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Коэффициент типа встряхивания не может быть отрицательным.");

			RuleFor(x => x.NumberFields)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Число полей должно быть положительным.");

			RuleFor(x => x.DistanceCpDevices)
				.NotNull()
				.GreaterThanOrEqualTo(0).WithMessage("Расстояние между устройствами не может быть отрицательным.");

		}
	}
}