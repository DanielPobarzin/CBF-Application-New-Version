using Models.Validators;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Models.Entities.CalculationFilterEfficiency;

/// <summary>
/// Представляет расчетные параметры, определяемые при расчете эффективности удаления золы в системах очистки газов.
/// </summary>
/// <remarks>
/// Этот класс реализует интерфейсы <see cref="INotifyPropertyChanged"/> и <see cref="IDataErrorInfo"/> для поддержки 
/// привязки данных и валидации. Он содержит свойства, описывающие различные параметры, влияющие на процесс 
/// фильтрации, такие как расход газа, скорость дымовых газов и коэффициенты, связанные с удалением золы.
/// </remarks>
[Description("Расчет")]
public class DefinedFilterParameters : INotifyPropertyChanged, IDataErrorInfo
{
	private CalculateValidator? Validator { get; set; }
	private string? useFuel;
	private double volumetricGasConsumption; 
	private double flueGasVelocity; 
	private double trateDriftAshParticles; 
	private double effectiveStrength;
	private double coefficientSecondaryEntrainmentTrappedAsh;  
	private double heightCoefficientElectrode; 
	private double parameterAshCollectionUniformVelocityField; 
	private double ashEmissionUniformVelocityField; 
	private double degreeAshCaptureUniformVelocityField; 
	private double passageAshTakingAccountUnevennessFieldVelocity;  
	private double coefficientRelativeIncreaseInfluenceUnevenness; 
	private double velocityDeviationAverageValue; 
	private double relativeHeightLiftingShaft; 
	private double passageAshTakingAccountGasLeaksZones;  
	private double passageAshInactiveZones; 
	private double degreeAshCapture; 
	private double ashConcentrationEntranceToFirstField; 
	private double amountAshFormedProductsMechanicalUnderBurning; 
	private double passageAshFirstField;  
	private double degreeAshCaptureFirstField; 
	private Dictionary<string, double>? optimalAshShakingMode; 
	private double optimalValueDustCapacity; 
	private double areaDepositionOneField;  
	private double numberGasesEnteringOneField;  
	private Dictionary<string, double>? ashConcentrationEntranceMthField;
	private Color colorResult;



	/// <summary>
	/// Цвет для графиков и выделения блоков
	/// </summary>
	public Color ColorResult
	{
		get => colorResult;
		set
		{
			if (!colorResult.Equals(value))
				colorResult = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Расчитываемое топливо
	/// </summary>
	public string? UseFuel
	{
		get => useFuel;
		set
		{
			if (!string.Equals(useFuel, value, StringComparison.Ordinal))
				useFuel = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Объемный расход газа
	/// </summary>
	[Description("Объемный расход газа Vг, м³/с")]
	public double VolumetricGasConsumption
	{
		get => volumetricGasConsumption;
		set
		{
			if (!volumetricGasConsumption.Equals(value))
				volumetricGasConsumption = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Скорость дымовых газов
	/// </summary>
	[Description("Скорость дымовых газов V, м/с")]
	public double FlueGasVelocity
	{
		get => flueGasVelocity;
		set
		{
			if (!flueGasVelocity.Equals(value))
				flueGasVelocity = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Скорость дрейфа частиц золы 
	/// </summary>
	[Description("Скорость дрейфа частиц золы v, м/с")]
	public double TrateDriftAshParticles
	{
		get => trateDriftAshParticles;
		set
		{
			if (!trateDriftAshParticles.Equals(value))
				trateDriftAshParticles = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Эффективная напряженность электрического поля
	/// </summary>
	[Description("Эффективная напряженность электрического поля Eэф, кВ/м")]
	public double EffectiveStrength
	{
		get => effectiveStrength;
		set
		{
			if (!effectiveStrength.Equals(value))
				effectiveStrength = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Коэффициент вторичного уноса уловленной золы
	/// </summary>
	[Description("Коэффициент вторичного уноса уловленной золы Кун")]
	public double CoefficientSecondaryEntrainmentTrappedAsh
	{
		get => coefficientSecondaryEntrainmentTrappedAsh;
		set
		{
			if (!coefficientSecondaryEntrainmentTrappedAsh.Equals(value))
				coefficientSecondaryEntrainmentTrappedAsh = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Коэффициент высоты электрода
	/// </summary>
	[Description("Коэффициент высоты электрода Kн")]
	public double HeightCoefficientElectrode
	{
		get => heightCoefficientElectrode;
		set
		{
			if (!heightCoefficientElectrode.Equals(value))
				heightCoefficientElectrode = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Параметр золоулавливания при РАВНОМЕРНОМ поле скоростей 
	/// </summary>
	[Description("Параметр золоулавливания при равномерном поле скоростей Пр")]
	public double ParameterAshCollectionUniformVelocityField
	{
		get => parameterAshCollectionUniformVelocityField;
		set
		{
			if (!parameterAshCollectionUniformVelocityField.Equals(value))
				parameterAshCollectionUniformVelocityField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Проскок золы при равномерном поле скоростей 
	/// </summary>
	[Description("Проскок золы при равномерном поле скоростей Рр")]
	public double AshEmissionUniformVelocityField
	{
		get => ashEmissionUniformVelocityField;
		set
		{
			if (!ashEmissionUniformVelocityField.Equals(value))
				ashEmissionUniformVelocityField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Степень улавливания золы при РАВНОМЕРНОМ поле скоростей 
	/// </summary>
	[Description("Степень улавливания золы при равномерном поле скоростей ηзу")]
	public double DegreeAshCaptureUniformVelocityField
	{
		get => degreeAshCaptureUniformVelocityField;
		set
		{
			if (!degreeAshCaptureUniformVelocityField.Equals(value))
				degreeAshCaptureUniformVelocityField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Проскок золы через электрофильтр с учетом НЕРАВНОМЕРНОСТИ поля 
	/// </summary>
	[Description("Проскок золы через электрофильтр с учетом неравномерности поля Pa")]
	public double PassageAshTakingAccountUnevennessFieldVelocity
	{
		get => passageAshTakingAccountUnevennessFieldVelocity;
		set
		{
			if (!passageAshTakingAccountUnevennessFieldVelocity.Equals(value))
				passageAshTakingAccountUnevennessFieldVelocity = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Коэффициент относительного увеличения влияния неравномерности
	/// </summary>
	[Description("Коэффициент относительного увеличения влияния неравномерности R")]
	public double CoefficientRelativeIncreaseInfluenceUnevenness
	{
		get => coefficientRelativeIncreaseInfluenceUnevenness;
		set
		{
			if (!coefficientRelativeIncreaseInfluenceUnevenness.Equals(value))
				coefficientRelativeIncreaseInfluenceUnevenness = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Значение квадрата отклонения скорости от среднего значения 
	/// </summary>
	[Description("Значение квадрата отклонения скорости от среднего значения Δucp^2")]
	public double SquareVelocityDeviationAverageValue
	{
		get => velocityDeviationAverageValue;
		set
		{
			if (!velocityDeviationAverageValue.Equals(value))
				velocityDeviationAverageValue = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Относительная высота подъемной шахты
	/// </summary>
	[Description("Относительная высота подъемной шахты H")]
	public double RelativeHeightLiftingShaft
	{
		get => relativeHeightLiftingShaft;
		set
		{
			if (!relativeHeightLiftingShaft.Equals(value))
				relativeHeightLiftingShaft = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Проскок золы через электрофильтр с учетом протечек газов через зоны 
	/// </summary>
	[Description("Проскок золы через электрофильтр с учетом протечек газов через зоны р")]
	public double PassageAshTakingAccountGasLeaksZones
	{
		get => passageAshTakingAccountGasLeaksZones;
		set
		{
			if (!passageAshTakingAccountGasLeaksZones.Equals(value))
				passageAshTakingAccountGasLeaksZones = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Проскок золы через неактивные зоны 
	/// </summary>
	[Description("Проскок золы через неактивные зоны рн")]
	public double PassageAshInactiveZones
	{
		get => passageAshInactiveZones;
		set
		{
			if (!passageAshInactiveZones.Equals(value))
				passageAshInactiveZones = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Степень улавливания золы
	/// </summary>
	[Description("Степень улавливания золы ηзу")]
	public double DegreeAshCapture
	{
		get => degreeAshCapture;
		set
		{
			if (!degreeAshCapture.Equals(value))
				degreeAshCapture = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Концентрация золы на входе в первое поле 
	/// </summary>
	[Description("Концентрация золы на входе в первое поле Свх1, г/м3")]
	public double AshConcentrationEntranceToFirstField
	{
		get => ashConcentrationEntranceToFirstField;
		set
		{
			if (!ashConcentrationEntranceToFirstField.Equals(value))
				ashConcentrationEntranceToFirstField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Количество образующейся золы и продуктов механического недожога топлива
	/// </summary>
	[Description("Kоличество образующейся золы и продуктов механического недожога топлива Мз, г/с")]
	public double AmountAshFormedProductsMechanicalUnderBurning
	{
		get => amountAshFormedProductsMechanicalUnderBurning;
		set
		{
			if (!amountAshFormedProductsMechanicalUnderBurning.Equals(value))
				amountAshFormedProductsMechanicalUnderBurning = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Проскок золы в первом поле 
	/// </summary>
	[Description("Проскок золы в первом поле Рп1")]
	public double PassageAshFirstField
	{
		get => passageAshFirstField;
		set
		{
			if (!passageAshFirstField.Equals(value))
				passageAshFirstField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Степень улавливания золы в первом поле 
	/// </summary>
	[Description("Cтепень улавливания золы в первом поле ηп1")]
	public double DegreeAshCaptureFirstField
	{
		get => degreeAshCaptureFirstField;
		set
		{
			if (!degreeAshCaptureFirstField.Equals(value))
				degreeAshCaptureFirstField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Оптимальный режим встряхивания золы для каждого поля
	/// </summary>
	[Description("Оптимальный режим встряхивания золы для каждого поля τ, с")]
	public Dictionary<string, double>? OptimalAshShakingMode
	{
		get => optimalAshShakingMode;
		set
		{
			optimalAshShakingMode ??= new Dictionary<string, double>();
			if (!Equals(optimalAshShakingMode, value))
				optimalAshShakingMode = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Оптимальное значение пылеемкости 
	/// </summary>
	[Description("Оптимальное значение пылеемкости m0, кг/м2")]
	public double OptimalValueDustCapacity
	{
		get => optimalValueDustCapacity;
		set
		{
			if (!optimalValueDustCapacity.Equals(value))
				optimalValueDustCapacity = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Площадь осаждения одного поля
	/// </summary>
	[Description("Площадь осаждения одного поля А, м2")]
	public double AreaDepositionOneField
	{
		get => areaDepositionOneField;
		set
		{
			if (!areaDepositionOneField.Equals(value))
				areaDepositionOneField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Количество газов, поступающих в одно поле 
	/// </summary>
	[Description("Количество газов, поступающих в одно поле Vп, м3/с")]
	public double NumberGasesEnteringOneField
	{
		get => numberGasesEnteringOneField;
		set
		{
			if (!numberGasesEnteringOneField.Equals(value))
				numberGasesEnteringOneField = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Концентрация золы на входе в m-тое поле
	/// </summary>
	[Description("Концентрация золы на входе в m-тое поле Свх m, г/м3")]
	public Dictionary<string, double>? AshConcentrationEntranceMthField
	{
		get => ashConcentrationEntranceMthField;
		set
		{
			ashConcentrationEntranceMthField ??= new Dictionary<string, double>();
			if (!Equals(ashConcentrationEntranceMthField, value))
				ashConcentrationEntranceMthField = value;
			OnPropertyChanged();
		}
	}

	# region implementation IDataErrorInfo
	public string Error => throw new NotImplementedException();
	public string this[string columnName]
	{
		get
		{
			Validator ??= new CalculateValidator();
			var propertyValue = GetType().GetProperty(columnName)?.GetValue(this);
			if (propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString()))
			{
				return null!;
			}
			var firstOrDefault = Validator.Validate(this)
				.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
			return firstOrDefault?.ErrorMessage!;
		}
	}
	#endregion

	#region implementation INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	#endregion
}