using Models.AbstractBase.Production;
using Models.Enums.Station;
using Models.Validators;
using System.ComponentModel;

namespace Models.Entities.HeatPowerPlant.StationProperty
{
	[Description("Используемые параметры электростанции")]
	public class Station : StationBase, IDataErrorInfo
	{
		private StationValidator validator { get; set; }
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

		public string Error { get; set; }

		/// <summary>
		/// Мельница пылеприготовления
		/// </summary>
		public string Mill
		{
			get { return mill; }
			set
			{
				if (mill!=value)
					mill = value;
					OnPropertyChanged(nameof(Mill));
			}
		}

		/// <summary>
		/// Расход топлива
		/// </summary>
		public double FuelConsumption
		{
			get { return fuelConsumption; }
			set
			{
				if (fuelConsumption != value)
					fuelConsumption = value;
					OnPropertyChanged(nameof(FuelConsumption));
			}
		}

		/// <summary>
		/// Тип шлакоудаления
		/// </summary>
		public SlagRemoval SlagRemoval
		{
			get { return slagRemoval; }
			set
			{
				if (slagRemoval != value)
					slagRemoval = value;
					OnPropertyChanged(nameof(SlagRemoval));
			}
		}

		/// <summary>
		/// Температура уходящих газов
		/// </summary>
		public double ExhaustGasTemperature
		{
			get { return exhaustGasTemperature; }
			set
			{
				if (exhaustGasTemperature != value)
					exhaustGasTemperature = value;
					OnPropertyChanged(nameof(ExhaustGasTemperature));

			}
		}

		/// <summary>
		/// Количество дымососов
		/// </summary>
		public int NumberSmokePumps
		{
			get { return numberSmokePumps; }
			set
			{
				if (numberSmokePumps != value)
					numberSmokePumps = value;
					OnPropertyChanged(nameof(NumberSmokePumps));
			}
		}

		/// <summary>
		/// Присосы воздуха
		/// </summary>
		public double AirSuction
		{
			get { return airSuction; }
			set
			{
				if (airSuction != value)
					airSuction = value;
					OnPropertyChanged(nameof(AirSuction));
			}
		}

		/// <summary>
		/// Тип подвода газа
		/// </summary>
		public TypeFlueGasSupply TypeFlueGasSupply
		{
			get { return typeFlueGasSupply; }
			set
			{
				if (typeFlueGasSupply!= value)
					typeFlueGasSupply = value;
					OnPropertyChanged(nameof(TypeFlueGasSupply));
			}
		}

		/// <summary>
		/// Число решеток
		/// </summary>
		public int NumberGrids
		{
			get { return numberGrids; }
			set
			{
				if (numberGrids != value)
					numberGrids = value;
					OnPropertyChanged(nameof(NumberGrids));
			}
		}

		/// <summary>
		/// Схема бункерной перегородки
		/// </summary>
		public SchemeBunkerPartitions SchemeBunkerPartitions
		{
			get { return schemeBunkerPartitions; }
			set
			{
				if (schemeBunkerPartitions != value)
					schemeBunkerPartitions = value;
					OnPropertyChanged(nameof(SchemeBunkerPartitions));
			}
		}

		/// <summary>
		/// Высота подъемной шахты
		/// </summary>
		public double HeightLiftShaft
		{
			get { return heightLiftShaft; }
			set
			{
				if (heightLiftShaft != value)
					heightLiftShaft = value;
					OnPropertyChanged(nameof(HeightLiftShaft));
			}
		}
		public string this[string columnName]
		{
			get
			{
				if (validator == null)
				{
					validator = new StationValidator();
				}
				var firstOrDefault = validator.Validate(this)
					.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
				return firstOrDefault?.ErrorMessage;
			}
		}
	}
}
