using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Persistance.Presenters
{
	public class CalculatePresenter
	{
		private readonly ICalculateService _calculateService;
		private readonly ICurrentParameterDTO _currentParameterDTO;


		private static Style GetStyle_ElementBorder() {

			Style borderStyle = new Style(typeof(Border));
			borderStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(1)));
			borderStyle.Setters.Add(new Setter(Border.MinHeightProperty, 20.0));
			borderStyle.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
			borderStyle.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(21, 35, 53))));
			borderStyle.Setters.Add(new Setter(Border.BorderBrushProperty, new SolidColorBrush(Color.FromRgb(106, 139, 179))));
			return borderStyle;
		}
		private static Style GetStyle_HeaderBorder()
		{
			Style headerBorderStyle = new Style(typeof(Border));
			headerBorderStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(1)));
			headerBorderStyle.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
			headerBorderStyle.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(29, 49, 74))));
			headerBorderStyle.Setters.Add(new Setter(Border.BorderBrushProperty, new SolidColorBrush(Color.FromRgb(106, 139, 179))));
			return headerBorderStyle;
		}
		private static Style GetStyle_TextBlockHeader()
		{
			Style headerBorderStyle = new Style(typeof(Border));
			headerBorderStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(1)));
			headerBorderStyle.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
			headerBorderStyle.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(29, 49, 74))));
			headerBorderStyle.Setters.Add(new Setter(Border.BorderBrushProperty, new SolidColorBrush(Color.FromRgb(106, 139, 179))));
			return headerBorderStyle;
		}
	}
}
