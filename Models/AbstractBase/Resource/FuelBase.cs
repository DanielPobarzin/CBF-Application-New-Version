using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Resource;

public abstract class FuelBase : INotifyPropertyChanged
{
	private string typeFuel = "Твердое топилво";
	private string? brandFuel;
	private int id;
	private string? type; 
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
		get => typeFuel;
		set
		{
			if (!string.Equals(typeFuel, value, StringComparison.Ordinal))
				typeFuel = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// ID топлива в базе данных
	/// </summary>
	[Key]
	public int Id
	{
		get => id;
		set
		{
			if (!id.Equals(value))
				id = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Модель топлива (тип и месторождение)
	/// </summary>
	[Description("Модель топлива")]
	public string? BrandFuel
	{
		get => brandFuel;
		set
		{
			if (!string.Equals(brandFuel, value, StringComparison.Ordinal))
				brandFuel = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Марка топлива
	/// </summary>
	[Description("Марка топлива")]
	public string? Type
	{
		get => type;
		set
		{
			if (!string.Equals(type, value, StringComparison.Ordinal))
				type = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Низшая теплота сгорания
	/// </summary>
	[Description("Низшая теплота сгорания Q, МДж/кг")]
	public double LowerHeatCombustion
	{
		get => lowerHeatCombustion;
		set
		{
			if (!lowerHeatCombustion.Equals(value))
				lowerHeatCombustion = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Серность
	/// </summary>
	[Description("Серность S, %")]
	public double SulfurContent
	{
		get => sulfurContent;
		set
		{
			if (!sulfurContent.Equals(value))
				sulfurContent = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Зольность
	/// </summary>
	[Description("Зольность А, %")]
	public double AshContent
	{
		get => ashContent;
		set
		{
			if (!ashContent.Equals(value))
				ashContent = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Влажность
	/// </summary>
	[Description("Влажность W, %")]
	public double Humidity
	{
		get => humidity;
		set
		{
			if (!humidity.Equals(value))
				humidity = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Содержание азота
	/// </summary>
	[Description("Содержание азота N, %")]
	public double NContent
	{
		get => nContent;
		set
		{
			if (!nContent.Equals(value))
				nContent = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Теоретический объем воздуха
	/// </summary>
	[Description("Теоретический объем воздуха Vв, м³/кг")]
	public double TheoreticalAirVolume
	{
		get => theoreticalAirVolume;
		set
		{
			if (!theoreticalAirVolume.Equals(value))
				theoreticalAirVolume = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Теоретический объем газа
	/// </summary>
	[Description("Теоретический объем газа Vг, м³/кг")]
	public double TheoreticalVolumeGas
	{
		get => theoreticalVolumeGas;
		set
		{
			if (!theoreticalVolumeGas.Equals(value))
				theoreticalVolumeGas = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	///  Теоретический объем водяных паров
	/// </summary>
	[Description("Теоретический объем водяных паров Vвпо, м³/кг")]
	public double TheoreticalVolumeWaterVapor
	{
		get => theoreticalVolumeWaterVapor;
		set
		{
			if (!theoreticalVolumeWaterVapor.Equals(value))
				theoreticalVolumeWaterVapor = value;
			OnPropertyChanged();
		}
	}

	#region implementation INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	#endregion
}