   M S B A M L   `   `   `  ����E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels  5       FilterApplication#   FilterApplication.View.Charts   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k	 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t
 pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q  mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r! nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q" mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s# oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r$ nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q% mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a& ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k' gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q( mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l) hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#   	 
                        ! " # $ % & ' ( ) 5      �
viewModels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels#   	 
                        ! " # $ % & ' ( ) 5      6  0Telerik.Windows.Controls.Diagrams.DiagramSurface    IsVirtualizing$
  True��5         	PageStyle#��[  5      .��5      � 
������ .+�5   
   �� ���#212529���#3A4149$��5q�5   
    �� CornerRadius$ 8,8,0,8��5   
   ._�5      �� $
��Auto=�6    %� IsVirtualizing$
 True��6>    %� VirtualizationMode$ 	Recycling=�6k   .��5      �  � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $
��0.8* �6(   .+�5      � $��0��6    5      �� 5      $
��0.1* �6,   �� 5      $��1* �6,   �� 5      $
��0.1* �6,   .+�5       �� $��0��6$   $��20q�61   $��Century Gothic)�6=   $��Italic$�6Y   $��Center=�6l    �� TextAlignment$ Center=�6�   $
��Wrap=�6�   $��18(�6�   $��Center=�6�   
�������/-Степени золоулавливания6  0 	 *Telerik.Windows.Controls.RadCartesianChart  5!      -   5        $��ChartDegreeAsh��5!   a   $
  True��64   $	��300��6w   $��1��6�   $��10q�6�   $��Stretch=�6�   $��Stretch=�6�      HorizontalAxis 5"      8 	 2Telerik.Windows.Controls.ChartView.CategoricalAxis  5#   "   - 	 'Telerik.Windows.Controls.ChartView.Axis   LabelInterval$ 1��6:      PlotMode$ BetweenTicks=�6L   	   LabelFitMode$	 Rotate=�6d   
   
LabelStyle
 5$   &   �� 5%   *    �� 
TargetType" ��60   .�5&   .   ��  �� Property � �� �� Value$ 80��6I   �� 5'   .    � ��$ 40��6J   �� 5(   .    � ��
 �����6K   �� 5)   .    � ��$ 11(�6I   �� 5*   .    � ��$ Century Gothic)�6K   �� 5+   .    � ��$
 Wrap=�6M   5,   +   5.   #      VerticalAxis 50      3 	 -Telerik.Windows.Controls.ChartView.LinearAxis  51   "   6 	 0Telerik.Windows.Controls.ChartView.NumericalAxis   MinimumA 	 ;Telerik.Windows.Controls.Converters.StringToDoubleConverter$ 0 65      Maximum$ 1 6A      	MajorStep$	 0.2 6M   
 52   &   �� 53   *   " ��60   .�54   .   ��  � ��
 �����6K   �� 55   .    � ��$ 10(�6I   �� 56   .    � ��$ 20��6F   �� 57   .    � ��$ Right=�6T   �� 58   .    � ��$ Century Gothic)�6K   59   +   5;   #      Grid 5=      ; 	 5Telerik.Windows.Controls.ChartView.CartesianChartGrid  5>   "      MajorXLinesRenderMode$	 All=�6=      MajorLinesVisibility$ XY=�6Y   5?   #   5	 	 /Telerik.Windows.Controls.ChartView.RadChartBase 	  	Behaviors 5A      @
 	 :Telerik.Windows.Controls.ChartView.ChartPanAndZoomBehavior
  5B   "    
  ZoomMode$
 Both=�6B    
  PanMode$
 Both=�6R   ? 	 9Telerik.Windows.Controls.ChartView.ChartSelectionBehavior  5C   "   A  ;Telerik.Windows.Controls.Data.PropertyGrid.AutoBindBehavior   BindingModeOverride OneTime6A      Series. 5E      2 	 ,Telerik.Windows.Controls.ChartView.BarSeries     PaletteMode$ Series=�60   > 	 8Telerik.Windows.Controls.ChartView.CategoricalSeriesBase   CategoryBindingJ 	 DTelerik.Windows.Controls.ChartView.StringToDataPointBindingConverter$ UseFuel 6E   : 	 4Telerik.Windows.Controls.ChartView.CategoricalSeries   ValueBinding$ DegreeAshCapture 6_      CombineMode$
 None=�6   4 	 .Telerik.Windows.Controls.ChartView.ChartSeries   ItemsSource 6�   �� *	Results+< 	 6Telerik.Windows.Controls.ChartView.PointTemplateSeries   PointTemplate 5F   "   �� 5G   &   .R�5H   *   �� ��5I   .   �� 5J   2     �� Color  6B   �� *DataItem.ColorResult+5L   +   5M   '   5O      5P      5Q      � 5R      $��1��6    5S      �� 5T      $
��0.1* �6,   �� 5U      $��1* �6,   �� 5V      $
��0.1* �6,   �� 5W      .+�5Y      �� $��0��6$   $��20q�61   $��Century Gothic)�6=   $��Italic$�6Y   $��Center=�6l   $ Center=�6�   $
��Wrap=�6�   $��18(�6�   $��Center=�6�   
���������Значения концентрации золы на входе в каждое поле электрофильтра, г/м³6=    5Z      -   5        $��Chart��5Z   a   $
  True��64   $	��300��6n   $��1��6~   $��10q�6�   $��Stretch=�6�   $��Stretch=�6�    5[        5\   "   $ 1��6:   $ BetweenTicks=�6L   $	 Rotate=�6d   
 5]   &   �� 5^   *   " ��60   .�5_   .   ��  � ��$ 80��6I   �� 5`   .    � ��$ 40��6J   �� 5a   .    � ��
 �����6K   �� 5b   .    � ��$ 11(�6I   �� 5c   .    � ��$ Century Gothic)�6K   �� 5d   .    � ��$
 Wrap=�6M   5e   +   5g   #    5i        5j   "   $ 0 65   $ 50 6A   $ 5 6N   
 5k   &   �� 5l   *   " ��60   .�5m   .   ��  � ��
 �����6K   �� 5n   .    � ��$ 10(�6I   �� 5o   .    � ��$ 20��6F   �� 5p   .    � ��$ Right=�6T   �� 5q   .    � ��$ Century Gothic)�6K   5r   +   5t   #    5v        5w   "   $	 All=�6=   $ XY=�6Y   5x   #    5z      
  5{   "   $
 Both=�6B   $
 Both=�6R     5|   "    OneTime6A   ? 	 9Telerik.Windows.Controls.ChartView.ChartCrosshairBehavior  5}   "   . 5        $ 	DataPoint=�60   $	��100��6H   $ FuelName 6W   $ FirstFieldConcentration 6r   $
 None=�6�    6�   �� *	AllData+!   DefaultVisualStyle! 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� �	#FF53F0456G   5�   '   5�        5�      $ FuelName 60   $	��100��6K   $ SecondFieldConcentration 6Z   $
 None=�6�    6�   �� *	AllData+! 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� �	#FFD6DD446G   5�   '   5�        5�      $ FuelName 60   $	��100��6K   $ ThirdFieldConcentration 6Z   $
 None=�6�    6�   �� *	AllData+! 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� �	#FFE991296G   5�   '   5�        5�      $ FuelName 60   $	��100��6K   $ FourthFieldConcentration 6Z   $
 None=�6�    6�   �� *	AllData+! 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� �	#FF6A40056G   5�   '   5�        5�      $ FuelName 60   $	��100��6K   $ OutConcentration 6Z   $
 None=�6z    6�   �� *	AllData+! 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��
 �  ��6G   5�   '   5�      5�      �� 5�      $��3��6!   $��10q�6.   $��2��5�   #   $��50��5�   #   " J� Opacity$	" 0.8Q�5�   #   $��1q�5�   "   
����+��$ 15��5�   "   ���#3A4149._�5�      � $��10q�6#   # � ColumnDefinitions# 5�   "   �� 5�   &   $
��0.3* �67   �� 5�   &   $��1* �67   �� 5�   &   $
��0.3* �67   �� 5�   &   $��1* �67   �� 5�   &   $
��0.3* �67   �� 5�   &   $��1* �67   �� 5�   &   $
��0.3* �67   �� 5�   &   $��1* �67   �� 5�   &   $
��0.3* �67   �� 5�   &   $��1* �67   .+�5�   "   �� $��0��6,   ���	#FF53F045$��10��6M   $��10��6Y   �� 5�   "   $��1��6,   $��Century Gothic)�6<   $��Center=�6X   
�������$&�� На входе в поле №1��6�   $	��100��6�   $
��Wrap=�6�   �� 5�   "   $��2��6,   ���	#FFD6DD44$��10��6M   $��10��6Y   �� 5�   "   $��3��6,   $��Century Gothic)�6<   $��Center=�6X   
�������$&�� На входе в поле №2��6�   $
��Wrap=�6�   �� 5�   "   $��4��6,   ���	#FFE99129$��10��6M   $��10��6Y   �� 5�   "   $��5��6,   $��Century Gothic)�6<   $��Center=�6X   
�������$&�� На входе в поле №3��6�   $
��Wrap=�6�   �� 5�   "   $��6��6,   ���	#FF6A4005$��10��6M   $��10��6Y   �� 5�   "   $��7��6,   $��Century Gothic)�6<   $��Center=�6X   
�������$&�� На входе в поле №4��6�   $
��Wrap=�6�   �� 5�   "   $��8��6,   
���  ��$��10��6G   $��10��6S   �� 5�   "   $��9��6,   $��Century Gothic)�6<   $��Center=�6X   
�������$��На выходе��6�   $
��Wrap=�6�   5�      5�      5�      5�      5�      5�      5�      5�      