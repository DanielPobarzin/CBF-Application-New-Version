   M S B A M L   `   `   `  ����F  BApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:Application.Utilities;assembly=ApplicationApplication.Utilities  5      E AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels 5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollThumbs  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName �� Angle  Play_Default  Play_Def  Play_MouseOver  Play_Mo  PlayBtn_Background �� ImageSource j� Stretch  PlayBtn_IsMouseOver  PlayBtn_IsPressed  Stop_Def 	 PlayBtn_Style�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      AMenu8clr-namespace:Application.Utilities;assembly=Application  5      E	ViewModel7clr-namespace:ViewModels.ViewModels;assembly=ViewModels  5      %T  &	        '�� {    &	 X	    7  &	 �	    7  &	 �	    7  &	 �	    7  &	  
    7  &		 *
    7  7  7  �� 5      "  n�5	      .�5
   
   ��  � �� 5      �� 5      " n�6"   .R�5      � $
 Grid��6   .+�5      �� $��Stretch=�6$   $��Stretch=�5   $   $
��Auto��5   $   $
��Auto��5   $   
������ 5   $   �� 5      $ 
Rectangle1��6!   $ 5��5   !   $��Stretch=�5   !   $��Stretch=�5   !   $
��Auto��5   !   $
��Auto��5   !   #��z��5   !   5       5      P� 5       �@�Tag$	 
Horizontal��5   "   . �5      �� $
 
Rectangle1��6%    � ��$
 Auto��5    %   �� 5!      $
 
Rectangle1��6%    � ��$ 7��5#   %   5$      5&      5(      5)      �� 5+      "  ��5,      .�5-   
   ��  �@��IsFlicksEnabled$ false��5.      �� 5/   
    � �� �#8C8C8C50      �� 51   
    � ��
 ���� 52      �� 53   
    � ��$ 8��54      �� 55   
    � �� 56      �� 57      " ��6"   .R�58      � $ GridRoot��6   $��8��59      #��z��5:       5;      �� 5<      $��0.00001* �6,   .+�5>      ]� $ 
PART_Track��6    $��0��5?       $
��true��5@       $|�false��5A        5B      n� 5C   "   $ Thumb��6(   #��z��5D   (   #���   5E   (    5G      �� 5H   "   $ PageUp��6/   $��ScrollBar.PageDownCommand��5I   /   $ 0Q�5J   /   $|�false��5K   /    5M      �� 5N   "   $ PageDown��6/   $��ScrollBar.PageUpCommand��5O   /   $ 0Q�5P   /   $|�false��5Q   /   5S      5T       5U      P� 5V      $ Thumb��6"    �@J�IsMouseOver$
	 true��5X   "   5Y      P� 5Z      $ Thumb��6"    �@n�
IsDragging$
	 true��5\   "   5]      P� 5^       � {�$	 false��5_   "   . �5`      �� $
 Thumb��6%    � y�$ 	Collapsed=�5b   %   5c      P� 5d       �@��Orientation$	 
Horizontal=�5e   "   . �5f      �� $
 GridRoot��6%    �@�LayoutTransform 5h   "   �� 5i   &   $	 -90Q�66   5k      �� 5l      $
 
PART_Track��6%    �@�LayoutTransform 5n   "   �� 5o   &   $	 -90Q�66   5q      �� 5r       � ��$
 Auto��5s   %   �� 5t       � ��$ 8��5u   %   �� 5v      $
 Thumb��6%    �@�Tag$ 
Horizontal��5x   %   �� 5y      $
 PageDown��6%    � ��$ ScrollBar.PageLeftCommand��5{   %   �� 5|      $
 PageUp��6%    � ��$  ScrollBar.PageRightCommand��5~   %   5      5�      5�      5�      �� 5�      8��  $��Uniform=�5�      �� 5�      8��  $��Uniform=�5�      �� 5�      8   $ Uniform=�5�      �� 5�      8   $ Uniform=�5�      �� 5�      8   $ Uniform=�5�      �� 5�      "  d�5�      .�5�   
   ��  � �� 5�      �� 5�      " d�6"   .R�5�      �� $ border��6   8��  ._�5�      �� 5�       5�      P� 5�       �@J�IsMouseOver$
	 True��5�   "   . �5�      �� $
 border��5�   %   8   � ��5�   %   5�      P� 5�       �@d�	IsChecked$
	 TrueY�5�   "   . �5�      �� $
 border��5�   %   8   � ��5�   %   5�      5�      5�      5�      5�      