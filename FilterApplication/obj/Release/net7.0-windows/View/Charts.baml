   M S B A M L   `   `   `  ���� E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels   FilterApplication#   FilterApplication.View.Charts   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k	 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t
 pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q  mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r! nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q" mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s# oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r$ nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q% mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a& ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k' gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q( mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l) hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#   	 
                        ! " # $ % & ' ( ) �
viewModels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels#   	 
                        ! " # $ % & ' ( ) 6  0Telerik.Windows.Controls.Diagrams.DiagramSurface    IsVirtualizing$
  True��   	PageStyle#��[  .��� 
������ .+��� ���#212529���#3A4149$��5q� �� CornerRadius$ 8,8,0,8��._��� $
��Auto=� %� IsVirtualizing$
 True�� %� VirtualizationMode$ 	Recycling=�.���  � RowDefinitions �� $��1* ��� $
��0.8* �.+�� $��0�� �� $
��0.1* ��� $��1* ��� $
��0.1* �.+��� $��0��$��20q�$��Century Gothic)�$��Italic$�$��Center=� �� TextAlignment$ Center=�$
��Wrap=�$��18(�$��Center=�
�������/-Степени золоулавливания0 	 *Telerik.Windows.Controls.RadCartesianChart  -   $��ChartDegreeAsh��$
  True��$	��300��$��1��$��10q�$��Stretch=�$��Stretch=�   HorizontalAxis 8 	 2Telerik.Windows.Controls.ChartView.CategoricalAxis  - 	 'Telerik.Windows.Controls.ChartView.Axis   LabelInterval$ 1��   PlotMode$ BetweenTicks=�	   LabelFitMode$	 Rotate=�
   
LabelStyle
 ��  �� 
TargetType" ��.���  �� Property � �� �� Value$ 80����  � ��$ 40����  � ��
 �������  � ��$ 11(���  � ��$ Century Gothic)���  � ��$
 Wrap=�   VerticalAxis 3 	 -Telerik.Windows.Controls.ChartView.LinearAxis  6 	 0Telerik.Windows.Controls.ChartView.NumericalAxis   MinimumA 	 ;Telerik.Windows.Controls.Converters.StringToDoubleConverter$ 0    Maximum$ 1    	MajorStep$	 0.2 
 �� " ��.���  � ��
 �������  � ��$ 10(���  � ��$ 20����  � ��$ Right=���  � ��$ Century Gothic)�   Grid ; 	 5Telerik.Windows.Controls.ChartView.CartesianChartGrid     MajorXLinesRenderMode$	 All=�   MajorLinesVisibility$ XY=�5	 	 /Telerik.Windows.Controls.ChartView.RadChartBase 	  	Behaviors @
 	 :Telerik.Windows.Controls.ChartView.ChartPanAndZoomBehavior
   
  ZoomMode$
 Both=� 
  PanMode$
 Both=�? 	 9Telerik.Windows.Controls.ChartView.ChartSelectionBehavior  A  ;Telerik.Windows.Controls.Data.PropertyGrid.AutoBindBehavior   BindingModeOverride OneTime   Series. 2 	 ,Telerik.Windows.Controls.ChartView.BarSeries     PaletteMode$ Series=�> 	 8Telerik.Windows.Controls.ChartView.CategoricalSeriesBase   CategoryBindingJ 	 DTelerik.Windows.Controls.ChartView.StringToDataPointBindingConverter$ UseFuel : 	 4Telerik.Windows.Controls.ChartView.CategoricalSeries   ValueBinding$ DegreeAshCapture    CombineMode$
 None=�4 	 .Telerik.Windows.Controls.ChartView.ChartSeries   ItemsSource �� *	Results+< 	 6Telerik.Windows.Controls.ChartView.PointTemplateSeries   PointTemplate �� .R��� ����   �� Color  �� *DataItem.ColorResult+� $��1�� �� $
��0.1* ��� $��1* ��� $
��0.1* ��� .+��� $��0��$��20q�$��Century Gothic)�$��Italic$�$��Center=�$ Center=�$
��Wrap=�$��18(�$��Center=�
���������Значения концентрации золы на входе в каждое поле электрофильтра, г/м³  -   $��Chart��$
  True��$	��300��$��1��$��10q�$��Stretch=�$��Stretch=�   $ 1��$ BetweenTicks=�$	 Rotate=�
 �� " ��.���  � ��$ 80����  � ��$ 40����  � ��
 �������  � ��$ 11(���  � ��$ Century Gothic)���  � ��$
 Wrap=�   $ 0 $ 50 $ 5 
 �� " ��.���  � ��
 �������  � ��$ 10(���  � ��$ 20����  � ��$ Right=���  � ��$ Century Gothic)�   $	 All=�$ XY=� 
  $
 Both=�$
 Both=�   OneTime? 	 9Telerik.Windows.Controls.ChartView.ChartCrosshairBehavior  .   $ 	DataPoint=�$	��100��$ FuelName $ FirstFieldConcentration $
 None=� �� *	AllData+!   DefaultVisualStyle! �� " ��.���  � �� �	#FF53F045  $ FuelName $	��100��$ SecondFieldConcentration $
 None=� �� *	AllData+! �� " ��.���  � �� �	#FFD6DD44  $ FuelName $	��100��$ ThirdFieldConcentration $
 None=� �� *	AllData+! �� " ��.���  � �� �	#FFE99129  $ FuelName $	��100��$ FourthFieldConcentration $
 None=� �� *	AllData+! �� " ��.���  � �� �	#FF6A4005  $ FuelName $	��100��$ OutConcentration $
 None=� �� *	AllData+! �� " ��.���  � ��
 �  ���� $��3��$��10q�$��2��$��50��" J� Opacity$	" 0.8Q�$��1q�
����+��$ 15�����#3A4149._�� $��10q�# � ColumnDefinitions# �� $
��0.3* ��� $��1* ��� $
��0.3* ��� $��1* ��� $
��0.3* ��� $��1* ��� $
��0.3* ��� $��1* ��� $
��0.3* ��� $��1* �.+��� $��0�����	#FF53F045$��10��$��10���� $��1��$��Century Gothic)�$��Center=�
�������$&�� На входе в поле №1��$	��100��$
��Wrap=��� $��2�����	#FFD6DD44$��10��$��10���� $��3��$��Century Gothic)�$��Center=�
�������$&�� На входе в поле №2��$
��Wrap=��� $��4�����	#FFE99129$��10��$��10���� $��5��$��Century Gothic)�$��Center=�
�������$&�� На входе в поле №3��$
��Wrap=��� $��6�����	#FF6A4005$��10��$��10���� $��7��$��Century Gothic)�$��Center=�
�������$&�� На входе в поле №4��$
��Wrap=��� $��8��
���  ��$��10��$��10���� $��9��$��Century Gothic)�$��Center=�
�������$��На выходе��$
��Wrap=�