   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.PaymentScreen   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5	      �   � RowDefinitions  5
   
   �� 5      $��4* �6   �� 5      $��1* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
receiptDTG��5      $��0��6%   $��0,12,0,0q�6L      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6^      SelectionMode$ Extended=�6n      
IsReadOnly .    AutoGenerateColumns .  ��6�   �� ��6�   Z� ��6�   Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6"    �� Opacity$	 0.3Q�64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	cName��,  &System.Windows.Controls.DataGridColumn	   Header$	 
Product ID��5   S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *	ProductID+6S     5      -   5        	cType��$
	 Name��5   M   
 64   �� *Name+6M     5      -   5        
cPrice��$	 Price��5   O   
 65   �� *Price+6O     5      -   5        
cCount��$	 Amount��5   P   
 65   �� *Amount+6P   5      �� 5   
   -   5         ��Name$ btn_Pay��5      $��1��68   $��Right=�6E   ��5       �� 5!      .R�5"      �� $��Center=�6   $��Center=�6:   ._�5#      �� $��Images\BuyNow1.jpg��6    $	��100��5$       $��80��5%       5&      5'      5)      �� 5+   
   -   5        $ 	btn_Trash��5+      $y�Visible=�6$    J� 	AllowDrop . $��1��6`   $
��Left=�6m   ��5,      �� 5-      .R�5.      �� $��Center=�6   $��Center=�6:   ._�5/      �� $��Images\trashBin3.jpg��6    $��80��50       $��50��51       52      53      55      �� 57   
   -	   5        $ 
btn_Trash2��57      $y�	Collapsed=�6%    . $��1��6d   $
��Left=�6q   ��58      �� 59      .R�5:      �� $��Center=�6   $��Center=�6:   ._�5;      �� $��Images\trashBin4.jpg��6    $��80��5<       $��50��5=       5>      5?      5A      �� 5B   
   -
   5        $��sumlbl��5B      $�� ��6   $
��Left=�6)   $��	85,10,0,0q�6D   $��1��6W   $	��Top=�6d   $��40��6|   $	��400��6�   5D      5E      