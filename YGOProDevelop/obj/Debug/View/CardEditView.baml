   M S B A M L   `   `   `  ����H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  5   	   Q-clr-namespace:YGOProDevelop.CardEditor.ConfigYGOProDevelop.CardEditor.Config  5   	   K*clr-namespace:YGOProDevelop.View.ConverterYGOProDevelop.View.Converter  5   	   A%clr-namespace:YGOProDevelop.ViewModelYGOProDevelop.ViewModel  5	   	   %    YGOProDevelop.View.CardEditView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:YGOProDevelop.View     5   	   =cfg-clr-namespace:YGOProDevelop.CardEditor.Config     5   	   :cvt*clr-namespace:YGOProDevelop.View.Converter     5   	   4vm%clr-namespace:YGOProDevelop.ViewModel     5	   	   f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5
   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          � Title$  CardEditView��5   	   $��704.846��6   $��682.643��6/    � WindowStartupLocation$ CenterOwner=�6@    � Topmost .  � 
ResizeMode$ NoResize=�6s    � DataContext 5      1   +YGOProDevelop.ViewModel.CardEditorViewModel  5   
   6$    � 	Resources 5      8   2YGOProDevelop.View.Converter.Datas2SourceConverter   	id2source3   -YGOProDevelop.CardEditor.Config.SettingConfig  cfg  WrapItemsPanelTemplate K� IsItemsHost � Orientation  FocusVisual �� Property	 �� Value
 J� SnapsToDevicePixels �� StrokeDashArray  Item.MouseOver.Background �� Color  Item.MouseOver.Border $  Item.SelectedInactive.Background   Item.SelectedInactive.Border " Item.SelectedActive.Background 	 Item.SelectedActive.Border 
 ListBoxItemStyle1 �� 
TargetType �� RelativeSource �� AncestorType �� 
TargetType ��Name �� Padding d� 	IsChecked �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value�� 5   
   %]  &	        &	      &	 &     &	 i     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7  7  7    5      6<     5      6.   �� 5      .R�5      �  . $ Vertical=�6/   5      �� 5      .�5      ��  � ��	 5      �� 5      .R�5      �� $��2q�6(   
 . #��� ��6N   $��1��6�   $	 1 2R�6�   5      5!      5"      �� 5#      $ 	#1F26A0DA��6@   �� 5$      $ 	#a826A0Da��6<   �� 5%      $ 	#3DDADADA��6G   �� 5&      $ 	#FFDADADA��6C   �� 5'      $ 	#3D26A0DA��6E   �� 5(      $ 	#FF26A0DA��6A   �� 5)      " ��6.   .�5*      ��  �@J�SnapsToDevicePixels	 . 68   �� 5+       � ��$		 4,1q�6,   �� 5,       � ��	 6?   �� *HorizontalContentAlignment+ �� " ���� 5-       � ��	 6=   �� *VerticalContentAlignment+ �� " ���� 5.       � ��
	 ���� 6/   �� 5/       � ��
	 ���� 60   �� 50       � ��$	 1q�64   �� 51       �@�FocusVisualStyle8	   65   �� 52       � ��	 53      �� 54      " ��6*   .R�55      �� $ Bd��6%   #��z��61   #��z��6]   #��z��6�   # z��6�   
 . ._�56   "   �� $
��Auto��6+    69   �� *
IsSelected+.��57   &   �� #��z��67   #
 z
 6z   #��z��6�   58   #   59       5:      ]� 5;   "    5<   &   �� 5=   *    �@J�IsMouseOver . 6K   ./�5?   &   �� $ Bd��6C   8	   � ��6S   �� 5@   &   $ Bd��6D   8	   � ��6T   5A   #   P� 5B   "    � {� .  . �5C   &   �� $ Bd��6O   #	 � ��6_    � ��5D   #   5F      5H      5I      5J      .��5L      �  � RowDefinitions 5M   
   �� 5N      $��52 �6   �� 5O      $	��213 �6   �� 5P      $
��382* �6   �� 5Q      $��29 �6    � ColumnDefinitions 5S   
   �� 5T      �� 5U      $	��185 �6   .+�5W   
   �� $��1��6   $��2��6t   $��0,8,10,0q�6�   ��6    �� *Card+ �� 	Converter# [   �� ConverterParameter$	 Pic��6�   �� 5X   
   $��1��6   $��2��6%   $��0,0,10,6q�62   .@�5Y      �� $��效果描述��6   .��5Z      � ���	#FFE5E5E5.+�5[      �� -   5         ��Name$ textBox��5[        �� TextWrapping$
  Wrap=�6/   ! �� AcceptsReturn! . ��6C   �� *Card.texts.desc+6d   5\      5]      �� 5^      $��脚本文本��6   .��5_      � -   5        " �Name$
" grid��5_      ���	#FFE5E5E5.+�5`      �� $��Disabled=�6   @�5a      �� 5b      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str1+# �� Mode$# TwoWay=�6w   �� 5c      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str2+$# TwoWay=�6w   �� 5d      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str3+$# TwoWay=�6w   �� 5e      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str4+$# TwoWay=�6w   �� 5f      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str5+$# TwoWay=�6w   �� 5g      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str6+$# TwoWay=�6w   �� 5h      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str7+$# TwoWay=�6w   �� 5i      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str8+$# TwoWay=�6w   �� 5j      $	��130��6U   $
  Wrap=�6a   ��6&   �� *Card.texts.str9+$# TwoWay=�6w   �� 5k      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str10+$# TwoWay=�6x   �� 5l      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str11+$# TwoWay=�6x   �� 5m      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str12+$# TwoWay=�6x   �� 5n      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str13+$# TwoWay=�6x   �� 5o      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str14+$# TwoWay=�6x   �� 5p      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str15+$# TwoWay=�6x   �� 5q      $	��130��6V   $
  Wrap=�6b   ��6&   �� *Card.texts.str16+$# TwoWay=�6x   5x      5y      5z      5{      �� 5|   
   $
��Left=�6   $��10,8,0,0q�6-   $
  Wrap=�6?   $	��266��6�   $��29.333(�6�   ��6S   �� *Card.texts.name+$# TwoWay=�$ �� UpdateSourceTrigger$$ 	LostFocus=�6�   A� 5}   
   $��10,10,16,10q�6   % A� Columns$% 4��6+   & A� Rows$& 7��67   $��1��6@   .+�5~      �� $��	卡密：��6   $��0,5,5,5q�6"   $��2q�64   �� 5      $
  Wrap=�6   $��2q�6+   $��Center=�66   ' �� 
IsReadOnly' . ( � ToolTip$�( �卡密是数据库中的主键值，必须是唯一的。随意修改可能会导致卡密重复游戏崩溃。因此本编辑器为安全起见，卡片创建时确定卡密，创建之后就不允许修改卡密。��6�   ��6X   �� *	Card.id+6�   �� 5�      $��同名卡：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $
  Wrap=�6   $��2q�6F   $��Center=�6Q   ��6*   �� *
Card.alias+6Q   �� 5�      $��
系列1：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *
SetCodes+) �� Source#) [ * �� SelectedValue* 6`   �� *Card.SetCode1+$$ PropertyChanged=�( 6�   �� *Card.SetCode1.Value+�� 5�      $��
系列2：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *
SetCodes+#) [ * 6`   �� *Card.SetCode2+6�   �� 5�      $��
系列3：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *
SetCodes+#) [ * 6`   �� *Card.SetCode3+6�   �� 5�      $��
系列4：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *
SetCodes+#) [ * 6`   �� *Card.SetCode4+6�   �� 5�      $��	规则：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $��2q�6   $��Center=�6}   ��6"   �� *Ots+#) [ * 6[   �� *	Card.Ot+6}   �� 5�      $��	属性：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *
Attributes+#) [ * 6b   �� *Card.Attribute+6�   �� 5�      $��	种族：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $��2q�6   $��Center=�6�   ��6"   �� *Races+#) [ * 6]   �� *	Card.Race+6�   �� 5�      $��	等级：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $��2q�6   $��Center=�6�   + �� DisplayMemberPath$+ Description��6�   , �� SelectedValuePath$, Value��6�   ��6"   �� *	StarLevel+#) [ * 6b   �� *
Card.Level+$# TwoWay=�6�   �� 5�      $��ATK：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $
  Wrap=�6   $��2q�6D   $��Center=�6O   ��6*   �� *
Card.atk+6O   �� 5�      $��DEF：��6   $��0,5,5,5q�6#   $��2q�65   �� 5�      $
  Wrap=�6   $��2q�6D   $��Center=�6O   ��6*   �� *
Card.def+6O   �� 5�      $��	左摆：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $
  Wrap=�6   $��2q�6R   $��Center=�6]   ��6*   �� *	Card.Left+$# OneWay=�6]   �� 5�      $��	右摆：��6   $��0,5,5,5q�6"   $��2q�64   �� 5�      $
  Wrap=�6   $��2q�6S   $��Center=�6^   ��6*   �� *
Card.Right+$# OneWay=�6^   5�      �� 5�   
   $��类型��6   $��
10,10,16,0q�6   $��2��63   $	��Top=�6@   $	��180��6X   .��5�      �� #���  6   #��� 
 6L   $��Disabled=�6�   - �� SelectionMode$- Multiple=�6�   $+ Content��6�   ��6�   �� *Types+5�      5�      �� 5�   
   $��效果分类��6   $��10,196,16,6q�6!   $��2��66   .��5�      �� #���  69   #��� 
 6o   $��Disabled=�6�   $	��Top=�6�   $- Multiple=�6�   $+ Content��6  ��6   �� *
Categories+6  5�      �� 5�   
   $��提交修改��6   $��	278,3,0,5q�6    $��3��63   $
��Left=�6k   $��76��6�   . �� 	IsDefault. . ��6@   �� *	SubmitCmd+$# OneWay=�6�   �� 5�   
   $��撤销修改��6   $��0,3,21,0q�6    $��3��62   $��21��6?   $	��Top=�6K   $��Right=�6�   $��74��6�   ��6c   �� *
ResetCmd+$# OneWay=�6�   5�      5�      