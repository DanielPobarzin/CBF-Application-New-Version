   M S B A M L   `   `   `  ���� E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels  F BApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:Application.Utilities;assembly=ApplicationApplication.Utilities  FilterApplication"   FilterApplication.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Fvm7clr-namespace:ViewModels.ViewModels;assembly=ViewModels     IMenu8clr-namespace:Application.Utilities;assembly=Application     -   $��ResponsiveWindow��  � Title$  CBF App PRO��$	��500��$	��900��$	��800��$	��420�� � AllowsTransparency$
 True�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� %� IsVirtualizing$
 True�� %� IsContainerVirtualizable$
 True�� %� VirtualizationMode$ 	Recycling=�! %� IsVirtualizingWhenGrouping$
 True��	 %� CacheLengthUnit$	 Pixel=�
 %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$
 100000  %� 
ScrollUnit$
 Item=�
������  � Icon ��  �� 	UriSource$ /Resources/Images/OST.ico?� � 	Resources 6  0Application.Utilities.MultiUINavigationConverter   MultiParameterConverter��%   &	          .���  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 30Q�   ShadowDepth$ 2Q�   	Direction$	 -90Q�   Color$
 Gray��.+��� -    ��Name$
 Bord�����#222222���#3A4149$��5q� �� CornerRadius$ 20��� -    �Name$ BasGrid�� � ColumnDefinitions �� $
��Auto �$	��228���� $��1* �.+�� -   $��NavigationGrid��$��80��$	��230��$
��Left=�$��0��.+��� ���#272B2F$��60��$	��240��$��5q�$ 	20,0,0,20���� -   $��	MenuClose��$y�Visible=�$	��Top=�$��Right=�$��10q�  CloseMenuButton#��[ ���� *CloseNavigationMenuCommand+��`�  `� 	Converter# [  .1���  �� ElementName$ NavigationGrid���� $ 	MenuClose���� $ MenuOpen���� -   $��MenuOpen��$y�	Collapsed=�$	��Top=�$��Right=�$��10q�  HamburgerMenuButton#��[ ���� *OpenNavigationMenuCommand+��`� # [  .1��� $ NavigationGrid���� $ 	MenuClose���� $ MenuOpen���� -   $��NavigationPanel��$y�Visible=�$	��340��$��5 0 5 0q�$	��220��.+�  Application.Utilities.Btn  -   $��Главная��  BtnStyle#���   d� 	IsChecked$
 TrueY����� *HomeCommand+ �� IsAsync$
 True��.��� .+��� $$��/Resources/Images/img_home.png��  Image_Style#��[ �� $��Главная��  
Text_Style#��[   -	   $��Фильтры��#��[ ���� *FiltersCommand+$
 True��.��� .+��� $&�� /Resources/Images/img_filter.png��#��[ �� $��Фильтры��#��[   -
   $��Топливо��#��[ ���� *FuelsCommand+.��� .+��� $$��/Resources/Images/img_fuel.png��#��[ �� $��Топливо��#��[   -   $��Станция��#��[ ���� *StationsCommand+$
 True��.��� .+��� $'��!/Resources/Images/img_station.png��#��[ �� $��Станция��#��[   -   $��Расчеты��#��[ ���� *CalculateCommand+.��� .+��� $)��#/Resources/Images/img_calculate.png��#��[ �� $��Расчеты��#��[   -   $��Графики��#��[ ���� *ChartsCommand+.��� .+��� $'��!/Resources/Images/img_setting.png��#��[ �� $��Графики��#��[ � -   $��UserGrid��$��1��.+��� -    ��Name$ Pages��$
 True��$
 True��$ 	Recycling=�$
 True��$	 Pixel=�$

 1000 $
 Item=����� *	Current+��  �� Orientation$ 
Horizontal=�$��Right=�$��0��$��1��.+���   MaxAppStyle#��[ ���� *
MaxCommand+����  �� RelativeSource ��  �� AncestorType
 Window��   ExitApp#��[ ���� *CloseCommand+����  �� 
 Window