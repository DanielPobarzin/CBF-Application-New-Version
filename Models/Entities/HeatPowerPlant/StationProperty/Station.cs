using Models.AbstractBase.Production;
using Models.Enums.Station;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.StationProperty
{
	/// <summary>
	/// Класс, представляющий параметры электростанции.
	/// </summary>
	/// <remarks>
	/// Этот класс наследует от <see cref="StationBase"/> и реализует интерфейс <see cref="IDataErrorInfo"/> для поддержки 
	/// валидации данных. Он содержит свойства, описывающие характеристики станции.
	/// </remarks> 
	[Description("Используемые параметры электростанции")]
	public class Station : StationBase, IDataErrorInfo
	{
		private StationValidator? Validator { get; set; }
		private string? mill; 
		private double fuelConsumption; 
		private SlagRemoval slagRemoval = 0; 
		private double exhaustGasTemperature; 
		private int numberSmokePumps; 
		private double airSuction;
		private TypeFlueGasSupply typeFlueGasSupply = 0;
		private int numberGrids; 
		private SchemeBunkerPartitions schemeBunkerPartitions = 0;
		private double heightLiftShaft; 

		

		/// <summary>
		/// Мельница пылеприготовления
		/// </summary>
		[Description("Мельница пылеприготовления")]
		public string Mill
		{
			get => mill!;
			set
			{
				if (!string.Equals(mill, value, StringComparison.Ordinal))
					mill = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Расход топлива
		/// </summary>
		[Description("Расход топлива В, кг/с")]
		public double FuelConsumption
		{
			get => fuelConsumption;
			set
			{
				if (!fuelConsumption.Equals(value))
					fuelConsumption = value;
				OnPropertyChanged();
				OnPropertyChanged(this[nameof(FuelConsumption)]);
			}
		}

		/// <summary>
		/// Тип шлакоудаления
		/// </summary>
		[Description("Тип шлакоудаления")]
		public SlagRemoval SlagRemoval
		{
			get => slagRemoval;
			set
			{
				if (!Equals(slagRemoval, value))
					slagRemoval = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Температура уходящих газов
		/// </summary>
		[Description("Температура уходящих газов, °C")]
		public double ExhaustGasTemperature
		{
			get => exhaustGasTemperature;
			set
			{
				if (!exhaustGasTemperature.Equals(value))
					exhaustGasTemperature = value;
				OnPropertyChanged();

			}
		}

		/// <summary>
		/// Количество дымососов
		/// </summary>
		[Description("Количество дымососов")]
		public int NumberSmokePumps
		{
			get => numberSmokePumps;
			set
			{
				if (!numberSmokePumps.Equals(value))
					numberSmokePumps = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Присосы воздуха
		/// </summary>
		[Description("Коэффициент избытка воздуха α")]
		public double AirSuction
		{
			get => airSuction;
			set
			{
				if (!airSuction.Equals(value))
					airSuction = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Тип подвода газа
		/// </summary>
		[Description("Тип подвода газа")]
		public TypeFlueGasSupply TypeFlueGasSupply
		{
			get => typeFlueGasSupply;
			set
			{
				if (!Equals(typeFlueGasSupply, value))
					typeFlueGasSupply = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Число решеток
		/// </summary>
		[Description("Число решеток")]
		public int NumberGrids
		{
			get => numberGrids;
			set
			{
				if (!numberGrids.Equals(value))
					numberGrids = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Схема бункерной перегородки
		/// </summary>
		[Description("Схема бункерной перегородки")]
		public SchemeBunkerPartitions SchemeBunkerPartitions
		{
			get => schemeBunkerPartitions;
			set
			{
				if (!Equals(schemeBunkerPartitions, value))
					schemeBunkerPartitions = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Высота подъемной шахты
		/// </summary>
		[Description("Высота подъемной шахты Н, м")]
		public double HeightLiftShaft
		{
			get => heightLiftShaft;
			set
			{
				if (!heightLiftShaft.Equals(value))
					heightLiftShaft = value;
				OnPropertyChanged();
			}
		}

		#region implemenation IDataErrorInfo
		public string Error => throw new NotImplementedException();
		public string this[string columnName]
		{
			get
			{
				Validator ??= new StationValidator();
				var firstOrDefault = Validator.Validate(this)
					.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
				return firstOrDefault?.ErrorMessage!;
			}
		}
		#endregion
	}
}
