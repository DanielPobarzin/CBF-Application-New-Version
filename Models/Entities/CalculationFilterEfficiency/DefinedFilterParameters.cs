﻿using Models.Validators;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Models.Entities.CalculationFilterEfficiency
{
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
		private Dictionary<string, double> optimalAshShakingMode; 
		private double optimalValueDustCapacity; 
		private double areaDepositionOneField;  
		private double numberGasesEnteringOneField;  
		private Dictionary<string, double> ashConcentrationEntranceMthField;
		private Color colorResult;
		public string Error { get; set; }


		/// <summary>
		/// Цвет для графиков и выделения блоков
		/// </summary>
		public Color ColorResult
		{
			get { return colorResult; }
			set
			{
				if (colorResult != value)
					colorResult = value;
				OnPropertyChanged(nameof(ColorResult));
			}
		}
		/// <summary>
		/// Расчитываемое топливо
		/// </summary>
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
		[Description("Объемный расход газа Vг, м³/с")]
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
		[Description("Скорость дымовых газов V, м/с")]
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
		[Description("Скорость дрейфа частиц золы v, м/с")]
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
		[Description("Эффективная напряженность электрического поля Eэф, кВ/м")]
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
		[Description("Коэффициент вторичного уноса уловленной золы Кун")]
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
		[Description("Коэффициент высоты электрода Kн")]
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
		[Description("Параметр золоулавливания при равномерном поле скоростей Пр")]
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
		[Description("Проскок золы при равномерном поле скоростей Рр")]
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
		[Description("Степень улавливания золы при равномерном поле скоростей ηзу")]
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
		[Description("Проскок золы через электрофильтр с учетом неравномерности поля Pa")]
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
		[Description("Коэффициент относительного увеличения влияния неравномерности R")]
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
		[Description("Значение квадрата отклонения скорости от среднего значения Δucp^2")]
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
		[Description("Относительная высота подъемной шахты H")]
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
		[Description("Проскок золы через электрофильтр с учетом протечек газов через зоны р")]
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
		[Description("Проскок золы через неактивные зоны рн")]
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
		[Description("Степень улавливания золы ηзу")]
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
		[Description("Концентрация золы на входе в первое поле Свх1, г/м3")]
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
		[Description("Kоличество образующейся золы и продуктов механического недожога топлива Мз, г/с")]
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
		[Description("Проскок золы в первом поле Рп1")]
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
		[Description("Cтепень улавливания золы в первом поле ηп1")]
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
		[Description("Оптимальный режим встряхивания золы для каждого поля τ, с")]
		public Dictionary<string, double> OptimalAshShakingMode
		{
			get { return optimalAshShakingMode; }
			set
			{
				optimalAshShakingMode ??= new Dictionary<string, double>();
				if (optimalAshShakingMode != value)
					optimalAshShakingMode = value;
				OnPropertyChanged(nameof(OptimalAshShakingMode));
			}
		}
		/// <summary>
		/// Оптимальное значение пылеемкости 
		/// </summary>
		[Description("Оптимальное значение пылеемкости m0, кг/м2")]
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
		[Description("Площадь осаждения одного поля А, м2")]
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
		[Description("Количество газов, поступающих в одно поле Vп, м3/с")]
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
		[Description("Концентрация золы на входе в m-тое поле Свх m, г/м3")]
		public Dictionary<string, double> AshConcentrationEntranceMthField
		{
			get { return ashConcentrationEntranceMthField; }
			set
			{
				ashConcentrationEntranceMthField ??= new Dictionary<string, double>();
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
