using Models.AbstractBase.Equipment;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.EGM_Filters
{
	[Description("Электрофильтр")]
	public class Filter : FilterBase, IDataErrorInfo
    {
        private double areaActiveSection;
        private double activeFieldLength;
        private double totalDepositionArea;
        private double electrodeHeight;
        private double coefficientShakingMode;
        private int numberFields;
        private double distanceCPDevices;

        private FilterValidator validator { get; set; }

        public string Error { get; set; }

		/// <summary>
		/// Площадь активного сечения
		/// </summary>
		[Description("Площадь активного сечения ω, м²")]
		public double AreaActiveSection
        {
            get { return areaActiveSection; }
            set
            {
                if (areaActiveSection != value)
                    areaActiveSection = value;
                OnPropertyChanged(nameof(AreaActiveSection));
            }
        }

		/// <summary>
		///  Активная длина поля
		/// </summary>
		[Description("Активная длина поля Lₚ, м")]
		public double ActiveFieldLength
        {
            get { return activeFieldLength; }
            set
            {
                if (activeFieldLength != value)
                    activeFieldLength = value;
                OnPropertyChanged(nameof(ActiveFieldLength));
            }
        }

		/// <summary>
		/// Общая площадь осаждения
		/// </summary>
		[Description("Общая площадь осаждения А, м²")]
		public double TotalDepositionArea
        {
            get { return totalDepositionArea; }
            set
            {
                if (totalDepositionArea != value)
                    totalDepositionArea = value;
                OnPropertyChanged(nameof(TotalDepositionArea));
            }
        }

		/// <summary>
		/// Высота электрода
		/// </summary>
		[Description("Высота электрода, м")]
		public double ElectrodeHeight
        {
            get { return electrodeHeight; }
            set
            {
                if (electrodeHeight != value)
                    electrodeHeight = value;
                OnPropertyChanged(nameof(ElectrodeHeight));
            }
        }

		/// <summary>
		/// Коэффициент типа встряхивания
		/// </summary>
		[Description("Коэффициент режима встряхивания, Квс")]
		public double СoefficientShakingMode
        {
            get { return coefficientShakingMode; }
            set
            {
                if (coefficientShakingMode != value)
                    coefficientShakingMode = value;
                OnPropertyChanged(nameof(СoefficientShakingMode));
            }
        }

		/// <summary>
		/// Число полей
		/// </summary>
		[Description("Количество полей")]
		public int NumberFields
        {
            get { return numberFields; }
            set
            {
                if (numberFields != value)
                    numberFields = value;
                OnPropertyChanged(nameof(NumberFields));
            }
        }

		/// <summary>
		/// Расстояние между коронующим и осадительным устройствами
		/// </summary>
		[Description("Расстояние между коронирующем и осадительным электродом t, м")]
		public double DistanceCPDevices
        {
            get { return distanceCPDevices; }
            set
            {
                if (distanceCPDevices != value)
                    distanceCPDevices = value;
                OnPropertyChanged(nameof(DistanceCPDevices));
            }
        }
        public string this[string columnName]
        {
            get
            {
                if (validator == null)
                {
                    validator = new FilterValidator();
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


