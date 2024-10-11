using Application.Interfaces.Services;
using Application.Interfaces.ViewModels;
using Application.Wrappers;
using Models.Entities.CalculationFilterEfficiency;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace ViewModels.ViewModels
{
	public class ChartVM : ViewModelBase, IChartViewModel
	{
		private readonly IChartsBuilderService _chartsBuilderService;
		private readonly ICalculateService _calculateService;
		private List<RenderMode> _renderModes;
		private int _defaultRenderModeIndex;
		public ChartVM(ICalculateService calculateService, IChartsBuilderService chartsBuilderService)
		{
			_calculateService = calculateService;
			_chartsBuilderService = chartsBuilderService;
			bool isD2DAvailable = Direct2DRenderOptions.IsHardwareDeviceAvailable();
			this._renderModes = new List<RenderMode>()
			{
				new RenderMode("Default", new XamlRenderOptions()),
				new RenderMode("Bitmap", new BitmapRenderOptions()),
				new RenderMode("Direct2D", new Direct2DRenderOptions()) { IsAvailable = isD2DAvailable }
			};

			this.DefaultRenderModeIndex = isD2DAvailable ? 2 : 1;
		}
		public IEnumerable<RenderMode> RenderOptions
		{
			get
			{
				return this._renderModes;
			}
		}
		//public ObservableCollection<DependencyData> DependencyDegreeAshConsumptionAirSuction => _chartsBuilderService.DependencyDegreeAshConsumptionAirSuction;
		public ObservableCollection<DefinedFilterParameters> Results => _calculateService.Results;
		public int DefaultRenderModeIndex
		{
			get
			{
				return this._defaultRenderModeIndex;
			}
			set
			{
				this._defaultRenderModeIndex = value;
				this.OnPropertyChanged("DefaultRenderModeIndex");
			}
		}
		//public void LoadData()
		//{
		//	var AreaSeriesCollection = new ObservableCollection<AreaSeries>();

		//	foreach (var dependency in DependencyDegreeAshConsumptionAirSuction)
		//	{
		//		var areaSeries = new AreaSeries
		//		{
		//			ItemsSource = dependency.Data, // Предполагается, что у вас есть коллекция DataPoints
		//			CategoryBinding = "XValue", // Привязка к оси X
		//			ValueBinding = "Close", // Привязка к оси Y
		//			Fill = new SolidColorBrush(Color.FromArgb(38, 37, 25, 218)),
		//			Stroke = new SolidColorBrush(Color.FromArgb(255, 11, 189, 255)),
		//			StrokeThickness = 3,
		//			TrackBallTemplate = (DataTemplate)Application.Current.Resources["trackBallTemplate"],
		//			Cursor = Cursors.Hand
		//		};

		//		AreaSeriesCollection.Add(areaSeries);
		//	}
		//}
	}
	public class RenderMode
	{
		public RenderMode(string name, ChartRenderOptions options)
		{
			this.Name = name;
			this.RenderOptions = options;
			this.IsAvailable = true;
		}

		public string Name { get; set; }

		public bool IsAvailable { get; set; }

		public ChartRenderOptions RenderOptions { get; set; }
	}
}
