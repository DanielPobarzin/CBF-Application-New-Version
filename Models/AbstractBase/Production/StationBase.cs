using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Production;

public abstract class StationBase : INotifyPropertyChanged
{
	private string typeStation = "ТЭС";
	public string TypeStation
	{
		get => typeStation;
		set
		{
			if (!string.Equals(typeStation, value, StringComparison.Ordinal))
				typeStation = value;
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