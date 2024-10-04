using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Equipment
{
	/// <summary>
	/// Базовая модель электрофильтра
	/// </summary>
	public abstract class FilterBase : INotifyPropertyChanged
	{
		private string brandFilter;
		private int id;
		private double weight; 
		private double length; 
		private double height; 
		private double width; 

		/// <summary>
		/// ID фильтра
		/// </summary>
		[Key]
		public int ID
		{
			get { return id; }
			set
			{
				if (value != id)
					id = value;
					OnPropertyChanged(nameof(ID));
			}
		}
		/// <summary>
		/// Модель фильтра
		/// </summary>
		[Description("Модель электрофильтра")]
		public string BrandFilter
		{
			get { return brandFilter; }
			set
			{
				if (value != brandFilter)
					brandFilter = value;
					OnPropertyChanged(nameof(BrandFilter));
			}
		}
		/// <summary>
		/// Масса фильтра
		/// </summary>
		[Description("Масса, т")]
		public double Weight
		{
			get { return weight; }
			set
			{
				if (value != weight)
					weight = value;
					OnPropertyChanged(nameof(Weight));
			}
		}
		/// <summary>
		/// Длина корпуса фильтра
		/// </summary>
		[Description("Длина корпуса, м")]
		public double Length
		{
			get { return length; }
			set
			{
				if (value != length)
					length = value;
					OnPropertyChanged(nameof(Length));
			}
		}
		/// <summary>
		/// Высота корпуса фильтра
		/// </summary>
		[Description("Высота корпуса, м")]
		public double Height
		{
			get { return height; }
			set
			{
				if (value != height)
					height = value;
					OnPropertyChanged(nameof(Height));
			}
		}
		/// <summary>
		/// Ширина корпуса фильтра
		/// </summary>
		[Description("Ширина корпуса, м")]
		public double Width
		{
			get { return width; }
			set
			{
				if (value != width)
					width = value;
					OnPropertyChanged(nameof(Width));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
