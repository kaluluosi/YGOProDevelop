   M S B A M L   `   `   `  ���� H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  9!clr-namespace:YGOProDevelop.ModelYGOProDevelop.Model  K*clr-namespace:YGOProDevelop.View.ConverterYGOProDevelop.View.Converter  Y1clr-namespace:YGOProDevelop.View.TemplateSelector#YGOProDevelop.View.TemplateSelector  %    YGOProDevelop.View.CardListView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  ,local clr-namespace:YGOProDevelop.View  -model!clr-namespace:YGOProDevelop.Model  4cvt*clr-namespace:YGOProDevelop.View.Converter  @selector1clr-namespace:YGOProDevelop.View.TemplateSelector  $
��Auto��$
��Auto��  � 	Resources  8   2YGOProDevelop.View.Converter.Datas2SourceConverter   	id2source8   2YGOProDevelop.View.Converter.Datas2StringConverter 	 d2str �� 
TargetType �� Property �� Value �� Orientation �� 	Converter �� ConverterParameter  MonItem � RowDefinitions � ColumnDefinitions	 ��Name
 ��Name  	SpellItem�� %  &	        &	      '�� 
     7   &	 �     7   7   7   7  7  &	 �    7   7   7   7      �� " ��.���  �@�ToolTip _� .���� $ Vertical=�$	��200��.+��� ���� *.+8   $	 Pic���� $
��Wrap=����� *
texts.desc+�� .R�� $��70��$	��200��$	��200�� �� $	��26* ��� $	��26* ��� $	��27* � �� $	��56* ��� $	��30* ��� $	��64* ��� $	��29* ��� $	��74* �.+��� $		 Pic��$��Stretch=�$
��Auto��$��1,0,0,0q�$��3������ *.+8   $	 Pic���� $	 AttributeIcon��$��1������ *.+8  $ 	Attribute���� $

 Name��$
��Bold"�$��2��$��3������ *
texts.name+�� $	 RaceIcon��$��1��$��1������ *.+8  $
 Race���� $

 Race��$��2��$��1������ *.+8  $
 Race���� $	 	LevelIcon��$��3��$=��7/YGOProDevelop;component/Resources/等级/levelStar.png��$��1���� $
 Level��$��4��$��1������ *level+�� $
 AtkDef��$��1��$��2��$��4������ *.+8  $ AtkDef���� .R�� $��70��$	��200��$	��200�� �� $	��26* ��� $	��26* ��� $	��27* � �� $	��56* ��� $	��30* ��� $	��64* ��� $	��29* ��� $	��74* �.+��� $		 Pic��$��Stretch=�$
��Auto��$��1,0,0,0q�$��3������ *.+8   $	 Pic���� $	 TypeIcon��$��1������ *.+8  $
 Type���� $

 Name��$
��Bold"�$��2��$��3������ *
texts.name+�� $	 SubTypeIcon��$��1��$��1������ *.+8  $ SubType���� $
 SubType��$��2��$��1������ *.+8  $ SubType��.��]� .+�`� $	��Top=�.�c� $��24�� `� IsLocked . .@��� ���� *
OpenCDBCmd+.��	打开CDB�� ���� *	AddNewCmd+.��新建卡片�� ���� *CreateNewCDBCmd+.��	新建CDB� $��Bottom=�$��0,2,0,0q� �� $
��210* ��� $��41 ��� $��13 �.+��� -    ��Name$ textBox�� �� TextWrapping$
 Wrap=����� *	KeyWord+ �� UpdateSourceTrigger$ PropertyChanged=�.��.���� $��搜索��$��1�� �� 	IsDefault . ���� *	SearchCmd+�� -    ��Name$ btnMore��$��.��$��2��� -    �Name$ popMore��$
��Left=� � 	StaysOpen .   � VerticalOffset$
 -202�� � PlacementTarget ��  �� ElementName$ btnMore�� �� Mode$ OneWay=�.��� $	��200��$	��200��.+��� .��临时面板�� -    ��Name$ listBox��$	��Top=�$��Disabled=� �� SelectedItem �� *SelectedCard+���� *QueryResult+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. /  )GalaSoft.MvvmLight.Command.EventToCommand     Command �� *OpenScriptCmd+��B   <YGOProDevelop.View.TemplateSelector.CardItemTemplateSelector     MonDataTemplate# [    SpellDataTemplate# [  � ContextMenu �� .@�m� $��打开脚本��  m� Command  �� *OpenScriptCmd+m� $��编辑��  �� *	EditCmd+m� $��删除��  �� *	DeleteCmd+