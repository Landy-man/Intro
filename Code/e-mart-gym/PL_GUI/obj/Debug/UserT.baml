   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.UserT   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��5 �6   �� 5      $	��330 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��670 �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��save��5      $��2��6   $��3��6-   $
��save��6:   $��5q�6\   $��Comic Sans MS)�6g   $��16(�6�   $	��Top=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 0.744Q�61   5      5      �� 5   
   -   5        $��
tablePanel��5   &   $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gridUser��5   4   $��1��6   $��0��6$      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6s   	   SelectionMode$	 Extended=�6�   
 �� AlternationCount$
 2��6�      AreRowDetailsFrozen . $��	10,10,0,0q�6�   ��6�   �� ��6�   Z� ��6  Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6&    �� Opacity$	 0.3Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . -   5        cTZ��   Header$ Teudat Zehute (userName)��5    e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
UserName+6e      RowDetailsTemplate 5"      �� 5#      .R�5$      �� ._�5%      �� .+�5&   "   �� $��delete2��6)   -   5        $��Delete��5&   8   $
��Left=�6I   $��370,-25,0,0q�6d   $	��Top=�6y   $��75��6�   6�   5'      5(      5)      5+      5,      5-      5.      