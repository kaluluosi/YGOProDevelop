   M S B A M L   `   `   `  ����H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  5      9!clr-namespace:YGOProDevelop.ModelYGOProDevelop.Model  5	      K*clr-namespace:YGOProDevelop.View.ConverterYGOProDevelop.View.Converter  5
      Y1clr-namespace:YGOProDevelop.View.TemplateSelector#YGOProDevelop.View.TemplateSelector  5      %    YGOProDevelop.View.CardListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      ,local clr-namespace:YGOProDevelop.View  5      -model!clr-namespace:YGOProDevelop.Model  5	      4cvt*clr-namespace:YGOProDevelop.View.Converter  5
      @selector1clr-namespace:YGOProDevelop.View.TemplateSelector  5      $
��Auto��5   �   $
��Auto��6�     � 	Resources  5      8   2YGOProDevelop.View.Converter.Datas2SourceConverter   	id2source8   2YGOProDevelop.View.Converter.Datas2StringConverter 	 d2str �� 
TargetType �� Property �� Value �� Orientation �� 	Converter �� ConverterParameter  MonItem � RowDefinitions � ColumnDefinitions	 ��Name
 ��Name  	SpellItem�� 5   
   %�	  &	        &	      '�� &     7   &	 K    7   7   7   7  7  &	 
    7   7   7   7    5      6<     5      68   �� 5      " ��6   .�5      ��  �@�ToolTip 5      _� 5      .��5      �� $ Vertical=�6)   $	��200��6@   .+�5   "   �� ��6(   �� *.+8   $	 Pic��6}   �� 5   "   $
��Wrap=�6H   ��6,   �� *
texts.desc+6^   5      5      5      5      �� 5      .R�5       � $��70��6   $	��200��6#   $	��200��6/    5!      �� 5"      $	��26* �6(   �� 5#      $	��26* �6(   �� 5$      $	��27* �6(    5&      �� 5'      $	��56* �6+   �� 5(      $	��30* �6+   �� 5)      $	��64* �6+   �� 5*      $	��29* �6+   �� 5+      $	��74* �6+   .+�5-      �� $		 Pic��6   $��Stretch=�6)   $
��Auto��6G   $��1,0,0,0q�6�   $��3��6�   ��6T   �� *.+8   $	 Pic��6�   �� 5.      $	 AttributeIcon��6   $��1��63   ��6C   �� *.+8  $ 	Attribute���� 5/      $

 Name��6   $
��Bold"�6*   $��2��6[   $��3��6k   ��6<   �� *
texts.name+6k   �� 50      $	 RaceIcon��6   $��1��6.   $��1��6�   ��6>   �� *.+8  $
 Race��6�   �� 51      $

 Race��6   $��2��6{   $��1��6�   ��6*   �� *.+8  $
 Race��6�   �� 52      $	 	LevelIcon��6   $��3��6/   $=��7/YGOProDevelop;component/Resources/等级/levelStar.png��6?   $��1��6|   �� 53      $
 Level��6   $��4��6E   $��1��6U   ��6+   �� *level+6U   �� 54      $
 AtkDef��6   $��1��6   $��2��6�   $��4��6�   ��6,   �� *.+8  $ AtkDef��6�   55      56      �� 57      .R�58      � $��70��6   $	��200��6#   $	��200��6/    59      �� 5:      $	��26* �6(   �� 5;      $	��26* �6(   �� 5<      $	��27* �6(    5>      �� 5?      $	��56* �6+   �� 5@      $	��30* �6+   �� 5A      $	��64* �6+   �� 5B      $	��29* �6+   �� 5C      $	��74* �6+   .+�5E      �� $		 Pic��6   $��Stretch=�6)   $
��Auto��6G   $��1,0,0,0q�6�   $��3��6�   ��6T   �� *.+8   $	 Pic��6�   �� 5F      $	 TypeIcon��6   $��1��6.   ��6>   �� *.+8  $
 Type���� 5G      $

 Name��6   $
��Bold"�6*   $��2��6[   $��3��6k   ��6<   �� *
texts.name+6k   �� 5H      $	 SubTypeIcon��6   $��1��61   $��1��6�   ��6A   �� *.+8  $ SubType��6�   �� 5I      $
 SubType��6   $��2��6�   $��1��6�   ��6-   �� *.+8  $ SubType��6�   5J      5K      5L      .��5N      ]� .+�5O   
   `� $	��Top=�6   .�5P      c� $��24��6    `� IsLocked . .@�5Q      �� ��6   �� *
OpenCDBCmd+.��68   	打开CDB6?   �� 5R      ��6   �� *	AddNewCmd+.��67   新建卡片6=   �� 5S      ��6   �� *CreateNewCDBCmd+.��6=   	新建CDB6D   5T      5U      � 5V   
   $��Bottom=�6   $��0,2,0,0q�6'    5W      �� 5X      $
��210* �6#   �� 5Y      $��41 �6#   �� 5Z      $��13 �6#   .+�5\      �� -   5         ��Name$ textBox��5\       �� TextWrapping$
 Wrap=�6'   ��6;   �� *	KeyWord+ �� UpdateSourceTrigger$ PropertyChanged=�.��6x   5^      �� 5_      $��搜索��6   $��1��6@    �� 	IsDefault . ��6"   �� *	SearchCmd+6P   �� 5`      -   5         ��Name$ btnMore��5`      $��.��6&   $��2��62   6B   � 5a      -   5         �Name$ popMore��5a      $
��Left=�6b    � 	StaysOpen .   � VerticalOffset$
 -202��6�    � PlacementTarget 6%   ��  �� ElementName$ btnMore�� �� Mode$ OneWay=�.��5b      � $	��200��6   $	��200��6#   .+�5c      �� .��6   临时面板6$   5d      5e      5f      �� 5g   
   -   5         ��Name$ listBox��5g      $	��Top=�6I   $��Disabled=�6�    �� SelectedItem 6#   �� *SelectedCard+��6^   �� *QueryResult+.  (System.Windows.Interactivity.Interaction   Triggers 5h      /  )System.Windows.Interactivity.EventTrigger  5i         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5j      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6)   �� *OpenScriptCmd+6M   5k      ��5m      B   <YGOProDevelop.View.TemplateSelector.CardItemTemplateSelector  5n         MonDataTemplate# [ 64      SpellDataTemplate# [ 6_   6�    � ContextMenu 5p      �� 5q      .@�5r      m� $��打开脚本��6     m� Command  6-   �� *OpenScriptCmd+6Q   m� 5s      $��编辑��6     6+   �� *	EditCmd+6I   m� 5t      $��删除��6     6+   �� *	DeleteCmd+6K   5u      5w      5x      5y      