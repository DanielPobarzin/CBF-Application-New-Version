using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Equipment;

/// <summary>
/// Базовая модель электрофильтра
/// </summary>
public abstract class FilterBase : INotifyPropertyChanged
{
	private string? brandFilter;
	private int id;
	private double weight; 
	private double length; 
	private double height; 
	private double width; 

	/// <summary>
	/// ID фильтра
	/// </summary>
	[Key]
	public int Id
	{
		get => id;
		set
		{
			if (value == id)
				return;
			id = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Модель фильтра
	/// </summary>
	[Description("Модель электрофильтра")]
	public string? BrandFilter
	{
		get => brandFilter;
		set
		{
			if (value == brandFilter)
				return;
			brandFilter = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Масса фильтра
	/// </summary>
	[Description("Масса, т")]
	public double Weight
	{
		get => weight;
		set
		{
			if (value.Equals(weight))
				return;
			weight = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Длина корпуса фильтра
	/// </summary>
	[Description("Длина корпуса, м")]
	public double Length
	{
		get => length;
		set
		{
			if (!value.Equals(length))
				length = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Высота корпуса фильтра
	/// </summary>
	[Description("Высота корпуса, м")]
	public double Height
	{
		get => height;
		set
		{
			if (!value.Equals(height))
				height = value;
			OnPropertyChanged();
		}
	}
	/// <summary>
	/// Ширина корпуса фильтра
	/// </summary>
	[Description("Ширина корпуса, м")]
	public double Width
	{
		get => width;
		set
		{
			if (!value.Equals(width))
				width = value;
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