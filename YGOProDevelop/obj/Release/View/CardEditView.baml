   M S B A M L   `   `   `  ���� H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  Q-clr-namespace:YGOProDevelop.CardEditor.ConfigYGOProDevelop.CardEditor.Config  K*clr-namespace:YGOProDevelop.View.ConverterYGOProDevelop.View.Converter  A%clr-namespace:YGOProDevelop.ViewModelYGOProDevelop.ViewModel  %    YGOProDevelop.View.CardEditView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:YGOProDevelop.View     =cfg-clr-namespace:YGOProDevelop.CardEditor.Config     :cvt*clr-namespace:YGOProDevelop.View.Converter     4vm%clr-namespace:YGOProDevelop.ViewModel     f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -     � Title$  CardEditView��$��704.846��$��682.643�� � WindowStartupLocation$ CenterOwner=� � Topmost .  � 
ResizeMode$ NoResize=� � DataContext 1   +YGOProDevelop.ViewModel.CardEditorViewModel   � 	Resources 8   2YGOProDevelop.View.Converter.Datas2SourceConverter   	id2source3   -YGOProDevelop.CardEditor.Config.SettingConfig  cfg  WrapItemsPanelTemplate K� IsItemsHost � Orientation  FocusVisual �� Property	 �� Value
 J� SnapsToDevicePixels �� StrokeDashArray  Item.MouseOver.Background �� Color  Item.MouseOver.Border $  Item.SelectedInactive.Background   Item.SelectedInactive.Border " Item.SelectedActive.Background 	 Item.SelectedActive.Border 
 ListBoxItemStyle1 �� 
TargetType �� RelativeSource �� AncestorType �� 
TargetType ��Name �� Padding d� 	IsChecked �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value�� %�  &	        &	      &	 
     &	 -     &	 {     &	 �     &	 �     &	 �     &	 �     &		 �     &	
 �     7  7  7      �� .R��  . $ Vertical=��� .���  � ��	 �� .R��� $��2q�
 . #��� ��$��1��$	 1 2R��� $ 	#1F26A0DA���� $ 	#a826A0Da���� $ 	#3DDADADA���� $ 	#FFDADADA���� $ 	#3D26A0DA���� $ 	#FF26A0DA���� " ��.���  �@J�SnapsToDevicePixels	 . ��  � ��$		 4,1q���  � ��	 �� *HorizontalContentAlignment+ �� " ����  � ��	 �� *VerticalContentAlignment+ �� " ����  � ��
	 ���� ��  � ��
	 ���� ��  � ��$	 1q���  �@�FocusVisualStyle8	   ��  � ��	 �� " ��.R��� $ Bd��#��z��#��z��#��z��# z��
 . ._��� $
��Auto�� �� *
IsSelected+.���� #��z��#
 z
 #��z�� ]�  ��  �@J�IsMouseOver . ./��� $ Bd��8	   � ���� $ Bd��8	   � ��P�  � {� .  . ��� $ Bd��#	 � �� � ��.���  � RowDefinitions �� $��52 ��� $	��213 ��� $
��382* ��� $��29 � � ColumnDefinitions �� �� $	��185 �.+��� $��1��$��2��$��0,8,10,0q����� *Card+ �� 	Converter# [   �� ConverterParameter$	 Pic���� $��1��$��2��$��0,0,10,6q�.@��� $��效果描述��.��� ���	#FFE5E5E5.+��� -    ��Name$ textBox��  �� TextWrapping$
  Wrap=�! �� AcceptsReturn! . ���� *Card.texts.desc+�� $��脚本文本��.��� -   " �Name$
" grid�����	#FFE5E5E5.+��� $��Disabled=�@��� $	��130��$
  Wrap=����� *Card.texts.str1+# �� Mode$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str2+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str3+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str4+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str5+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str6+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str7+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str8+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str9+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str10+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str11+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str12+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str13+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str14+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str15+$# TwoWay=��� $	��130��$
  Wrap=����� *Card.texts.str16+$# TwoWay=��� $
��Left=�$��10,8,0,0q�$
  Wrap=�$	��266��$��29.333(����� *Card.texts.name+$# TwoWay=�$ �� UpdateSourceTrigger$$ 	LostFocus=�A� $��10,10,16,10q�% A� Columns$% 4��& A� Rows$& 7��$��1��.+��� $��	卡密：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=�' �� 
IsReadOnly' . ( � ToolTip$�( �卡密是数据库中的主键值，必须是唯一的。随意修改可能会导致卡密重复游戏崩溃。因此本编辑器为安全起见，卡片创建时确定卡密，创建之后就不允许修改卡密。������ *	Card.id+�� $��同名卡：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=����� *
Card.alias+�� $��
系列1：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *
SetCodes+) �� Source#) [ * �� SelectedValue* �� *Card.SetCode1+$$ PropertyChanged=�( �� *Card.SetCode1.Value+�� $��
系列2：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *
SetCodes+#) [ * �� *Card.SetCode2+�� $��
系列3：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *
SetCodes+#) [ * �� *Card.SetCode3+�� $��
系列4：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *
SetCodes+#) [ * �� *Card.SetCode4+�� $��	规则：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *Ots+#) [ * �� *	Card.Ot+�� $��	属性：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *
Attributes+#) [ * �� *Card.Attribute+�� $��	种族：��$��0,5,5,5q�$��2q��� $��2q�$��Center=����� *Races+#) [ * �� *	Card.Race+�� $��	等级：��$��0,5,5,5q�$��2q��� $��2q�$��Center=�+ �� DisplayMemberPath$+ Description��, �� SelectedValuePath$, Value������ *	StarLevel+#) [ * �� *
Card.Level+$# TwoWay=��� $��ATK：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=����� *
Card.atk+�� $��DEF：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=����� *
Card.def+�� $��	左摆：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=����� *	Card.Left+$# OneWay=��� $��	右摆：��$��0,5,5,5q�$��2q��� $
  Wrap=�$��2q�$��Center=����� *
Card.Right+$# OneWay=��� $��类型��$��
10,10,16,0q�$��2��$	��Top=�$	��180��.���� #���  #��� 
 $��Disabled=�- �� SelectionMode$- Multiple=�$+ Content������ *Types+�� $��效果分类��$��10,196,16,6q�$��2��.���� #���  #��� 
 $��Disabled=�$	��Top=�$- Multiple=�$+ Content������ *
Categories+�� $��提交修改��$��	278,3,0,5q�$��3��$
��Left=�$��76��. �� 	IsDefault. . ���� *	SubmitCmd+$# OneWay=��� $��撤销修改��$��0,3,21,0q�$��3��$��21��$	��Top=�$��Right=�$��74������ *
ResetCmd+$# OneWay=�