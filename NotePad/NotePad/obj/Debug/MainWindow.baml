   M S B A M L   `   `   `  ����B  >NotePad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotePadNotePad  5   	       NotePad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:NotePad     5   	   -   5        $	��App��5   J     � Icon$  icons/notepad2.ico��5   &    � Title$ Unnamed��5   	   $	��450��6   $	��800��6&   
�������.��5	      � .+�5
   
   ]� ��. .+�5      o� 
�������$��18��6(   $	��Top=�65   .@�5      m� $��Center=�6   $��_File��67   $��20��6F   .@�5      m� -   5        $��	NewButton��5      $��Stretch=�60   $	��New��6L    m� InputGestureText$ CTRL+N��6Y   $��20��6s   6   m� 5      -   5        $��
OpenButton��5      $��Stretch=�61   $��Open...��6M   $ CTRL+0��6_   $��20��6y   6�   m� 5      -   5        $��
SaveButton��5      $��Stretch=�61   $
��Save��6M   $��20��6[   $ CTRL+S��6g   6�   m� 5      -   5        $��SaveAsButton��5      $��Stretch=�63   $��Save As��6O   $��20��6`   6�   �� 5      6"   m� 5      -   5        $��
ExitButton��5      $��Stretch=�62   $
��Exit��6N   $��20��6\   6�   5      m� 5      $��Center=�6   $��_Edit��66   $��20��6E   .@�5      m� -   5        $��
UndoButton��5      $��Stretch=�61   $
��Undo��6N   $ CTRL+Z��6\   $��20��6v   6�   �� 5      6"   m� 5      -   5        $��	CutButton��5      $��Stretch=�60   $	��Cut��6M   $ CTRL+X��6Z   $��20��6t   6�   m� 5      -	   5        $��
CopyButton��5      $��Stretch=�61   $
��Copy��6N   $ CTRL+C��6\   $��20��6v   6�   m� 5      -
   5        $��PasteButton��5      $��Stretch=�62   $��Paste��6N   $ CTRL+V��6]   $��20��6w   6�   m� 5      -   5        $��DeleteButton��5      $��Stretch=�63   $��Delete��6O   $	 Del��6_   $��20��6v   6�   m� 5      -   5        $��SelectAllButton��5      $��Stretch=�66   $��
Select All��6R   $ CTRL+A��6f   $��20��6�   6�   5      m� 5       $��Center=�6   $��_Format��66   $��20��6G   .@�5!      m� -   5        $��wordwrapbutton��5!      $��Center=�65    m� IsCheckable . $��
World Wrap��6c   $��20��6w   6�   m� 5"      -   5        $��Center=�5"      $
��Font��6:   $��20��6H   6k   5#      m� 5$      $��Center=�6   $��_View��66   $��20��6E   .@�5%      m� -   5        $��
SttsButton��5%      $��Center=�61    . $��
Status Bar��6_   $��20��6s   6�   5&      m� 5'      -   5        $��Center=�5'      $��_Help��67   $��20��6F   6g   5(      �� 5*      -   5        $��
SttsWindow��5*       �� TextAlignment$ Right=�6*   $y�	Collapsed=�6@   $��Bottom=�6W   $��18��6o   $��16(�6{   $	��Top=�6�   $��0,0,15,0q�6�   5-      �� 5.      -   5        $��scrll��5.      $��Visible=�6(   $��Visible=�6P   .��5/      �� -   5        $��textbox��5/      $��0q�6*   $��0,2,0,0q�6?    �� 
LineHeight$ 1��6Q    �� IsUndoEnabled .  �� 	UndoLimit$ 50��6{    �� AcceptsReturn . $��Consolas)�6�   $��14(�6�   6�   50      52      53      54      