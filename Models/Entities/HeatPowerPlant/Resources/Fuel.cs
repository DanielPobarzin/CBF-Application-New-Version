using Models.AbstractBase.Resource;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.Resources;

/// <summary>
/// Представляет топливо, используемое в процессе сжигания.
/// </summary>
/// <remarks>
/// Этот класс наследует от <see cref="FuelBase"/> и реализует интерфейс <see cref="IDataErrorInfo"/> для поддержки 
/// валидации данных. Он содержит свойства, описывающие характеристики топлива.
/// </remarks>
[Description("Топливо")]
public class Fuel : FuelBase, IDataErrorInfo
{

	private double medianDiameterAsh; 
	private double electricFieldStrength; 
	private double coefficientReverseCrown;
	private double electricalResistanceAsh;
	private FuelValidator? Validator { get; set; }

	/// <summary>
	/// Медианный диаметр золы
	/// </summary>
	[Description("Медианный диаметр золы d50, м")]
	public double MedianDiameterAsh
	{
		get => medianDiameterAsh;
		set
		{
			if (!medianDiameterAsh.Equals(value)) 
				medianDiameterAsh = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Напряженность электрического поля
	/// </summary>
	[Description("Напряженность электрического поля E, кВ/м")]
	public double ElectricFieldStrength
	{
		get => electricFieldStrength;
		set
		{
			if (!electricFieldStrength.Equals(value))
				electricFieldStrength = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Коэффициент, учитывающий влияние обратной короны
	/// </summary>
	[Description("Коэффициент, учитывающий влияние обратной короны")]
	public double CoefficientReverseCrown
	{
		get => coefficientReverseCrown;
		set
		{
			if (!coefficientReverseCrown.Equals(value))
				coefficientReverseCrown = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Электрическое сопротивление золы
	/// </summary>
	[Description("Удельное электрическое сопротивление золы, lg(p)")]
	public double ElectricalResistanceAsh
	{
		get => electricalResistanceAsh;
		set
		{
			if (!electricalResistanceAsh.Equals(value))
				electricalResistanceAsh = value;
			OnPropertyChanged();
		}
	}

	#region implementation IDataErrorInfo
	public string Error => throw new NotImplementedException();
	public string this[string columnName]
	{
		get
		{
			Validator ??= new FuelValidator();
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