   M S B A M L   `   `   `  ���� E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels   FilterApplication&    FilterApplication.View.Calculate   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     N
viewModels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels       %� IsVirtualizing$
  True�� %� IsContainerVirtualizable$
 True�� %� VirtualizationMode$ 	Recycling=�! %� IsVirtualizingWhenGrouping$
 True�� %� CacheLengthUnit$ Pixel=� %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 10000  %� 
ScrollUnit$
 Item=�   	PageStyle#��[   � 	Resources   ElementBorder �� 
TargetType	 �� Property
 �� Value  TextBlockHeader  HeaderBorder  
DotPattern !� Visual j� Viewport j� ViewportUnits j� TileMode��%�  &	       &	 �     &	 {    &	 $    �� " ��.��� 	 �@��CornerRadius$
 1���� 	 � ��$
 30���� 	 � ��$
 1q��� 	 � ��
 �#152335�� 	 � ��
 �#6a8bb3�� " ��.��� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��
 �#DCE0E4�� 	 �@��TextAlignment$
 Center=��� 	 � ��$

 Wrap=��� 	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)��� 	 � ��$
 11(��� " ��.��� 	 �@��CornerRadius$
 1���� 	 � ��$
 40���� 	 � ��$	
 100���� 	 � ��$
 1q��� 	 � ��
 �#1d314a�� 	 � ��
 �#6a8bb3!�  A� $��10��$��10�����	#FF616161 �0,0,3,3�$ Absolute=�$
 Tile=�.��� 
������ .+��� ���#212529���#3A4149$��5q� �� CornerRadius$ 8,8,0,8��._��� $
��Auto=�$
  True��$
 True��$ 	Recycling=�$
 True��$ Pixel=�$
 1000 $
 Item=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* �.+��� $��5��$��3��$��0 0 0 0q�$��Center=�$��Center=� J� Opacity$	 0.5Q�$'��!/Resources/Images/charts_page.png��$
��Fill=��� $��0��$��3��$��0��$��20q�.+��� ���#373E46$��10q�$	��400��$ 25��$
��1500��._�� $��10q�.+��� $
��Auto=�.��� .+��� ���#DCE0E4$�� ��$��20(�$
��Wrap=�$(��"/Resources/Fonts/#Raleway SemiBold)���  �� Orientation$ Vertical=�$��1��$��1��.+��� -    ��Name$ HeaderCalculate�����	#FF0BCDFF$��50��$	��150��$ 25��$y�Visible=�._���  �� TextAlignment$ Center=�$��Center=�$��Center=�
���   �$��К РАСЧЕТУ��$��20(�$��NoWrap=�$��Century Gothic)�� -   $��GridLoad��$	��120��$y�	Collapsed=�$	��Top=�$��Center=�.+�A� $	��100��$	��100��$	 0.8Q����#4D4D4D$��50��$��Center=�$��Center=�A� $	��100��$	��100�����	#FF07A8D1$	 0.9Q�$��10��$��Center=�$��Center=��� -    ��Name$ 
TimerLabel��
��� ���$��60��$��60��$��30(�$��Center=�$��Center=�$ Center=�$��0,10,0,0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 30Q�   ShadowDepth$ 2Q�   	Direction$	 -90Q�   Color$ #FEF200���� -   $��LoadText�����#FFFFFF$��16��$	��150��$��10(�$��Center=�$ Center=�$��0,40,0,0q�d� -    d�Name$ StartButtonCalculate��$��10q�$��50��$��50��$��Center=�$	��Top=�  PlayBtnStyle#��[  d� 	IsChecked$ FalseY��� -   $��UserGrid��$��2��$��3��$��0��._��  �� $
��Auto �.+��� $��0��$	��500��$ Vertical=�.+�]� -   $��ResultsTable��$
��True��
������ $��Stretch=�$	��Top=�.+��� -   $ Header��$��40��$	��Top=�
������ ���� *ActualWidth+ �� RelativeSource ��  �� AncestorType 	DockPanel._��� $ 
Horizontal=�$��Stretch=�.+��� -	   $ 
HeaderFuel��#��[ ._��� #��[ $-��'Используемое топливо���� -
   $ HeaderFields��#��[ ._��� #��[ $+��%Поля электрофильтра���� -   $ HeaderConcentrateAsh��#��[ ._��� #��[ $-��'Время встряхивания, с���� -   $ HeaderOptimalShakeMode��#��[ ._��� #��[ $/��)Концентрация золы, г/м3���� -   $ DegreeAshCapture��#��[ ._��� #��[ $3��-Степень золоулавливания���� .+��� $
��Auto=�.���� ���� *	Results+���� .R��� $ Vertical=�.+�]� .+�� $
��Left=� �� $��1* ��� $��1* �.+��� $��0��#��[ ���� *ActualHeight+ ��  	DockPanel���� *ActualWidth+  �� ElementName$  
HeaderFuel��._��  �� $��0.15* ��� $��1* �.+��� #��[ $��5q�$��1��$��10(����� *	UseFuel+�� $��0��$��Stretch=�$��Center=�$��4��$ 2��$��5q����� ! �� Color! �� *ColorResult+   $ 0Q�$ 20Q�"   Opacity$	" 0.4Q� ��  �� 
 Border# �� Path$# BorderBrush��� $ Vertical=�$
��Auto��$��1������ *ActualWidth+$  HeaderFields��.+��� ���� *OptimalAshShakingMode+���� .R��� #��[ $��20��._��� #��[ ���� *Key+�  �� $��1* ��� $��1* ��� $��1* �.+��� $��PanelWithResult��$ Vertical=�$
��Auto��$��0������ *ActualWidth+$  HeaderOptimalShakeMode��.+��� ���� *OptimalAshShakingMode+���� .R��� #��[ $��20��._��� #��[ ���� *Value+$ �� StringFormat$$ {0:F2}���� $ Vertical=�$��1������ *ActualHeight+$  PanelWithResult������ *ActualWidth+$  HeaderConcentrateAsh��.+��� ���� *" AshConcentrationEntranceMthField+���� .R��� #��[ $��20��._��� #��[ ���� *Value+$$ {0:F4}���� $��2��$ Vertical=�$
��Auto������ *ActualWidth+$  DegreeAshCapture��.+��� #��[ ���� *ActualHeight+$  PanelWithResult��._��� #��[ ���� *DegreeAshCapture+$$ {0:F4}���� $ Vertical=�$��3��$��0��$��3��$��Stretch=�.+���  
 Export#��[ ���� *ExportToExcelCommand+�� -   $ ConsoleBorder��$��5 0 5 5q�$��Stretch=�$	��200��$	��500�����	#FF8A8D92$��3q�$	 0.8Q����	#FF1F1D1D._��  �� $
��Auto ��� $��1* �.+�]� $��0��$��40��$	��Top=����	#FF47494D.+�]� -   % ]�Name$% Console��$	��Top=�.+��� $
��Left=�
�������
Вывод�� $��4q�$��Right=�$��Stretch=�#��[ ]� $��Bottom=�.+��� ���	#FF959BA0hfОтображение сообщений, возникающих в результате работы�� $
��Auto=�$��1��.���� -   & ��Name$& OutputTextBox��$��Stretch=�' �� 
IsReadOnly$
' True�����	#FF1F1D1D���	#FFC9F3CF$��12(�$��Rubik)�( �� AcceptsReturn$
( True��) �� TextWrapping$
) Wrap=����� *	LogOutput+* �� UpdateSourceTrigger$* PropertyChanged=�+ �� Mode$+ OneWay=�