using FluentValidation;
using Models.Entities.CalculationFilterEfficiency;

namespace Models.Validators
{
	public class CalculateValidator :  AbstractValidator<DefinedFilterParameters>
	{
		public CalculateValidator() {
			RuleFor(x => x.VolumetricGasConsumption)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Объемный расход газа не может быть отрицательным. Проверьте исходные данные.");
			RuleFor(x => x.FlueGasVelocity)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Скорость дымовых газов не может быть отрицательной. Проверьте исходные данные.")
			.LessThanOrEqualTo(299792458).WithMessage("Скорость дымовых газов превысила скорость света. Чудеса да и только ...");
			RuleFor(x => x.TrateDriftAshParticles)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Скорость дрейфа частиц золы не может быть отрицательной. Проверьте исходные данные.")
			.LessThanOrEqualTo(299792458).WithMessage("Скорость дрейфа частиц золы превысила скорость света. Закройте программу и больше никогда ей не пользуйтесь ...");
			RuleFor(x => x.EffectiveStrength)
			.NotNull();
			RuleFor(x => x.CoefficientSecondaryEntrainmentTrappedAsh)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Коэффициент вторичного уноса уловленной золы отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.HeightCoefficientElectrode)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Коэффициент высоты электрода отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.ParameterAshCollectionUniformVelocityField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Параметр золоулавливания при равномерном поле скоростей отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.AshEmissionUniformVelocityField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Проскок золы при равномерном поле скоростей отрицательный. Проверьте исходные данные.")
			.LessThanOrEqualTo(1).WithMessage("Проскок золы при равномерном поле скоростей превысил 100%. Пожалуйста, не используйте такой фильтр ...");
			RuleFor(x => x.DegreeAshCaptureUniformVelocityField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Степень улавливания золы при равномерном поле скоростей отрицательная. Проверьте исходные данные.")
			.LessThanOrEqualTo(1).WithMessage("Степень улавливания золы при равномерном поле скоростей превысила 100%. Интересно, откуда столько золы ...");
			RuleFor(x => x.PassageAshTakingAccountUnevennessFieldVelocity)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Проскок золы через электрофильтр с учетом неравномерности поля отрицательный. Проверьте исходные данные.")
			.LessThanOrEqualTo(1).WithMessage("Проскок золы через электрофильтр с учетом неравномерности поля превысил 100%. Пожалуйста, не используйте такой фильтр ...");
			RuleFor(x => x.CoefficientRelativeIncreaseInfluenceUnevenness)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Коэффициент относительного увеличения влияния неравномерности отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.SquareVelocityDeviationAverageValue)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Квадрат отклонения скорости от среднего значения отрицательный. Ошибка в формулах. Обратитесь к разработчику");
			RuleFor(x => x.RelativeHeightLiftingShaft)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Относительная высота подъемной шахты отрицательная. Проверьте исходные данные.");
			RuleFor(x => x.PassageAshTakingAccountGasLeaksZones)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Проскок золы через электрофильтр с учетом протечек газов через зоны отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.PassageAshInactiveZones)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Проскок золы через через неактивные зоны отрицательный. Проверьте исходные данные.");
			RuleFor(x => x.DegreeAshCapture)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Степень улавливания золы отрицательная. Фильтр еще сверху своей золы накидывает ?")
			.LessThanOrEqualTo(1).WithMessage("Степень улавливания золы превысила 100%. Срочно патентуйте свое открытие!");
			RuleFor(x => x.AshConcentrationEntranceToFirstField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Концентрация золы на входе в первое поле отрицательная. Проверьте исходные данные.");
			RuleFor(x => x.OptimalAshShakingMode)
		   .NotNull()
		   .WithMessage("Оптимальный режим встряхивания не может быть null.")
		   .Must(x => x != null && x.Any())
		   .WithMessage("Оптимальный режим встряхивания для каждого поля не определен. Если изменение исходных данных не помогает, обратитесь к разработчику. Вероятно, есть ошибка в расчетах.");

			RuleForEach(x => x.OptimalAshShakingMode)
				.Must(pair => pair.Value >= 0)
				.WithMessage("Оптимальный режим встряхивания для каждого поля должен быть неотрицательным.");
			RuleFor(x => x.OptimalValueDustCapacity)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Опитимальное значение пылеемкости отрицательное. Проверьте исходные данные.");
			RuleFor(x => x.AreaDepositionOneField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Площадь осаждения одного поля отрицательная. Проверьте исходные данные.");
			RuleFor(x => x.NumberGasesEnteringOneField)
			.NotNull()
			.GreaterThanOrEqualTo(0).WithMessage("Количество газов, поступающих в одно поле, отрицательное. Проверьте исходные данные.");
			RuleFor(x => x.AshConcentrationEntranceMthField)
			.NotNull()
			.WithMessage("Концентрация золы на входе не может быть null.")
			.Must(x => x != null && x.Any())
			.WithMessage("Концентрация золы на входе не определена. Если изменение исходных данных не помогает, обратитесь к разработчику. Вероятно, есть ошибка в расчетах.");
			RuleForEach(x => x.AshConcentrationEntranceMthField)
				.Must(pair => pair.Value >= 0)
				.WithMessage("Концентрация золы на входе в поле отрицательная. Проверьте исходные данные.");
		}
	}
}