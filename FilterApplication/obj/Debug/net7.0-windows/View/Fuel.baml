   M S B A M L   `   `   `  ����E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels  5       FilterApplication!   FilterApplication.View.Fuel   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k	 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t
 pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q  mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r! nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q" mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s# oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r$ nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q% mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a& ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k' gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q( mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l) hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#   	 
                        ! " # $ % & ' ( ) 5      �
viewModels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels#   	 
                        ! " # $ % & ' ( ) 5        %� IsVirtualizing$
  True��5
       %� IsContainerVirtualizable$
 True��5       %� VirtualizationMode$ 	Recycling=�5      ! %� IsVirtualizingWhenGrouping$
 True��5       %� CacheLengthUnit$ Pixel=�5       %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 10000 5       %� 
ScrollUnit$ Pixel=�5         	PageStyle#��[  5       � 	Resources 5        GridViewDataColumnStyle �� 
TargetType1  +Telerik.Windows.Controls.GridViewDataColumn-  'Telerik.Windows.Controls.GridViewColumn	 �� Property
 �� Value6  0Telerik.Windows.Controls.GridViewBoundColumnBase��%E  &	       �� 5   
   "  60   .�5      �� 	 �@ TextWrapping$

 Wrap=�6-   �� 5      	 �@ HeaderTextAlignment$
 Center=�64   �� 5      	 �@ HeaderTextWrapping$

 Wrap=�63   �� 5      	 �@ MinWidth$
 50Q�6)   �� 5      	 �@ ValidatesOnDataErrors$
 
InViewMode=�66   5      5      .��5      � 
������ .+�5   
   �� ���#212529���#3A4149$��5q�6<    �� CornerRadius$ 8,8,0,8��6P   ._�5      �� $
  True��6   $
 True��5       $ 	Recycling=�5!      $
 True��5"      $ Pixel=�5#      $
 1000 5$      $
 Item=�5%      .��5&      �  � RowDefinitions 5'      �� 5(      $
��Auto �6(   �� 5)      $
��Auto �6(   �� 5*      $��1* �6(   �� 5+      $
��Auto �6(    � ColumnDefinitions 5-      �� 5.      $��1* �6+   �� 5/      $��1* �6+   .+�51      �� $��4��6   $��2��52      $��0 0 0 30q�53      $
��1000��54      $
��1000��55       J� Opacity$	 0.6Q�56      $��Right=�57      $��Bottom=�58      $&�� /Resources/Images/fuels_page.png��59      $��Uniform=�6F   �� 5:       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��0��5;      $��2��6(   $��0��6<   $��0,50,0,5q�5<   !   .+�5=      (  "Telerik.Windows.Controls.RadButton    LoadDataFromDataBase#��[ 6,   ��5>      �� *GetAllCommand+5?        5@        SaveDataToDataBase#��[ 6,   ��5A   ,   �� *GeneralInsertCommand+��6U   �� *Fuels+5B      5C      *  $Telerik.Windows.Controls.RadGridView  5D      -   5        $��	FuelsGrid��5D   *   8  2Telerik.Windows.Controls.GridView.BaseItemsControl   GroupRenderMode$
 Flat=�6;   $��1��6R   $��2��6_   $��0��5E   *   $��8,15,8,8q�5F   *   $
��Auto��5H   *   $	��Top=�5I   *   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns$ False��5J         
IsReadOnly$ False��5L   *      RowIndicatorVisibility$ 	Collapsed=�5M   *      DataLoadMode$ Asynchronous=�5N   *      NewRowPosition$ Bottom=�5O   *   $
  True��5P   +   $
 True��5Q   +   $ 	Recycling=�5R   +   $
 True��5S   +   $
 Item=�5T   +   $ 10 5U   +   $
 Item=�5V   +      ShowColumnHeaders$
 True��5W   *      ShowSearchPanel$
 True��5X   *      ShowColumnSortIndexes$
 True��5Y   *   &   IsLocalizationLanguageRespected$
 True��5Z   *   *	 & $Telerik.Windows.Controls.DataControl 	  ItemsSource 5K   *   �� *Fuels+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� IsAsync$
 True��   Columns 5\        5]         Header$ Топливо��69   #���  6J       DataMemberBinding  5^      �� *	BrandFuel+$ PropertyChanged=�$ TwoWay=�$
 True��  5_      $ Марка топлива��69   #���  6P     5`      �� *Type+$ PropertyChanged=�$ TwoWay=�$
 True��  5a      $A ;Низшая теплота сгорания Q, МДж/кг��69   #���  6d     5b      �� *LowerHeatCombustion+$ PropertyChanged=�$ TwoWay=�$
 True��  5c      $	 S,%��69   #���  6G     5d      �� *SulfurContent+$ PropertyChanged=�$ TwoWay=�$
 True��  5e      $
 А,%��69   #���  6G     5f      �� *
AshContent+$ PropertyChanged=�$ TwoWay=�$
 True��  5g      $	 W,%��69   #���  6G     5h      �� *
Humidity+$ PropertyChanged=�$ TwoWay=�$
 True��  5i      $	 N,%��69   #���  6G     5j      �� *
NContent+$ PropertyChanged=�$ TwoWay=�$
 True��  5k      $I CТеоретический объем воздуха Vв, м³/кг��69   #���  6h     5l      �� *TheoreticalAirVolume+$ PropertyChanged=�$ TwoWay=�$
 True��  5m      $C =Теоретический объем газа Vг, м³/кг��69   #���  6e     5n      �� *TheoreticalVolumeGas+$ PropertyChanged=�$ TwoWay=�$
 True��  5o      $X RТеоретический объем водяных паров Vвпо, м³/кг��69   #���  6p     5p      �� *TheoreticalVolumeWaterVapor+$ PropertyChanged=�$ TwoWay=�$
 True��  5q      $8 2Медианный диаметр золы d50, м��69   #���  6`     5r      �� *MedianDiameterAsh+$ PropertyChanged=�$ TwoWay=�$
 True��  5s      $Q KНапряженность электрического поля E, кВ/м��69   #���  6l     5t      �� *ElectricFieldStrength+$ PropertyChanged=�$ TwoWay=�$
 True��  5u      $A ;Коэффициент обратной короны Кок��69   #���  6b     5v      �� *CoefficientReverseCrown+$ PropertyChanged=�$ TwoWay=�$
 True��  5w      $\ VУдельное электрическое сопротивление золы, lg(p)��69   #���  6s     5x      �� *ElectricalResistanceAsh+$ PropertyChanged=�$ TwoWay=�$
 True��5z      �� 5{      $��2��6   $	��Top=�5|      $
��Left=�5}      $��0��5~      $	 0.9Q�5      ���#373E46$��10q�5�      $	��250��5�      $	��450��5�      $ 25��5�      ._�5�      �� $
��Auto=�6'   $��10q�6J   $
  True��6V   $ 	Recycling=�6�   .��5�      �� ! �� 
IsReadOnly$
! True��6*   
������ ���#DCE0E4
������ $
  True��6�   $ Standard=�6�   . �5�   "   /� .T�5�   &   J� $��Fonts/#Raleway SemiBold)�60   $��20(�6U   " �� Padding$" 	10 10 0 0q�6c   .*�6w   К ознакомлению5�   '   �� 5�   &   $��Fonts/#Raleway SemiBold)�6.   $��14(�6S   $" 5 0 0 0q�6a   .�5�   *   J� # J� 
TextIndent$# 10��64   .*�6D   ��В теплоэнергетике существует такое понятие, как проектное топливо. Это топливо, для работы на котором рассчитана конкретная ТЭЦ. Выбор проектного топлива, как правило, обусловлен целым комплексом различных факторов: экономических, географических, технических и т. п. Таким образом, здесь важно не просто какого цвета уголь, а его марка.5�   +   J� 5�   *   $# 10��64   .*�6D   ��Каменные и бурые угли сильно отличаются по важным характеристикам. Это и температура сгорания, и зольность, и содержание серы и азота. Оборудование теплоэлектростанций строится под определенный вид угля, для того чтобы использовать топливо максимально эффективно и также максимально, насколько возможно, очищать выбросы.5�   +   J� 5�   *   $# 10��64   .*�6D   ��При анализе возможности и последствий перевода ТЭС на непроектный уголь сравнение по уровню выбросов твѐрдых частиц обычно выполняется при принятии неизменной эффективности золоулавливающих устройств, то есть изменение выбросов зависит только от приведѐнной зольности. Естественно, что при переходе на более зольные угли выбросы твѐрдых частиц увеличиваются. Реально при изменении качества топлива на ТЭС, оборудованных электрофильтрами, количество выбросов золы может изменяться не только в силу различий в количестве балласта, но и из-за изменения эффективности работы электрофильтров. Известны случаи отказа от использования подходящего по другим характеристикам угля из-за высокой стоимости необходимой реконструкции электрофильтров для удовлетворения экологических требований. Забегая вперѐд, отметим, что улучшение экологической ситуации за счѐт снижения выбросов оксидов серы путѐм замены угля менее сернистым часто ведѐт к ухудшению улавливания золы в электрофильтрах5�   +   5�   '   5�   #   5�      5�      5�      � 5�      -   5        $ �Name$
$ Root��5�   '   $��20q�6   $��2��65   $
��Left=�6B   $��1��6]    5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   .+�5�      � $��0��6   .+�5�      �� .+�5�   "   $
  Telerik.Windows.Controls.Label
  $��10q�60   $-��'Выбраны виды топлива:��5�   0   $��0q�5�   0   $��Century Gothic)�5�   0   
�������5�   0   �� 5�   "   $ 10��6)   $��Stretch=�6;   $��Stretch=�6W   ���#3A4149$	 0.9Q�6�   ._�5�   &   �� ��63   �� *SelectedFuels+��5�   *   �� 5�   .   .R�5�   2   �� $��12(�5�   <   $��5 5 5 0q�5�   <   $��Century Gothic)�5�   <   
��� �����5�   <   �� *	BrandFuel+5�   3   5�   /   5�   '   5�   #   5�      5�      *  $Telerik.Windows.Controls.RadComboBox  5�      -   5        %  Name$% RadComboBox��5�   .   $��10q�5�   .   $	��400��5�   .   $��1��5�   .   &   	EmptyText$>& 8Выберите топливо для расчета...��5�   .   $��Century Gothic)�5�   .   '   AllowMultipleSelection$
' True��5�   .   ( �� SelectedValuePath$( 	BrandFuel��5�   .   ) w� TextPath$) 	BrandFuel��5�   .   ��5�   .   �� *Fuels+!*   MultipleSelectionSeparator* 5�   .   �� + �� ElementName$ + MultipleSelectionSeparator��, �� Path$
, Text�$ TwoWay=�-   
IsEditable- 5�   .   �� *	IsChecked+$+ 
IsEditable����5�      �� 5�   "   .R�5�   &   �� .  (Telerik.Windows.Input.Touch.TouchManager".   ShouldSuspendMousePromotion$
. True��5�   )   ��5�   )   �� *	BrandFuel+��5�   )   �� / �� RelativeSource/ �� 0 �� AncestorType0 telerik:RadComboBoxItem$, 
Foreground�1 d� 	IsChecked1 5�   )   �� / �� 0 telerik:RadComboBoxItem$, 
IsSelected�5�   )   5�   #   5�      �� 5�      $��2��6%   $ Vertical=�62   .+�5�          	SelectAll#���  60   2  ,Telerik.Windows.Controls.RadComboBoxCommands2   	SelectAll#��Z2 5�   0   ��5�   1   �� $+ RadComboBox��5�        5�        UnselectAll#���  60   3   UnselectAll#��Z3 5�   0   ��5�   /   �� $+ RadComboBox��5�      5�      5�      +  %Telerik.Windows.Controls.RadDataPager  5�      -   5        4  Name$4 RadDataPager��5�   +   $��Century Gothic)�6A   $��3��5�      $��12(�6   5   DisplayMode$	5 All=�5�      6   PageSize$6 10��5�      $
{�True��5�      7   IsTotalItemCountFixed$
7 True��5�      $��2��6%   $��0��69   8   Source8 5�      �� $+ 	FuelsGrid��$, Items�5�   9   5�      5�      5�      5�      5�      