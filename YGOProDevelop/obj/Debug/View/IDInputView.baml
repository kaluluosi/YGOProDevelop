   M S B A M L   `   `   `  ����H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  5   	   A%clr-namespace:YGOProDevelop.ViewModelYGOProDevelop.ViewModel  5   	   $    YGOProDevelop.View.IDInputView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:YGOProDevelop.View     5   	   4vm%clr-namespace:YGOProDevelop.ViewModel     5   	     � Title$  输入卡密��5	   	   $��165.451��6   $��285.837��6'    � 
ResizeMode$ NoResize=�67    � Icon$< 6/YGOProDevelop;component/Resources/等级/level_12.png��6M    � WindowStartupLocation$ CenterOwner=�5
   N    � DataContext 6	   ��    Locator �� Source# [   �� Path$ IDInput�.��5      �  � RowDefinitions 5   
   �� 5      $	��35* �6   �� 5      $	��70* �6   �� 5      $	��31* �6   .+�5   
   �� -   5         ��Name$ label��5      $��卡密:��6   $
��Left=�6-   $��10,7,0,0q�6H   $	��Top=�6Z   �� 5   
   -   5        	 ��Name$	 textBox��5      $��23��6#   $��	52,9,73,0q�6/   
 �� TextWrapping$

 Wrap=�6B   $	��Top=�6W   ��6o   �� *Id+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5         ��Name$ 	textBlock��5      $��	10,2,10,1q�6'   $
��Wrap=�6:   $N��H提示：卡密如果已经存在的话，确定按钮将不能点击。��6N   $��1��6n   �� 5   
   -   5         ��Name$ button��5      $��确定��6!   $
��Left=�6.   $��52,4,0,6q�6I   $��75��6[   $��2��6f   ��6s   �� *	SubmitCmd+�� 5   
   -   5        $ button_Copy��5      $��取消��6&   $��
152,4,51,6q�63   $��2��6G   ��6T   �� *	CancelCmd+�� 5   
   -   5        $ button1��5      $��	随一个��6"   $��0,9,10,0q�6P   $��Right=�6b   $��58��6~   $��23��6�   $	��Top=�6�   ��60   �� *RandomIDCmd+6�   5      5      