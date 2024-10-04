using Models.AbstractBase.Resource;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.Resources
{
	[Description("Топливо")]
	public class Fuel : FuelBase, IDataErrorInfo
	{

		private double medianDiameterAsh; 
		private double electricFieldStrength; 
		private double coefficientReverseCrown;
		private double electricalResistanceAsh;
		private FuelValidator validator { get; set; }
		public string Error { get; set; }

		/// <summary>
		/// Медианный диаметр золы
		/// </summary>
		public double MedianDiameterAsh
		{
			get { return medianDiameterAsh; }
			set
			{
				if (medianDiameterAsh != value) 
					medianDiameterAsh = value;
					OnPropertyChanged(nameof(MedianDiameterAsh));
			}
		}

		/// <summary>
		/// Напряженность электрического поля
		/// </summary>
		public double ElectricFieldStrength
		{
			get { return electricFieldStrength; }
			set
			{
				if (electricFieldStrength != value)
					electricFieldStrength = value;
					OnPropertyChanged(nameof(ElectricFieldStrength));
			}
		}

		/// <summary>
		/// Коэффициент, учитывающий влияние обратной короны
		/// </summary>
		public double CoefficientReverseCrown
		{
			get { return coefficientReverseCrown; }
			set
			{
				if (coefficientReverseCrown != value)
					coefficientReverseCrown = value;
					OnPropertyChanged(nameof(CoefficientReverseCrown));
			}
		}

		/// <summary>
		/// Электрическое сопротивление золы
		/// </summary>
		public double ElectricalResistanceAsh
		{
			get { return electricalResistanceAsh; }
			set
			{
				if (electricalResistanceAsh !=  value)
					electricalResistanceAsh = value;
					OnPropertyChanged(nameof(ElectricalResistanceAsh));
			}
		}

		public string this[string columnName]
		{
			get
			{
				if (validator == null)
				{
					validator = new FuelValidator();
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
	}
}