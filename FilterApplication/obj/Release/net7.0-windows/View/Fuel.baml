   M S B A M L   `   `   `  ���� E  AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.ViewModels;assembly=ViewModelsViewModels.ViewModels   FilterApplication!   FilterApplication.View.Fuel   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     k gTelerik.Windows.Cloud.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k	 gTelerik.Windows.Controls.Chart, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7t
 pTelerik.Windows.Controls.Chart.Direct2D, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7v rTelerik.Windows.Controls.ConversationalUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r nTelerik.Windows.Controls.DataServices, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7w sTelerik.Windows.Controls.DataVisualization, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Diagrams, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.Diagrams.Extensions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7u qTelerik.Windows.Controls.Diagrams.Ribbon, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7y uTelerik.Windows.Controls.EntityFrameworkCore, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Expressions, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.FileDialogs, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Media, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q  mTelerik.Windows.Controls.RichTextBox, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r! nTelerik.Windows.Controls.ScheduleView, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q" mTelerik.Windows.Controls.Spreadsheet, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s# oTelerik.Windows.Controls.SpreadsheetUI, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r$ nTelerik.Windows.Controls.SyntaxEditor, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q% mTelerik.Windows.Controls.VirtualGrid, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a& ]Telerik.Windows.Data, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k' gTelerik.Windows.Documents.Core, Version=2023.1.104.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q( mTelerik.Windows.PersistenceFramework, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l) hTelerik.Windows.Scheduling.Core, Version=2023.1.117.70, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�telerik1http://schemas.telerik.com/2008/xaml/presentation#   	 
                        ! " # $ % & ' ( ) �
viewmodels7clr-namespace:ViewModels.ViewModels;assembly=ViewModels#   	 
                        ! " # $ % & ' ( )   %� IsVirtualizing$
  True�� %� IsContainerVirtualizable$
 True�� %� VirtualizationMode$ 	Recycling=�! %� IsVirtualizingWhenGrouping$
 True�� %� CacheLengthUnit$ Pixel=� %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 10000  %� 
ScrollUnit$ Pixel=�   
Page_Style#��[   � 	Resources 7  1Telerik.Windows.Controls.InvertedBooleanConverter  InvertedBooleanConverter   MultipleSelectionBoxTemplate �� ElementName	 �� Path
 �� StringFormat  CheckBoxItemTemplate ��Name.  (Telerik.Windows.Input.Touch.TouchManager"   ShouldSuspendMousePromotion �� RelativeSource �� AncestorType d� 	IsChecked  NormalItemTemplate  GridViewDataColumnStyle �� 
TargetType1  +Telerik.Windows.Controls.GridViewDataColumn-  'Telerik.Windows.Controls.GridViewColumn �� Property �� Value6  0Telerik.Windows.Controls.GridViewBoundColumnBase��%{  &	       &	      &	 �     &	 G    &	 k      �� .R��� 
���   �$��Italic$����� $ radComboBox��$	 SelectedItems.Count�$1
 +Выбрано типов топлива: 0���� .R��� $ cb��$
 True������ *	BrandFuel+����  ��  telerik:RadComboBoxItem$	 
Foreground� ��  ��  telerik:RadComboBoxItem$	 
IsSelected��� .R��� ���� *	BrandFuel+�� "  .���  �@ TextWrapping$
 Wrap=���  �@ HeaderTextAlignment$ Center=���  �@ HeaderTextWrapping$
 Wrap=���  �@ MinWidth$ 50Q���  �@ ValidatesOnDataErrors$ 
InViewMode=�.��� 
������ .+��� ���#212529���#3A4149$��5q� �� CornerRadius$ 8,8,0,8��._��� $
  True��$
 True��$ 	Recycling=�$
 True��$ Pixel=�$
 1000 $
 Item=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��1* ��� $
��Auto � � ColumnDefinitions �� $��1* ��� $��1* �.+��� $��4��$��2��$��0 0 0 30q�$
��1000��$
��1000�� J� Opacity$	 0.6Q�$��Right=�$��Bottom=�$&�� /Resources/Images/fuels_page.png��$��Uniform=���  �� Orientation$ 
Horizontal=�$��Center=�$��0��$��2��$��0,50,0,5q�.+�(  "Telerik.Windows.Controls.RadButton    LoadDataFromDataBase#��[ ���� *GetAllCommand+    SaveDataToDataBase#��[ ���� *GeneralInsertCommand+���� *Fuels+*  $Telerik.Windows.Controls.RadGridView  -   $��	fuelsGrid��8	  2Telerik.Windows.Controls.GridView.BaseItemsControl 	  GroupRenderMode$
 Flat=�$��1��$��2��$��8,15,8,8q�$
��Auto��$	��Top=�;
  5Telerik.Windows.Controls.GridView.GridViewDataControl 
  AutoGenerateColumns$ False�� 
  
IsReadOnly$ False�� 
  RowIndicatorVisibility$ 	Collapsed=� 
  DataLoadMode$ Asynchronous=� 
  NewRowPosition$ Bottom=�$
  True��$
 True��$ 	Recycling=�$
 True��$
 Item=�$ 10 $
 Item=� 
  ShowColumnHeaders$
 True�� 
  ShowSearchPanel$
 True��  
  ShowColumnSortIndexes$
  True��&! 
  IsLocalizationLanguageRespected$
! True��* & $Telerik.Windows.Controls.DataControl"   ItemsSource" �� *Fuels+# �� UpdateSourceTrigger$# PropertyChanged=�$ �� Mode$$ TwoWay=�% �� IsAsync$
% True��& 
  Columns&   '   Header$' Топливо��#���  (   DataMemberBinding( �� *	BrandFuel+$# PropertyChanged=�$$ TwoWay=�$
% True��  $' Марка топлива��#���  ( �� *Type+$# PropertyChanged=�$$ TwoWay=�$
% True��  $A' ;Низшая теплота сгорания Q, МДж/кг��#���  ( �� *LowerHeatCombustion+$# PropertyChanged=�$$ TwoWay=�$
% True��  $	' S,%��#���  ( �� *SulfurContent+$# PropertyChanged=�$$ TwoWay=�$
% True��  $
' А,%��#���  ( �� *
AshContent+$# PropertyChanged=�$$ TwoWay=�$
% True��  $	' W,%��#���  ( �� *
Humidity+$# PropertyChanged=�$$ TwoWay=�$
% True��  $	' N,%��#���  ( �� *
NContent+$# PropertyChanged=�$$ TwoWay=�$
% True��  $I' CТеоретический объем воздуха Vв, м³/кг��#���  ( �� *TheoreticalAirVolume+$# PropertyChanged=�$$ TwoWay=�$
% True��  $C' =Теоретический объем газа Vг, м³/кг��#���  ( �� *TheoreticalVolumeGas+$# PropertyChanged=�$$ TwoWay=�$
% True��  $X' RТеоретический объем водяных паров Vвпо, м³/кг��#���  ( �� *TheoreticalVolumeWaterVapor+$# PropertyChanged=�$$ TwoWay=�$
% True��  $8' 2Медианный диаметр золы d50, м��#���  ( �� *MedianDiameterAsh+$# PropertyChanged=�$$ TwoWay=�$
% True��  $Q' KНапряженность электрического поля E, кВ/м��#���  ( �� *ElectricFieldStrength+$# PropertyChanged=�$$ TwoWay=�$
% True��  $A' ;Коэффициент обратной короны Кок��#���  ( �� *CoefficientReverseCrown+$# PropertyChanged=�$$ TwoWay=�$
% True��  $\' VУдельное электрическое сопротивление золы, lg(p)��#���  ( �� *ElectricalResistanceAsh+$# PropertyChanged=�$$ TwoWay=�$
% True���� $��2��$	��Top=�$
��Left=�$��0��$	 0.9Q����#373E46$��10q�$	��250��$	��450��$ 25��._��� $
��Auto=�$��10q�$
  True��$ 	Recycling=�.���� ) �� 
IsReadOnly$
) True��
������ ���#DCE0E4
������ $
  True��$ Standard=�. �/� .T�J� $��Fonts/#Raleway SemiBold)�$��20(�* �� Padding$* 	10 10 0 0q�.*�К ознакомлению�� $��Fonts/#Raleway SemiBold)�$��14(�$* 5 0 0 0q�.�J� + J� 
TextIndent$+ 10��.*���В теплоэнергетике существует такое понятие, как проектное топливо. Это топливо, для работы на котором рассчитана конкретная ТЭЦ. Выбор проектного топлива, как правило, обусловлен целым комплексом различных факторов: экономических, географических, технических и т. п. Таким образом, здесь важно не просто какого цвета уголь, а его марка.J� $+ 10��.*���Каменные и бурые угли сильно отличаются по важным характеристикам. Это и температура сгорания, и зольность, и содержание серы и азота. Оборудование теплоэлектростанций строится под определенный вид угля, для того чтобы использовать топливо максимально эффективно и также максимально, насколько возможно, очищать выбросы.J� $+ 10��.*���При анализе возможности и последствий перевода ТЭС на непроектный уголь сравнение по уровню выбросов твѐрдых частиц обычно выполняется при принятии неизменной эффективности золоулавливающих устройств, то есть изменение выбросов зависит только от приведѐнной зольности. Естественно, что при переходе на более зольные угли выбросы твѐрдых частиц увеличиваются. Реально при изменении качества топлива на ТЭС, оборудованных электрофильтрами, количество выбросов золы может изменяться не только в силу различий в количестве балласта, но и из-за изменения эффективности работы электрофильтров. Известны случаи отказа от использования подходящего по другим характеристикам угля из-за высокой стоимости необходимой реконструкции электрофильтров для удовлетворения экологических требований. Забегая вперѐд, отметим, что улучшение экологической ситуации за счѐт снижения выбросов оксидов серы путѐм замены угля менее сернистым часто ведѐт к ухудшению улавливания золы в электрофильтрах� -   , �Name$
, root��$��20q�$��2��$
��Left=�$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�� $��0��.+��� .+�$  Telerik.Windows.Controls.Label  $��10q�$-��'Выбраны виды топлива:��$��0q�$��Century Gothic)�
��������� $ 10��$��Stretch=�$��Stretch=����#3A4149$	 0.9Q�._��� ���� $ radComboBox��$	 SelectedItems����� .R��� $��12(�$��5 5 5 0q�$��Century Gothic)�
��� ������� *	BrandFuel+*  $Telerik.Windows.Controls.RadComboBox  -   -  Name$- radComboBox��$��10q�$	��400��$��1��.   	EmptyText$>. 8Выберите топливо для расчета...��$��Century Gothic)�/   AllowMultipleSelection$
/ True��0 �� SelectedValuePath$0 	BrandFuel��1 w� TextPath$1 	BrandFuel��#��[ ���� *Fuels+!2   MultipleSelectionSeparator2 �� $  MultipleSelectionSeparator��$
	 Text�$$ TwoWay=�3   
IsEditable3 �� *	IsChecked+$ 
IsEditable���� $��2��$ Vertical=�.+�    	SelectAll#���  $
��Left=�2  ,Telerik.Windows.Controls.RadComboBoxCommands4   	SelectAll#��Z4 ���� $ radComboBox��   	 UnselectAll#��� 	 $
��Left=�5   UnselectAll#��Z5 ���� $ radComboBox��+  %Telerik.Windows.Controls.RadDataPager  -   6  Name$6 radDataPager��$��Century Gothic)�$��3��$��12(�7   DisplayMode$	7 All=�8   PageSize$8 10��$
{�True��9   IsTotalItemCountFixed$
9 True��$��2��:   Source: �� $ 	fuelsGrid��$	 Items�