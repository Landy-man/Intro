   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.DepartmentT   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��5 �6   �� 5      $	��330 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��670 �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��save��5      $��2��6   $��3��6-   $
��save��6:   $��5q�6\   $��Comic Sans MS)�6g   $��16(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 0.744Q�61   5      5      �� 5   
   -   5        $��
tablePanel��5   &   $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gridDepartment��5   4   $��1��6   $��0��6$      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6x   	   SelectionMode$	 Extended=�6�   
 �� AlternationCount$
 2��6�      AreRowDetailsFrozen . $��
10,10,0,10q�6�   ��6�   �� ��6�   Z� ��6  Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6&    �� Opacity$	 0.3Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . -   5        
cDepID��   Header$ Department ID��5    l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *DepartmentID+6l     5!      -   5        	cName��$
 Name��5!   Q    68   �� *Name+6Q      RowDetailsTemplate 5#      �� 5$      .R�5%      �� ._�5&      �� .+�5'   "   �� $��headLine��6(   $*��$You can change the following fields:��68   $
��Left=�6g   $��40��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��170��6�   �� 5(   "   $��editName��6*   $
��Left=�6:   $��30��6k   $��200,-35,0,0q�6w    �� TextWrapping$
 Wrap=�6�    �� 
IsReadOnly .  $	��Top=�6�   $	��130��6�   ��6U   �� *Name+6�   �� 5)   "   $
��edit��6)   -   5        $��Save Changes��5)   5   $
��Left=�6L   $��340,-25,0,0q�6g   $	��Top=�6|   $��75��6�   6�   �� 5*   "   $��delete2��6)   -   5        $��Delete��5*   8   $
��Left=�6I   $��440,-25,0,0q�6d   $	��Top=�6y   $��75��6�   6�   5+      5,      5-      5/      50      51      52      