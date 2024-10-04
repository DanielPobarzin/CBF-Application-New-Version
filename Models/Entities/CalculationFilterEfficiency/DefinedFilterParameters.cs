using Models.Validators;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.Entities.CalculationFilterEfficiency
{
	public class DefinedFilterParameters : INotifyPropertyChanged, IDataErrorInfo
	{
		private CalculateValidator validator { get; set; }
		private string useFuel;
		private double volumetricGasConsumption; 
		private double flueGasVelocity; 
		private double trateDriftAshParticles; 
		private double effectiveStrength;
		private double coeffSecondaryEntrainmentTrappedAsh;  
		private double heightCoefficientElectrode; 
		private double parameterAshCollectionUNIFORMVelocityField; 
		private double ashEmissionUniformVelocityField; 
		private double degreeAshCaptureUNIFORMVelocityField; 
		private double passageAshTakingAccountUNEVENNESSFieldVelocity;  
		private double coeffRelativeIncreaseInfluenceUnevenness; 
		private double squareVelocityDeviationAverageValue; 
		private double relativeHeightLiftingShaft; 
		private double passageAshTakingAccountGasLeaksZones;  
		private double passageAshInactiveZones; 
		private double degreeAshCapture; 
		private double ashConcentrationEntranceToFirstField; 
		private double amountAshFormedProductsMechanicalUnderburning; 
		private double passageAshFirstField;  
		private double degreeAshCaptureFirstField; 
		private List<double> optimalAshShakingMode; 
		private double optimalValueDustCapacity; 
		private double areaDepositionOneField;  
		private double numberGasesEnteringOneField;  
		private List<double> ashConcentrationEntranceMthField;

		public string Error { get; set; }

		/// <summary>
		/// Расчитываемое топливо
		/// </summary>
		[Description("Топливо, используемое в расчете")]
		public string UseFuel
		{
			get { return useFuel; }
			set
			{
				if (useFuel != value)
					useFuel = value;
				OnPropertyChanged(nameof(UseFuel));
			}
		}
		/// <summary>
		/// Объемный расход газа
		/// </summary>
		public double VolumetricGasConsumption
		{
			get { return volumetricGasConsumption; }
			set
			{
				if (volumetricGasConsumption != value)
					volumetricGasConsumption = value;
				OnPropertyChanged(nameof(VolumetricGasConsumption));
			}
		}
		/// <summary>
		/// Скорость дымовых газов
		/// </summary>
		public double FlueGasVelocity
		{
			get { return flueGasVelocity; }
			set
			{
				if (flueGasVelocity != value)
					flueGasVelocity = value;
				OnPropertyChanged(nameof(FlueGasVelocity));
			}
		}
		/// <summary>
		/// Скорость дрейфа частиц золы 
		/// </summary>
		public double TrateDriftAshParticles
		{
			get { return trateDriftAshParticles; }
			set
			{
				if (trateDriftAshParticles != value)
					trateDriftAshParticles = value;
				OnPropertyChanged(nameof(TrateDriftAshParticles));
			}
		}
		/// <summary>
		/// Эффективная напряженность электрического поля
		/// </summary>
		public double EffectiveStrength
		{
			get { return effectiveStrength; }
			set
			{
				if (effectiveStrength != value)
					effectiveStrength = value;
				OnPropertyChanged(nameof(EffectiveStrength));
			}
		}
		/// <summary>
		/// Коэффициент вторичного уноса уловленной золы
		/// </summary>
		public double CoeffSecondaryEntrainmentTrappedAsh
		{
			get { return coeffSecondaryEntrainmentTrappedAsh; }
			set
			{
				if (coeffSecondaryEntrainmentTrappedAsh != value)
					coeffSecondaryEntrainmentTrappedAsh = value;
				OnPropertyChanged(nameof(CoeffSecondaryEntrainmentTrappedAsh));
			}
		}
		/// <summary>
		/// Коэффициент высоты электрода
		/// </summary>
		public double HeightCoefficientElectrode
		{
			get { return heightCoefficientElectrode; }
			set
			{
				if (heightCoefficientElectrode != value)
					heightCoefficientElectrode = value;
				OnPropertyChanged(nameof(HeightCoefficientElectrode));
			}
		}
		/// <summary>
		/// Параметр золоулавливания при РАВНОМЕРНОМ поле скоростей 
		/// </summary>
		public double ParameterAshCollectionUNIFORMVelocityField
		{
			get { return parameterAshCollectionUNIFORMVelocityField; }
			set
			{
				if (parameterAshCollectionUNIFORMVelocityField != value)
					parameterAshCollectionUNIFORMVelocityField = value;
				OnPropertyChanged(nameof(ParameterAshCollectionUNIFORMVelocityField));
			}
		}
		/// <summary>
		/// Проскок золы при равномерном поле скоростей 
		/// </summary>
		public double AshEmissionUniformVelocityField
		{
			get { return ashEmissionUniformVelocityField; }
			set
			{
				if (ashEmissionUniformVelocityField != value)
					ashEmissionUniformVelocityField = value;
				OnPropertyChanged(nameof(AshEmissionUniformVelocityField));
			}
		}
		/// <summary>
		/// Степень улавливания золы при РАВНОМЕРНОМ поле скоростей 
		/// </summary>
		public double DegreeAshCaptureUNIFORMVelocityField
		{
			get { return degreeAshCaptureUNIFORMVelocityField; }
			set
			{
				if (degreeAshCaptureUNIFORMVelocityField != value)
					degreeAshCaptureUNIFORMVelocityField = value;
				OnPropertyChanged(nameof(DegreeAshCaptureUNIFORMVelocityField));
			}
		}
		/// <summary>
		/// Проскок золы через электрофильтр с учетом НЕРАВНОМЕРНОСТИ поля 
		/// </summary>
		public double PassageAshTakingAccountUNEVENNESSFieldVelocity
		{
			get { return passageAshTakingAccountUNEVENNESSFieldVelocity; }
			set
			{
				if (passageAshTakingAccountUNEVENNESSFieldVelocity != value)
					passageAshTakingAccountUNEVENNESSFieldVelocity = value;
				OnPropertyChanged(nameof(PassageAshTakingAccountUNEVENNESSFieldVelocity));
			}
		}
		/// <summary>
		/// Коэффициент относительного увеличения влияния неравномерности
		/// </summary>
		public double CoeffRelativeIncreaseInfluenceUnevenness
		{
			get { return coeffRelativeIncreaseInfluenceUnevenness; }
			set
			{
				if (coeffRelativeIncreaseInfluenceUnevenness != value)
					coeffRelativeIncreaseInfluenceUnevenness = value;
				OnPropertyChanged(nameof(CoeffRelativeIncreaseInfluenceUnevenness));
			}
		}
		/// <summary>
		/// Значение квадрата отклонения скорости от среднего значения 
		/// </summary>
		public double SquareVelocityDeviationAverageValue
		{
			get { return squareVelocityDeviationAverageValue; }
			set
			{
				if (squareVelocityDeviationAverageValue != value)
					squareVelocityDeviationAverageValue = value;
				OnPropertyChanged(nameof(SquareVelocityDeviationAverageValue));
			}
		}
		/// <summary>
		/// Относительная высота подъемной шахты
		/// </summary>
		public double RelativeHeightLiftingShaft
		{
			get { return relativeHeightLiftingShaft; }
			set
			{
				if (relativeHeightLiftingShaft != value)
					relativeHeightLiftingShaft = value;
				OnPropertyChanged(nameof(RelativeHeightLiftingShaft));
			}
		}
		/// <summary>
		/// Проскок золы через электрофильтр с учетом протечек газов через зоны 
		/// </summary>
		public double PassageAshTakingAccountGasLeaksZones
		{
			get { return passageAshTakingAccountGasLeaksZones; }
			set
			{
				if (passageAshTakingAccountGasLeaksZones != value)
					passageAshTakingAccountGasLeaksZones = value;
				OnPropertyChanged(nameof(PassageAshTakingAccountGasLeaksZones));
			}
		}
		/// <summary>
		/// Проскок золы через неактивные зоны 
		/// </summary>
		public double PassageAshInactiveZones
		{
			get { return passageAshInactiveZones; }
			set
			{
				if (passageAshInactiveZones != value)
					passageAshInactiveZones = value;
				OnPropertyChanged(nameof(PassageAshInactiveZones));
			}
		}
		/// <summary>
		/// Степень улавливания золы
		/// </summary>
		public double DegreeAshCapture
		{
			get { return degreeAshCapture; }
			set
			{
				if (degreeAshCapture != value)
					degreeAshCapture = value;
				OnPropertyChanged(nameof(DegreeAshCapture));
			}
		}
		/// <summary>
		/// Концентрация золы на входе в первое поле 
		/// </summary>
		public double AshConcentrationEntranceToFirstField
		{
			get { return ashConcentrationEntranceToFirstField; }
			set
			{
				if (ashConcentrationEntranceToFirstField != value)
					ashConcentrationEntranceToFirstField = value;
				OnPropertyChanged(nameof(AshConcentrationEntranceToFirstField));
			}
		}
		/// <summary>
		/// Kоличество образующейся золы и продуктов механического недожога топлива
		/// </summary>
		public double AmountAshFormedProductsMechanicalUnderburning
		{
			get { return amountAshFormedProductsMechanicalUnderburning; }
			set
			{
				if (amountAshFormedProductsMechanicalUnderburning != value)
					amountAshFormedProductsMechanicalUnderburning = value;
				OnPropertyChanged(nameof(AmountAshFormedProductsMechanicalUnderburning));
			}
		}
		/// <summary>
		/// Проскок золы в первом поле 
		/// </summary>
		public double PassageAshFirstField
		{
			get { return passageAshFirstField; }
			set
			{
				if (passageAshFirstField != value)
					passageAshFirstField = value;
				OnPropertyChanged(nameof(PassageAshFirstField));
			}
		}
		/// <summary>
		/// Cтепень улавливания золы в первом поле 
		/// </summary>
		public double DegreeAshCaptureFirstField
		{
			get { return degreeAshCaptureFirstField; }
			set
			{
				if (degreeAshCaptureFirstField != value)
					degreeAshCaptureFirstField = value;
				OnPropertyChanged(nameof(DegreeAshCaptureFirstField));
			}
		}
		/// <summary>
		/// Оптимальный режим встряхивания золы для каждого поля
		/// </summary>
		public List<double> OptimalAshShakingMode
		{
			get { return optimalAshShakingMode; }
			set
			{
				optimalAshShakingMode ??= new List<double>();
				if (optimalAshShakingMode != value)
					optimalAshShakingMode = value;
				OnPropertyChanged(nameof(OptimalAshShakingMode));
			}
		}
		/// <summary>
		/// Оптимальное значение пылеемкости 
		/// </summary>
		public double OptimalValueDustCapacity
		{
			get { return optimalValueDustCapacity; }
			set
			{
				if (optimalValueDustCapacity != value)
					optimalValueDustCapacity = value;
				OnPropertyChanged(nameof(OptimalValueDustCapacity));
			}
		}
		/// <summary>
		/// Площадь осаждения одного поля
		/// </summary>
		public double AreaDepositionOneField
		{
			get { return areaDepositionOneField; }
			set
			{
				if (areaDepositionOneField != value)
					areaDepositionOneField = value;
				OnPropertyChanged(nameof(AreaDepositionOneField));
			}
		}
		/// <summary>
		/// Количество газов, поступающих в одно поле 
		/// </summary>
		public double NumberGasesEnteringOneField
		{
			get { return numberGasesEnteringOneField; }
			set
			{
				if (numberGasesEnteringOneField != value)
					numberGasesEnteringOneField = value;
				OnPropertyChanged(nameof(NumberGasesEnteringOneField));
			}
		}
		/// <summary>
		/// Концентрация золы на входе в m-тое поле
		/// </summary>
		public List<double> AshConcentrationEntranceMthField
		{
			get { return ashConcentrationEntranceMthField; }
			set
			{
				ashConcentrationEntranceMthField ??= new List<double>();
				if (ashConcentrationEntranceMthField != value)
					ashConcentrationEntranceMthField = value;
				OnPropertyChanged(nameof(AshConcentrationEntranceMthField));
			}
		}

		public string this[string columnName]
		{
			get
			{
				if (validator == null)
				{
					validator = new CalculateValidator();
				}
				var propertyValue = GetType().GetProperty(columnName)?.GetValue(this);
				if (propertyValue == null || string.IsNullOrWhiteSpace(propertyValue.ToString()))
				{
					return null;
				}
				var firstOrDefault = validator.Validate(this)
					.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
				return firstOrDefault?.ErrorMessage;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
