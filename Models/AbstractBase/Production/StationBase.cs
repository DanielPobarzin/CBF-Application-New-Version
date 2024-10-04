using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.AbstractBase.Production
{
	public abstract class StationBase : INotifyPropertyChanged
    {
		private string typeStation = "ТЭС";
		public string TypeStation
		{
			get { return typeStation; }
			set
			{
				if (typeStation != value)
					typeStation = value;
					OnPropertyChanged(nameof(TypeStation));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
