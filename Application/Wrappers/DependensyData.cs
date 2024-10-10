using System.Windows.Media;

namespace Application.Wrappers
{
	public class DependencyData
    {
        public string FuelName { get; set; }
		public Color FuelColor { get; set; }
		public Dictionary<double, double> Data { get; set; }
    }
}
