   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.ProductT   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��5 �6   �� 5      $	��330 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��670 �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��save��5      $��2��6   $��3��6-   $
��save��6:   $��5q�6\   $��Comic Sans MS)�6g   $��16(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 0.744Q�61   5      5      �� 5   
   -   5        $��
tablePanel��5   &   $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gridProduct��5   {   $��1��6^   $��0��6k      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   	   SelectionMode$	 Extended=�6�   
 �� AlternationCount$
 2��6�      AreRowDetailsFrozen . $��	10,10,0,0q�6.  $	��325��6A  ��6�   �� ��6N  Z� ��6d  Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6&    �� Opacity$	 0.3Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        	cName��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5    Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Name+6Q     5!      -   5        	cType��$
 Type��5!   Q    68   �� *Type+6Q     5"         
IsReadOnly . -   5        
cInvID��$ Inventory ID��5"   k    6K   �� *InventoryID+6k     5#      -   5        	cLocation��$ Location��5#   Y    6<   �� *
Location+6Y     5$       . -   5        cInS��$ 	In Stock?��5$   e    6I   �� *	INStock+6e     5%      -	   5        
cCount��$ Stock Count��5%   X    69   �� *
StockCount+6X     5&      -
   5        
cPrice��$ Price��5&   S    69   �� *Price+6S     5'      -   5        cWhenTo��$ WhenToOrder��5'   Z    6:   �� *WhenToOrder+6Z      RowDetailsTemplate 5)      �� 5*      .R�5+      �� ._�5,      �� $	��stk��6)   .+�5-   "   �� $��headLine��6(   $*��$You can change the following fields:��68   $
��Left=�6g   $��40��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��170��6�   �� 5.   "   $
��name��6(   $��Name :��64   $
��Left=�6E   $��30��6`   $��20,0,0,0q�6l   $	��Top=�6~   $	��170��6�   �� 5/   "   $��editName��6*   $
��Left=�6:    �� 
IsReadOnly .  $��30��6   $��180,-25,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6i   �� *Name+6�   �� 50   "   $
��type��6(   $��Type :��64   $
��Left=�6E   $��30��6`   $��20,0,0,0q�6l   $	��Top=�6~   $	��170��6�   �� 51   "    ��Name$ Atype��6+   $��25��6:    �� Text$  ��6F   $	��130��6N    �� 
IsReadOnly .  $��-147,-25,0,0q�6n   .@�52   &   ��  ��Name$ electra��63   $��Electronics��6D   �� 53   &   $ fashion��63   $��Fashion��6D   �� 54   &   $
 food��63   $
��Food��6A   �� 55   &   $ HoAGa��63   $��Home And Garden��6B   56   #   �� 57   "   $��depID��6(   $ ��Location (department ID) :��65   $
��Left=�6Z   $��30��6u   $��20,0,0,0q�6�   $	��Top=�6�   $	��170��6�   �� 58   "   $��editLocation��6*   $
��Left=�6>    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6m   �� *
Location+6�   �� 59   "   $��stock��6(   $��Stock Count :��65   $
��Left=�6M   $��30��6h   $��20,0,0,0q�6t   $	��Top=�6�   $	��170��6�   �� 5:   "   $��	editStock��6*   $
��Left=�6;    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6j   �� *
StockCount+6�   �� 5;   "   $��price��6(   $��Price :��65   $
��Left=�6G   $��30��6b   $��20,0,0,0q�6n   $	��Top=�6�   $	��170��6�   �� 5<   "   $��	editPrice��6*   $
��Left=�6;    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6j   �� *Price+6�   �� 5=   "   $��whenTO��6(   $��When To Order:��66   $
��Left=�6O   $��30��6j   $��20,0,0,0q�6v   $	��Top=�6�   $	��170��6�   �� 5>   "   $��editWhen��6*   $
��Left=�6:    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6i   �� *WhenToOrder+6�   �� 5?   "   $
��edit��6)   -   5        $��Save Changes��5?   5   $
��Left=�6L   $��340,-25,0,0q�6g   $	��Top=�6|   $��75��6�   6�   �� 5@   "   $��delete2��6)   -   5        $��Delete��5@   8   $
��Left=�6I   $��440,-25,0,0q�6d   $	��Top=�6y   $��75��6�   6�   5A      5B      5C      5E      5F      �� 5G   
    �� Orientation$ Vertical=�6   $��2��6,   $��1��6@   $��1��6N   .+�5H      �� -   5        $ Atype��5H      $��30��6&   $ Sort By Type��62   $	��110��6F   $��10,30q�6S   .@�5I      �� -   5        $ electra��5I      $��Electronics��60   $��Comic Sans MS)�6c   $��13(�6~   ��5J      �� 5K      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5L      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5M      $ White��6+   $ 0.744Q�69   5N      5P      �� 5Q      -   5        $ fashion��5Q      $��Fashion��60   $��Comic Sans MS)�6[   $��13(�6v   ��5R      �� 5S      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5T      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5U      $ White��6+   $ 0.744Q�69   5V      5X      �� 5Y      -   5        $
 food��5Y      $
��Food��6-   $��Comic Sans MS)�6R   $��13(�6m   ��5Z      �� 5[      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5\      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5]      $ White��6+   $ 0.744Q�69   5^      5`      �� 5a      -   5        $ HoAGa��5a      $��Home And Garden��6.   $��Comic Sans MS)�6_   $��13(�6z   ��5b      �� 5c      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5d      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5e      $ White��6+   $ 0.744Q�69   5f      5h      5i      5j      5l      5m      