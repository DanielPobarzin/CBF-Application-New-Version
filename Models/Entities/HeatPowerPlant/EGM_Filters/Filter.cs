using Models.AbstractBase.Equipment;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.EGM_Filters;

/// <summary>
/// Представляет электрофильтр, используемый для очистки газов от твердых частиц.
/// </summary>
/// <remarks>
/// Этот класс наследует от <see cref="FilterBase"/> и реализует интерфейс <see cref="IDataErrorInfo"/> для поддержки 
/// валидации данных. Он содержит свойства, описывающие геометрические и эксплуатационные характеристики 
/// электрофильтра.
/// </remarks>
[Description("Электрофильтр")]
public class Filter : FilterBase, IDataErrorInfo
{
	private double areaActiveSection;
	private double activeFieldLength;
	private double totalDepositionArea;
	private double electrodeHeight;
	private double coefficientShakingMode;
	private int numberFields;
	private double distanceCpDevices;

	private FilterValidator? Validator { get; set; }

	/// <summary>
	/// Площадь активного сечения
	/// </summary>
	[Description("Площадь активного сечения ω, м²")]
	public double AreaActiveSection
	{
		get => areaActiveSection;
		set
		{
			if (!areaActiveSection.Equals(value))
				areaActiveSection = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Активная длина поля
	/// </summary>
	[Description("Активная длина поля Lₚ, м")]
	public double ActiveFieldLength
	{
		get => activeFieldLength;
		set
		{
			if (!activeFieldLength.Equals(value))
				activeFieldLength = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Общая площадь осаждения
	/// </summary>
	[Description("Общая площадь осаждения А, м²")]
	public double TotalDepositionArea
	{
		get => totalDepositionArea;
		set
		{
			if (!totalDepositionArea.Equals(value))
				totalDepositionArea = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Высота электрода
	/// </summary>
	[Description("Высота электрода, м")]
	public double ElectrodeHeight
	{
		get => electrodeHeight;
		set
		{
			if (!electrodeHeight.Equals(value))
				electrodeHeight = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Коэффициент типа встряхивания
	/// </summary>
	[Description("Коэффициент режима встряхивания, Квс")]
	public double CoefficientShakingMode
	{
		get => coefficientShakingMode;
		set
		{
			if (!coefficientShakingMode.Equals(value))
				coefficientShakingMode = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Число полей
	/// </summary>
	[Description("Количество полей")]
	public int NumberFields
	{
		get => numberFields;
		set
		{
			if (!numberFields.Equals(value))
				numberFields = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Расстояние между коронующим и осадительным устройствами
	/// </summary>
	[Description("Расстояние между коронирующем и осадительным электродом t, м")]
	public double DistanceCpDevices
	{
		get => distanceCpDevices;
		set
		{
			if (!distanceCpDevices.Equals(value))
				distanceCpDevices = value;
			OnPropertyChanged();
		}
	}

	#region implementation IDataErrorInfo

	public string Error => throw new NotImplementedException();
	public string this[string columnName]
	{
		get
		{
			Validator ??= new FilterValidator();
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
}