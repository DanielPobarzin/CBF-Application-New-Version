   M S B A M L   `   `   `  ����W  SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxNormalBorderBrush  �� Color ! ComboBoxNormalBackgroundBrush # ComboBoxDisabledForegroundBrush # ComboBoxDisabledBackgroundBrush  ComboBoxDisabledBorderBrush �� 
TargetType   ComboBoxToggleButtonTemplate � ColumnDefinitions �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  ComboBoxFlatStyle
 �� 
TargetType �� 	ClickMode d� 	IsChecked �� Path �� RelativeSource �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
IsReadOnly �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %6  &	        &	 !     &	 ?     &	 ]     &	 {     &	 �     7   7  7  7  7  7  7  &	     7  7   7  �� 5      $  #e3e9ef��68   �� 5      $
  #fff��6<   �� 5      $
  #888��6>   �� 5      $
  #eee��6>   �� 5      $
  #888��6:   �� 5
      " d�6   .R�5   
   �  5      �� 5      �� 5      $��20 �6#   .+�5      �� $��Border��6)   $��2��6   8��  $ 0��5      $��
1, 1, 1, 1q�6    8�� 5      �� 5      $��ButtonBorder��6L   $��1��6   $��
1, 1, 1, 1q�6%   ���#444$ 
0, 0, 0, 0��5      $��
0, 0, 0, 0q�6)   8�� 5      F� 5      $��Arrow��6   $��1��6    =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=�5      ���#444$��Center=�5      5       5   
   P� 5       �@J�IsMouseOver$
 True��67   . �5      �� $ ButtonBorder��65    � ��
	 �����6O   5       P� 5!       �@d�	IsChecked$
 TrueY�68   . �5"      �� $ ButtonBorder��65    � ��
	 �����6O   �� 5#      $ Arrow��6/    � ��	 �	#FF8D979E6B   5$      P� 5%       � {�$ False��65   . �5&      �� $ Border��65   8	   � ��6I   �� 5'      $ ButtonBorder��65   8	   � ��6O   �� 5(      $ ButtonBorder��67   8	   � ��6Q   �� 5)      8	   � ��6;   �� 5*      $ Arrow��6/    � ��	 �#9996B   5+      5-      �� 5/      "
 ��6'   .�50   
   ��  �@J�SnapsToDevicePixels$
	 True��60   �� 51   
    �@�OverridesDefaultStyle$
	 True��62   �� 52   
    � ��$
	 Auto=�6G   �� 53   
    � ��$
	 Auto=�6E   �� 54   
    � ��$
	 True��6:   �� 55   
    � ��
	 �   �63   �� 56   
    �@�FocusVisualStyle	 6-   Z� �� 57   
    � ��	 58      �� 59      " ��6"   .R�5:      �  5;      �� 5<      �� 5=      �� 5>      .+�5@      d� $��ToggleButton��6'   $��2��6;   $ Press=�5A   '   $|�False��69   8��   5B   '   �� $ IsDropDownOpen� �� *TemplatedParent+$ TwoWay=�5C   '   �� 5E      $��ContentSite��6;   $��0��6+   $��5, 3, 23, 3q�6N   $ False��6c   $
��Left=�5F   +   $��Center=�6F   #��z 5G   +   #��z 5H   +   #��z��5I   +   �� 5J      $��PART_EditableTextBox��62   $��0��6"   $��3, 3, 23, 3q�6N   # z 5K   "   $y�Hidden=�5L   "   
������ $
��Left=�5M   "   $��Center=�6=   $
|�True��5N   "   .��64   ��5O      �� 5P   "   " ��62   .R�5Q   &   �� $��PART_ContentHost��6-   $|�False��6E   5R   #   .��5S   0   5T      � 5V      $��Popup��60   $��0��6    $��Bottom=�6=   $|�False��5W       $
 True��62   #��z 5X       $��Slide=�5Y       .��5Z      � $��DropDown��6#   $
 True��63   #��z 5[      #��z 5\      .+�5]   "   �� $��DropDownBorder��6)   
�������$��
0, 1, 0, 0q�6R   $ 0��5^      $��1,1,1,1q�6*   8�� 5_      �� 5`   "   $��4q�6/   $
 True��6:   .��5a   &   �� $ 	Contained=�65   5b   #   5c      5d      5e       5f      P� 5g       �@��HasItems$ False��6C   . �5h      �� $ DropDownBorder��6K    � ��$	 95��6g   5i      P� 5j       � {�$ False��6A   . �5k      �� 8	   � ��6G   5l      P� 5m       �@��
IsGrouping$
 True��6E   . �5n      ��  � ��$	 False��6N   5o      P� 5p       �@��
IsEditable$
 True��6A   . �5q      ��  �@  	IsTabStop$	 False��6M   �� 5r      $ PART_EditableTextBox��6E    � y�$	 Visible=�6g   �� 5s      $ ContentSite��6E    � y�$	 Hidden=�6^   5t      5v      5x      5y      5{      