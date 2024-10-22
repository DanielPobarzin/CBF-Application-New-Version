using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Application.Parameters;
using Models.Enums.View;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FilterApplication.View
{
	/// <summary>
	/// Логика взаимодействия для Charts.xaml
	/// </summary>
	public partial class Charts : UserControl, IChartsView
	{
		private IChartViewModel _viewModel;
		private List<ColumnInfo> columnInfos;
		public Represantation View => Represantation.Charts;
		public Charts()
		{
			InitializeComponent();
			this.columnInfos = new List<ColumnInfo>
			{
				new("Топливо", stats => stats.FuelName),
				new("Поле №1", stats => stats.FirstFieldConcentration.ToString()),
				new("Поле №2", stats => stats.SecondFieldConcentration.ToString()),
				new("Поле №3", stats => stats.ThirdFieldConcentration.ToString()),
				new("Поле №4", stats => stats.FourthFieldConcentration.ToString()),
				new("Выход", stats => stats.OutConcentration.ToString())
			};
		}
		public void SetViewModel(IChartViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
		}
		private class ColumnInfo
		{
			internal string Header;
			internal Func<ConcentrationStatisticsReport, string> GetValue;

			internal ColumnInfo(string header, Func<ConcentrationStatisticsReport, string> valueGetter)
			{
				this.Header = header;
				this.GetValue = valueGetter;
			}
		}
	}
}
