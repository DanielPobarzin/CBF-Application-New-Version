   M S B A M L   `   `   `  ����F  BApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:Application.Utilities;assembly=ApplicationApplication.Utilities  5      E AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels 6T    FilterApplication&    FilterApplication.View.Calculate   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      IMenu8clr-namespace:Application.Utilities;assembly=Application     5      N
viewmodels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels     6T   k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p  lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q! mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r" nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q# mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s$ oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r% nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q& mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a' ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k( gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q) mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l* hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#  	 
                        ! " # $ % & ' ( ) * 6�     %� IsVirtualizing$
  True��5       %� IsContainerVirtualizable$
 True��5	       %� VirtualizationMode$ 	Recycling=�5
      ! %� IsVirtualizingWhenGrouping$
 True��5       %� CacheLengthUnit$ Pixel=�5       %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 10000 5       %� 
ScrollUnit$
 Item=�5         
Page_Style#��[  5       � 	Resources 5      0   *Application.Utilities.RandomColorConverter  RandomColorConverter  TextBoxUniformStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �Name J� SnapsToDevicePixels ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value  TextBlockForm  ElementBorder  TextBlockHeader  HeaderBorder  
DotPattern !� Visual j� Viewport j� ViewportUnits j� TileMode��%�
  &	       &	      &	 @    &	 6    &	 %    &	 �    &	 �	      5   
   6$   �� 5   
   " ��6,   .�5      �� 	 � ��
 �	#FF11141A6+   �� 5      	 � ��$
 Center=�69   �� 5      	 � ��$
 25��6'   �� 5      	 � ��
 �	#FFA6AAB46+   �� 5      	 � ��$
 12(�6)   �� 5      	 � ��
 �	#FF6E70736,   �� 5      	 � ��$
 10,0,0,0q�6(   �� 5      	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)�6+   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5       � $
 root��6   #��z��6-   #��z��5!      $
 True��5"      .+�5#      �� $ 
Background��6%   $��2q�5$      $ 10��5%      #��z��5&      #��z��5'      �� 5(      $ PART_ContentHost��6+   $��0q�5)      #��z��5*      $��False��5+      #��z��5-      ��5,      Z� 5/      51       52      P� 53       �@J�IsMouseOver$
 True��6=   . �54   "   �� 	 � ��
 �	#FF383C446@   55      P� 56       �@J�	IsFocused$
 True��6;   . �57   "   �� 	 � ��
 �	#FF3D578C6@   �� 58   "   	 � ��
 �	#FF0E11166?   59      5;      5=      5>      �� 5?   
   " ��6&   .�5@      �� 	 � ��$	
 Top=�62   �� 5A      	 � ��$
 10, 10, 0, 0q�6'   �� 5B      	 � ��$
 20��6*   �� 5C      	 � ��$
 80��6*   �� 5D      	 � ��$

 Left=�64   �� 5E      	 � ��$	
 350��6)   �� 5F      	 � ��
 �#DCE0E46+   �� 5G      	 �@��TextAlignment$

 Left=�6.   �� 5H      	 � ��$

 Wrap=�6-   �� 5I      	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)�6+   �� 5J      	 � ��$
 10(�6)   5K      �� 5L   
   " ��6&   .�5M      �� 	 �@��CornerRadius$
 1��6-   �� 5N      	 � ��$
 30��6'   �� 5O      	 � ��$
 1q�60   �� 5P      	 � ��
 �#1523356+   �� 5Q      	 � ��
 �#6a8bb36,   5R      �� 5S   
   " ��6(   .�5T      �� 	 � ��$
 Center=�62   �� 5U      	 � ��$
 Center=�64   �� 5V      	 � ��
 �#DCE0E46+   �� 5W      	 �@��TextAlignment$
 Center=�6.   �� 5X      	 � ��$

 Wrap=�6-   �� 5Y      	 � ��$(
 "/Resources/Fonts/#Raleway SemiBold)�6+   �� 5Z      	 � ��$
 11(�6)   5[      �� 5\   
   " ��6%   .�5]      �� 	 �@��CornerRadius$
 1��6-   �� 5^      	 � ��$
 40��6'   �� 5_      	 � ��$	
 100��6&   �� 5`      	 � ��$
 1q�60   �� 5a      	 � ��
 �#1d314a6+   �� 5b      	 � ��
 �#6a8bb36,   5c      !� 5d   
    5e      A� 5f      $��10��6   $��10��6&   ���	#FF61616161    5h      �5i      0,0,3,3�6    $ Absolute=�5k   L   $
 Tile=�5l   >   5m      5n      .��5o      � 
������ .+�5p   
   �� ���#212529���#3A4149$��5q�5r      $ 8,8,0,8��5s      ._�5t      �� $
��Auto=�6   $
  True��6?   $
 True��5u      $ 	Recycling=�5v      $
 True��5w      $ Pixel=�5x      $
 1000 5y      $
 Item=�5z      .��5{      �  � RowDefinitions 5|      �� 5}      $
��Auto �6(   �� 5~      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(    � ColumnDefinitions 5�      �� 5�      $��1* �6+   �� 5�      $��1* �6+   �� 5�      $��1* �6+   .+�5�      �� $��5��6   $��3��6-   $��0 0 0 0q�5�      $��Center=�5�      $��Center=�5�       J� Opacity$	 0.5Q�5�      $'��!/Resources/Images/charts_page.png��5�      $
��Fill=�5�      �� 5�      $��0��6!   $��3��6.   $��20q�6B   .+�5�      �� ���#373E46$��10q�66   $	��400��6B   $ 25��6R   $
��1500��6d   ._�5�      � $��10q�6#   .+�5�   "   �� $
��Auto=�6/   .��5�   &   � .+�5�   *   �� ���#DCE0E4$�� ��5�   2   $��20(�5�   2   $
��Wrap=�5�   2   $(��"/Resources/Fonts/#Raleway SemiBold)�5�   2   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�       �� Orientation$ Vertical=�6!   $��1��68   $��1��6H   .+�5�      �� -   5        $ HeaderCalculate��5�   !   ���	#FF0BCDFF$��50��5�      $	��150��5�      $ 25��5�      $y�Visible=�5�      ._�5�      ��  �� TextAlignment$ Center=�6(   $��Center=�5�   &   $��Center=�5�   &   
���   �$��К РАСЧЕТУ��5�   &   $��20(�5�   &   $��NoWrap=�5�   &   $��Century Gothic)�5�   &   5�      � 5�      -   5        $��GridLoad��5�   ,   $	��120��6   $y�	Collapsed=�6<   $	��Top=�5�      $��Center=�5�      .+�5�      A� $	��100��6&   $	��100��5�       $	 0.8Q�5�   &   ���#4D4D4D$��50��5�       $��Center=�5�       $��Center=�5�       A� 5�      $	��100��6&   $	��100��5�   &   ���	#FF07A8D1$	 0.9Q�5�   &   $��10��5�   &   $��Center=�5�   &   $��Center=�5�   &   �� 5�      -   5         ��Name$ 
TimerLabel��5�   (   
��� ���$��60��5�   '   $��60��5�   '   $��30(�5�   '   $��Center=�5�   '   $��Center=�5�   '   $ Center=�5�   '   $��0,10,0,0q�5�   '    J� Effect 5�   "   3  -System.Windows.Media.Effects.DropShadowEffect  5�   &      
BlurRadius$ 30Q�67       ShadowDepth$  2Q�5�   *   !   	Direction$	! -90Q�5�   *   "   Color$" #FEF200��5�   *   5�      �� 5�      -   5        $��LoadText��5�   (   ���#FFFFFF$��16��5�      $	��150��5�      $��10(�5�      $��Center=�5�      $ Center=�5�      $��0,40,0,0q�5�      5�      d� 5�      -   5        # d�Name$# StartButtonCalculate��5�   '   $��10q�5�   %   $��50��5�   %   $��50��5�   %   $��Center=�5�   %   $	��Top=�5�   %     PlayBtn_Style#��[ 5�   %   $ d� 	IsChecked$$ FalseY�5�   %   5�      5�      �� 5�      -   5        $��UserGrid��5�      $��2��6-   $��3��6:   ._�5�      �  5�      �� 5�   "   $
��Auto �60   .+�5�      �� $��0��6)   $	��500��66   $ Vertical=�6B   .+�5�   "   ]� -   5        $��ResultsTable��5�   A   $
��True��6,   
������ $��Stretch=�6n   $	��Top=�6�   .+�5�   &   �� -   5        $ Header��5�   9   $��40��6-   $	��Top=�6�   
������ ��6I   �� *ActualWidth+% �� RelativeSource% �� & �� AncestorType& 	DockPanel._�5�   *   �� $ 
Horizontal=�65   $��Stretch=�6N   .+�5�   .   �� -	   5        $ 
HeaderFuel��5�   [   #��[ 65   ._�5�   2   �� #��[ 6<   $-��'Используемое топливо��6e   6�   5�   /   �� 5�   .   -
   5        $ HeaderFields��5�   [   #��[ 65   ._�5�   2   �� #��[ 6<   $+��%Поля электрофильтра��6e   6�   5�   /   �� 5�   .   -   5        $ HeaderConcentrateAsh��5�   [   #��[ 65   ._�5�   2   �� #��[ 6<   $-��'Время встряхивания, с��6e   6�   5�   /   �� 5�   .   -   5        $ HeaderOptimalShakeMode��5�   [   #��[ 65   ._�5�   2   �� #��[ 6<   $/��)Концентрация золы, г/м3��6e   6�   5�   /   �� 5�   .   -   5        $ DegreeAshCapture��5�   [   #��[ 65   ._�5�   2   �� #��[ 6<   $3��-Степень золоулавливания��6e   6�   5�   /   5�   +   5   '   5  #   �� 5  "   .+�5  &   �� $
��Auto=�63   .��5  *   �� ��67   �� *	Results+��5  .   �� 5  2   .R�5  6   �� $ Vertical=�6A   .+�5  :   ]� .+�5	  >   � $
��Left=�6C    5
  B   �� 5  F   $��1* �6W   �� 5  F   $��1* �6W   .+�5  B   �� $��0��6I   #��[ 6�   ��6Y   �� *ActualHeight+% �� & 	DockPanel��6�   �� *ActualWidth+' �� ElementName$' 
HeaderFuel��._�5  F   �  5  J   �� 5  N   $��0.15* �6_   �� 5  N   $��1* �6_   .+�5  J   �� #��[ 6T   $��5q�5  J   $��1��5  J   $
��Wrap=�5  J   $��10(�5  J   ��5  J   �� *	UseFuel+6e   �� 5  J   $��Stretch=�6S   $��Center=�5  ?   $��4��5  @   $ 2��5  @   $��5q�5  @   ��5  N   �� 5   R   ( �� Color( 6b   �� *ColorResult+ 5"  N     5#  R   $  0Q�5&  D   $ 20Q�5'  D   )   Opacity$	) 0.4Q�5(  D   " 5$  D   �� % �� 
& Border* �� Path$* BorderBrush.Color�5(  D   5*  K   5+  G   5,  C   �� 5-  B   $ Vertical=�6M   $
��Auto��6d   $��1��6r   ��6�   �� *ActualWidth+$' HeaderFields��.+�5.  F   �� ��6S   �� *OptimalAshShakingMode+��5/  J   �� 50  N   .R�51  R   �� #��[ 6Y   $��20��6�   ._�52  V   �� #��[ 6`   ��6�   �� *Key+6�   53  S   54  O   56  G   57  C   58  ?   � 5:  >    5;  B   �� 5<  F   $��1* �6W   �� 5=  F   $��1* �6W   �� 5>  F   $��1* �6W   .+�5@  B   �� $��PanelWithResult��6M   $ Vertical=�6d   $
��Auto��6{   $��0��6�   ��6�   �� *ActualWidth+$' HeaderOptimalShakeMode��.+�5A  F   �� ��6S   �� *OptimalAshShakingMode+��5B  J   �� 5C  N   .R�5D  R   �� #��[ 6Y   $��20��6�   ._�5E  V   �� #��[ 6`   ��6�   �� *Value++ �� StringFormat$+ {0:F2}��6�   5F  S   5G  O   5I  G   5J  C   �� 5K  B   $ Vertical=�6M   $��1��6�   ��6d   �� *ActualHeight+$' PanelWithResult����6�   �� *ActualWidth+$' HeaderConcentrateAsh��.+�5L  F   �� ��6S   �� *" AshConcentrationEntranceMthField+��5M  J   �� 5N  N   .R�5O  R   �� #��[ 6Y   $��20��6�   ._�5P  V   �� #��[ 6`   ��6�   �� *Value+$+ {0:F4}��6�   5Q  S   5R  O   5T  G   5U  C   �� 5V  B   $ Vertical=�6M   $
��Auto��6d   $��3��6r   ��6�   �� *ActualWidth+$' DegreeAshCapture��.+�5W  F   �� #��[ 6M   ��6t   �� *ActualHeight+$' PanelWithResult��._�5X  J   �� #��[ 6T   ��6}   �� *DegreeAshCapture+$+ {0:F4}��6�   5Y  G   5Z  C   5[  ?   5\  ;   5]  7   5^  3   5`  +   5a  '   5b  #   5c     5d     5e     �� 5g     $ Vertical=�6!   $��3��68   $��0��6E   $��3��6U   $��Stretch=�6i   .+�5h     ��  
	 Export#��[	 6!   ��6A   �� *ExportToExcelCommand+5i     �� 5j     -   5        $ ConsoleBorder��5j  2   $��5 0 5 5q�6!   $��Stretch=�5k  #   $	��200��5l  #   $	��500��5m  #   ���	#FF8A8D92$��3q�5o  #   $	 0.8Q�5p  #   ���	#FF1F1D1D._�5q     �  5r  "   �� 5s  &   $
��Auto �64   �� 5t  &   $��1* �64   .+�5v  "   ]� $��0��6,   $��40��69   $	��Top=�6E   ���	#FF47494D.+�5w  &   ]� -   5        , ]�Name$, Console��5w  0   $	��Top=�6A   .+�5x  *   �� $
��Left=�64   
�������
Вывод6i   �� 5y  *   $��4q�61   $��Right=�6<   $��Stretch=�6S   $��3��6q   #��[ 6�   6�   5z  '   ]� 5{  &   $��Bottom=�60   .+�5|  *   �� ���	#FF959BA0hfОтображение сообщений, возникающих в результате работы6�   5}  '   5~  #   �� 5  "   $
��Auto=�6/   $��1��6R   .��5�  &   �� -   5        - ��Name$- OutputTextBox��5�  .   $��Stretch=�5�  0   . �� 
IsReadOnly$
. True��5�  0   ���	#FF1F1D1D���	#FFC9F3CF$��12(�5�  0   $��Rubik)�5�  0   / �� AcceptsReturn$
/ True��5�  0   0 �� TextWrapping$
0 Wrap=�5�  0   ��5�  0   �� *	LogOutput+1 �� UpdateSourceTrigger$1 PropertyChanged=�2 �� Mode$2 OneWay=�5�  0   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     