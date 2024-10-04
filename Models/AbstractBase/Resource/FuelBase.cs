using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Resource
{
	public abstract class FuelBase : INotifyPropertyChanged
    {
		private string typeFuel = "Твердое топилво";
		private string brandFuel;
		private int id;
		private string type; 
		private double lowerHeatCombustion; 
		private double sulfurContent; 
		private double ashContent; 
		private double humidity; 
		private double nContent; 
		private double theoreticalAirVolume; 
		private double theoreticalVolumeGas; 
		private double theoreticalVolumeWaterVapor;

		/// <summary>
		/// Тип топлива
		/// </summary>
		public string TypeFuel
		{
			get { return typeFuel; }
			set
			{
				if (typeFuel != value)
					typeFuel = value;
				OnPropertyChanged(nameof(TypeFuel));
			}
		}

		/// <summary>
		/// ID топлива в базе данных
		/// </summary>
		[Key]
		public int ID
		{
			get { return id; }
			set
			{
				if (id != value)
					id = value;
					OnPropertyChanged(nameof(ID));
			}
		}

		/// <summary>
		/// Модель топлива (тип и месторождение)
		/// </summary>
		[Description("Модель топлива")]
		public string BrandFuel
		{
			get { return brandFuel; }
			set
			{
				if (brandFuel != value)
					brandFuel = value;
					OnPropertyChanged(nameof(BrandFuel));
			}
		}

		/// <summary>
		/// Марка топлива
		/// </summary>
		[Description("Марка топлива")]
		public string Type
		{
			get { return type; }
			set
			{
				if (type != value)
					type = value;
					OnPropertyChanged(nameof(Type));
			}
		}

		/// <summary>
		/// Низшая теплота сгорания
		/// </summary>
		[Description("Низшая теплота сгорания Q, МДж/кг")]
		public double LowerHeatCombustion
		{
			get { return lowerHeatCombustion; }
			set
			{
				if (lowerHeatCombustion != value)
					lowerHeatCombustion = value;
					OnPropertyChanged(nameof(LowerHeatCombustion));
			}
		}

		/// <summary>
		/// Серность
		/// </summary>
		[Description("Низшая теплота сгорания Q, МДж/кг")]
		public double SulfurContent
		{
			get { return sulfurContent; }
			set
			{
				if (sulfurContent != value)
					sulfurContent = value;
					OnPropertyChanged(nameof(SulfurContent));
			}
		}

		/// <summary>
		/// Зольность
		/// </summary>
		public double AshContent
		{
			get { return ashContent; }
			set
			{
				if (ashContent != value)
					ashContent = value;
					OnPropertyChanged(nameof(AshContent));
			}
		}

		/// <summary>
		///  Влажность
		/// </summary>
		public double Humidity
		{
			get { return humidity; }
			set
			{
				if (humidity != value)
					humidity = value;
					OnPropertyChanged(nameof(Humidity));
			}
		}

		/// <summary>
		///  Содержание азота
		/// </summary>
		public double NContent
		{
			get { return nContent; }
			set
			{
				if (nContent != value)
					nContent = value;
					OnPropertyChanged(nameof(NContent));
			}
		}

		/// <summary>
		///  Теоретический объем воздуха
		/// </summary>
		public double TheoreticalAirVolume
		{
			get { return theoreticalAirVolume; }
			set
			{
				if (theoreticalAirVolume != value)
					theoreticalAirVolume = value;
					OnPropertyChanged(nameof(TheoreticalAirVolume));
			}
		}

		/// <summary>
		///  Теоретический объем газа
		/// </summary>
		public double TheoreticalVolumeGas
		{
			get { return theoreticalVolumeGas; }
			set
			{
				if (theoreticalVolumeGas != value)
					theoreticalVolumeGas = value;
					OnPropertyChanged(nameof(TheoreticalVolumeGas));
			}
		}

		/// <summary>
		///  Теоретический объем водяных паров
		/// </summary>
		public double TheoreticalVolumeWaterVapor
		{
			get { return theoreticalVolumeWaterVapor; }
			set
			{
				if (theoreticalVolumeWaterVapor != value)
					theoreticalVolumeWaterVapor = value;
					OnPropertyChanged(nameof(TheoreticalVolumeWaterVapor));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
