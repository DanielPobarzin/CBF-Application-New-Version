   M S B A M L   `   `   `  ���� F  BApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:Application.Utilities;assembly=ApplicationApplication.Utilities  E AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels  FilterApplication&    FilterApplication.View.Calculate   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     IMenu8clr-namespace:Application.Utilities;assembly=Application     N
viewmodels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels     k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p  lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q! mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r" nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q# mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s$ oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r% nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q& mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a' ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k( gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q) mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l* hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#  	 
                        ! " # $ % & ' ( ) *   %� IsVirtualizing$
  True�� %� IsContainerVirtualizable$
 True�� %� VirtualizationMode$ 	Recycling=�! %� IsVirtualizingWhenGrouping$
 True�� %� CacheLengthUnit$ Pixel=� %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 10000  %� 
ScrollUnit$
 Item=�   
Page_Style#��[   � 	Resources 0   *Application.Utilities.RandomColorConverter  RandomColorConverter  TextBoxUniformStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �Name J� SnapsToDevicePixels ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value  TextBlockForm  ElementBorder  TextBlockHeader  HeaderBorder  
DotPattern !� Visual j� Viewport j� ViewportUnits j� TileMode��%V  &	       &	      &	 t    &	 �    &	 K    &	 4    &	 �      �� " ��.��� 	 � ��
 �	#FF11141A�� 	 � ��$
 Center=��� 	 � ��$
 25���� 	 � ��
 �	#FFA6AAB4�� 	 � ��$
 12(��� 	 � ��
 �	#FF6E7073�� 	 � ��$
 10,0,0,0q��� 	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)��� 	 � ��
 �� " ��.R�� $
 root��#��z��#��z��$
 True��.+��� $ 
Background��$��2q�$ 10��#��z��#��z���� $ PART_ContentHost��$��0q�#��z��$��False��#��z����Z�  P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �	#FF383C44P�  �@J�	IsFocused$
 True��. ��� 	 � ��
 �	#FF3D578C�� 	 � ��
 �	#FF0E1116�� " ��.��� 	 � ��$	
 Top=��� 	 � ��$
 10, 10, 0, 0q��� 	 � ��$
 20���� 	 � ��$
 80���� 	 � ��$

 Left=��� 	 � ��$	
 350���� 	 � ��
 �#DCE0E4�� 	 �@��TextAlignment$

 Left=��� 	 � ��$

 Wrap=��� 	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)��� 	 � ��$
 10(��� " ��.��� 	 �@��CornerRadius$
 1���� 	 � ��$
 20���� 	 � ��$
 1q��� 	 � ��
 �#152335�� 	 � ��
 �#6a8bb3�� " ��.��� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��
 �#DCE0E4�� 	 �@��TextAlignment$
 Center=��� 	 � ��$

 Wrap=��� 	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)��� 	 � ��$
 10(��� " ��.��� 	 �@��CornerRadius$
 1���� 	 � ��$
 1q��� 	 � ��
 �#1d314a�� 	 � ��
 �#6a8bb3!�  A� $��10��$��10�����	#FF616161 �0,0,3,3�$ Absolute=�$
 Tile=�.��� 
������ .+��� ���#212529���#3A4149$��5q�$ 8,8,0,8��._��� $
��Auto=�$
  True��$
 True��$ 	Recycling=�$
 True��$ Pixel=�$
 1000 $
 Item=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* �.+��� $��5��$��3��$��0 0 0 0q�$��Center=�$��Center=� J� Opacity$	 0.5Q�$'��!/Resources/Images/charts_page.png��$
��Fill=��� $��0��$��3��$��20q�.+��� ���#373E46$��10q�$	��400��$ 25��$
��1500��._�� $��10q�.+��� $
��Auto=�.��� .+��� ���#DCE0E4$�� ��$��20(�$
��Wrap=�$(��"/Resources/Fonts/#Raleway SemiBold)���  �� Orientation$ Vertical=�$��1��$��1��.+��� -   $ HeaderCalculate�����	#FF0BCDFF$��50��$	��150��$ 25��$y�Visible=�._���  �� TextAlignment$ Center=�$��Center=�$��Center=�
���   �$��К РАСЧЕТУ��$��20(�$��NoWrap=�$��Century Gothic)�� -   $��GridLoad��$	��200��$y�	Collapsed=�$	��200��$	��Top=�$��Center=�.+��� -    ��Name$ ProccessCalculateImage��$	��140��$y�Visible=�$	��140��$��Center=�$��Center=�  
Dial_Image#��[ $��Uniform=�A� $	��160��$	��160��$	 0.7Q����#212529$��15��$��Center=�$��Center=�A� $	��100��$	��100�����#4D4D4D$��10��$��Center=�$��Center=��� -    ��Name$ 
TimerLabel�����#FEF200$��60��$��60��$��30(�$��Center=�$��Center=�$ Center=�$��0,10,0,0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect      
BlurRadius$  30Q�!   ShadowDepth$! 2Q�"   	Direction$	" -90Q�#   Color$# #FEF200���� -   $��LoadText�����#FFFFFF$��16��$	��150��$��10(�$��Center=�$ Center=�$��0,40,0,0q�d� -   $ d�Name$$ StartButtonCalculate��$��10q�$��50��$��50��$��Center=�$	��Top=� 	 PlayBtn_Style#��[	 % d� 	IsChecked$% FalseY����� *CalculateCommand+�� -   $��UserGrid��$��2��$��3��._��  �� $
��Auto �.+��� $��0��$	��500��$ Vertical=�.+�]� -   $��ResultsTable��$
��True��
������ $	��500��$	��Top=�.+��� -	   $ Header��$��40��$	��Top=�
������ ���� *ActualWidth+& �� RelativeSource& �� ' �� AncestorType' 	DockPanel._��� $ 
Horizontal=�.+��� -
   $ 
HeaderFuel��#��[ $	��100��._��� #��[ $-��'Используемое топливо���� -   $ HeaderFields��#��[ $	��100��._��� #��[ $+��%Поля электрофильтра���� -   $ HeaderConcentrateAsh��#��[ $	��100��._��� #��[ $-��'Время встряхивания, с���� -   $ HeaderOptimalShakeMode��#��[ $	��100��._��� #��[ $/��)Концентрация золы, г/м3���� -   $ DegreeAshCapture��#��[ $	��100��._��� #��[ $3��-Степень золоулавливания���� .+��� $
��Auto=�.���� ���� *	Results+���� .R��� $ Vertical=�.+�]� .+�� $
��Left=� �� $��1* ��� $��1* �.+��� $��0��#��[ ���� *ActualHeight+& �� ' 	DockPanel���� *ActualWidth+( �� ElementName$( 
HeaderFuel��._��  �� $��0.15* ��� $��1* �.+��� #��[ $��5q�$��1��$
��Wrap=�$��8(����� *	UseFuel+�� $��Stretch=�$��Center=�$��4��$ 2��$��5q����� ) �� Color) �� *СolorResult+   $! 0Q�$  20Q�*   Opacity$	* 0.4Q�# �� & �� 
' Border+ �� Path$+ BorderBrush.Color��� $ Vertical=�$
��Auto��$��1������ *ActualWidth+$( HeaderFields��.+��� ���� *OptimalAshShakingMode+���� .R��� #��[ $��20��._��� #��[ ���� *Key+�  �� $��1* ��� $��1* ��� $��1* �.+��� $��PanelWithResult��$ Vertical=�$
��Auto��$��0������ *ActualWidth+$( HeaderOptimalShakeMode��.+��� ���� *OptimalAshShakingMode+���� .R��� #��[ $��20��._��� #��[ ���� *Value+�� $ Vertical=�$��1������ *ActualHeight+$( PanelWithResult������ *ActualWidth+$( HeaderConcentrateAsh��.+��� ���� *" AshConcentrationEntranceMthField+���� .R��� #��[ $��20��._��� #��[ ���� *Value+�� $ Vertical=�$
��Auto��$��3������ *ActualWidth+$( DegreeAshCapture��.+��� #��[ ���� *ActualHeight+$( PanelWithResult��._��� #��[ ���� *DegreeAshCapture+�� $ 
Horizontal=�$��3��$��3��$��Right=�.+���  

 Export#��[
 ���� *ExportToExcelCommand+�� -   $ ConsoleBorder��$��5 0 5 5q�$��4��$��Stretch=�$��3��$	��150��$	��500��$��Stretch=����	#FF8A8D92$��3q�$	 0.8Q����	#FF1F1D1D._��  �� $
��Auto ��� $��1* �.+�]� $��0��$��40��$	��Top=����	#FF47494D.+�]� -   , ]�Name$, Console��$	��Top=�.+��� $
��Left=�
�������
Вывод�� $��4q�$��Right=�$��Stretch=�$��3��#��[ ]� $��Bottom=�.+��� ���	#FF959BA0hfОтображение сообщений, возникающих в результате работы�� $
��Auto=�$��1��.���� -   - ��Name$- OutputTextBox��$��Stretch=�. �� 
IsReadOnly$
. True�����	#FF1F1D1D���	#FFC9F3CF$��12(�$��Rubik)�/ �� AcceptsReturn$
/ True��0 �� TextWrapping$
0 Wrap=����� *	LogOutput+1 �� UpdateSourceTrigger$1 PropertyChanged=�2 �� Mode$2 OneWay=�