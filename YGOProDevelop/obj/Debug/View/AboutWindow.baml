   M S B A M L   `   `   `  ����H  DYGOProDevelop, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:YGOProDevelop.ViewYGOProDevelop.View  5   	   $    YGOProDevelop.View.AboutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:YGOProDevelop.View     5   	     � Title$  关于��5   	   $��247.854��6   $	��300��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��176* �6   �� 5      $	��43* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��
10,10,10,0q�6'   $
��Wrap=�6;   $	��159��6O   $	��Top=�6\   ��本编辑器可能不如sublime、notepad++、evernote等魔改后的ygopro编辑器好用，但是自己开发的编辑器有一个自主优势，我可以根据用户 需求开发一些内置的ygopro脚本专用工具来方便大家写脚本。这也是为什么我最后又把这个坑挖出来继续开发的原因。但是没有需求的话， 工具就无法继续改进下去，因此希望使用这个工具的用户，如果你有什么好的建议请给我发邮件反馈给我，我会尽快答复你。，如果我能力 范围内可实现，我就会在下个版本中加入你建议的新功能。5      �� 5   
   -   5         ��Name$ label��5      $��	邮箱：��6   $
��Left=�6-   $��	10,8,0,10q�6H   $��1��6[   �� 5   
   -   5         ��Name$ textBox��5      $��56,10,21,10q�6#    �� TextWrapping$
 Wrap=�68   $��kaluluosi11@qq.com��6L    �� 
IsReadOnly . $��1��6x   5      5      