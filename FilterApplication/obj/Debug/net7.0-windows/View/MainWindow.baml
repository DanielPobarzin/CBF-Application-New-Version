   M S B A M L   `   `   `  ����E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels  5      F BApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:Application.Utilities;assembly=ApplicationApplication.Utilities 5       FilterApplication"   FilterApplication.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Fvm7clr-namespace:ViewModels.ViewModels;assembly=ViewModels     5      IMenu8clr-namespace:Application.Utilities;assembly=Application     5      -   5        $��ResponsiveWindow��5        � Title$  CBF App PRO��5
      $	��500��5      $	��900��5      $	��800��5      $	��420��5       � AllowsTransparency$
 True��5       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       %� IsVirtualizing$
 True��5       %� IsContainerVirtualizable$
 True��5       %� VirtualizationMode$ 	Recycling=�5      ! %� IsVirtualizingWhenGrouping$
 True��5      	 %� CacheLengthUnit$	 Pixel=�5      
 %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$
 100000 5       %� 
ScrollUnit$
 Item=�5      
������  � Icon 5      �� 5    
    �� 	UriSource$ /Resources/Images/OST.ico?�6    � 	Resources 5"      6  0Application.Utilities.MultiUINavigationConverter   MultiParameterConverter��%   &	          5#   
   6*   5$      .��5%      �  J� Effect 5&   
   3  -System.Windows.Media.Effects.DropShadowEffect  5'         
BlurRadius$ 30Q�6      ShadowDepth$ 2Q�5(   #      	Direction$	 -90Q�5)   #      Color$
 Gray��5*   #   5+      .+�5.   
   �� -   5         ��Name$
 Bord��5.      ���#222222���#3A4149$��5q�50   
    �� CornerRadius$ 20��51   
   � 53   
   -   5         �Name$ BasGrid��53       � ColumnDefinitions 55      �� 56      $
��Auto �6#   $	��228��57   #   �� 58      $��1* �6#   .+�5<      � -   5        $��NavigationGrid��5<      $��80��6)   $	��230��67   $
��Left=�6F   $��0��6a   .+�5=      �� ���#272B2F$��60��6/   $	��240��6=   $��5q�5>      $ 	20,0,0,20��5?      �� 5@      -   5        $��	MenuClose��5@      $y�Visible=�5A      $	��Top=�5B      $��Right=�5C      $��10q�5D        CloseMenuButton#��[ 5F      ��5E      �� *CloseNavigationMenuCommand+��5G      `� 5H       `� 	Converter# [  6'   .1�5I      ��  �� ElementName$ NavigationGrid��6&   �� 5J      $ 	MenuClose��6&   �� 5K      $ MenuOpen��6&   5L      5N      �� 5O      -   5        $��MenuOpen��5O      $y�	Collapsed=�5P      $	��Top=�5Q      $��Right=�5R      $��10q�5S        HamburgerMenuButton#��[ 5U      ��5T      �� *OpenNavigationMenuCommand+��5V      `� 5W      # [  6'   .1�5X      �� $ NavigationGrid��6&   �� 5Y      $ 	MenuClose��6&   �� 5Z      $ MenuOpen��6&   5[      5]      �� 5_      -   5        $��NavigationPanel��5_      $y�Visible=�64   $	��340��6I   $��5 0 5 0q�6V   $	��220��5`      .+�5b        Application.Utilities.Btn  -   5        $��Главная��5b        BtnStyle#���  6.    d� 	IsChecked$
 TrueY�5c      ��5b   Q   �� *HomeCommand+ �� IsAsync$
 True��.��5e      � .+�5f      �� $$��/Resources/Images/img_home.png��6$     Image_Style#��[ 5g      �� 5i      $��Главная��6(     
Text_Style#��[ 5j      5l      5m        5q      -	   5        $��Фильтры��5q   A   #��[ 6   ��5r      �� *FiltersCommand+$
 True��.��5t      � .+�5u      �� $&�� /Resources/Images/img_filter.png��6$   #��[ 5v      �� 5w      $��Фильтры��6(   #��[ 5x      5z      5{        5~      -
   5        $��Топливо��5~   A   #��[ 6   ��5      �� *FuelsCommand+.��5�      � .+�5�      �� $$��/Resources/Images/img_fuel.png��6$   #��[ 5�      �� 5�      $��Топливо��6(   #��[ 5�      5�      5�        5�      -   5        $��Станция��5�   A   #��[ 6   ��5�      �� *StationsCommand+$
 True��.��5�      � .+�5�      �� $'��!/Resources/Images/img_station.png��6$   #��[ 5�      �� 5�      $��Станция��6(   #��[ 5�      5�      5�        5�      -   5        $��Расчеты��5�   A   #��[ 6   ��5�      �� *CalculateCommand+.��5�      � .+�5�      �� $)��#/Resources/Images/img_calculate.png��6$   #��[ 5�      �� 5�      $��Расчеты��6(   #��[ 5�      5�      5�        5�      -   5        $��Графики��5�   A   #��[ 6   ��5�      �� *ChartsCommand+.��5�      � .+�5�      �� $'��!/Resources/Images/img_setting.png��6$   #��[ 5�      �� 5�      $��Графики��6(   #��[ 5�      5�      5�      5�      5�      � 5�      -   5        $��UserGrid��5�      $��1��6$   .+�5�      �� -   5         ��Name$ Pages��5�   !   $
 True��5�      $
 True��5�      $ 	Recycling=�5�      $
 True��5�      $	 Pixel=�5�      $

 1000 5�      $
 Item=�5�      ��5�      �� *	Current+5�      5�      �� 5�   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��0��6J   $��1��6W   .+�5�      ��   MaxAppStyle#��[ 5�      ��5�      �� *
MaxCommand+��5�      ��  �� RelativeSource ��  �� AncestorType
 Window5�      �� 5�        ExitApp#��[ 5�      ��5�      �� *CloseCommand+��5�      ��  �� 
 Window5�      5�      5�      5�      