   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.TransectionT   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��5 �6   �� 5      $	��330 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��670 �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��save��5      $��2��6   $��3��6-   $
��save��6:   $��5q�6\   $��Comic Sans MS)�6g   $��16(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 0.744Q�61   5      5      �� 5   
   -   5        $��
tablePanel��5   &   $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gridTransection��5   4   $��1��6   $��0��6$      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6z   	   SelectionMode$	 Extended=�6�   
 �� AlternationCount$
 2��6�      AreRowDetailsFrozen . $��	10,10,0,0q�6�   ��6�   �� ��6�   Z� ��6  Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6&    �� Opacity$	 0.3Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . -   5        cTid��   Header$ Transection ID��5    k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *TransactionID+6k     5!       . -   5        	cDate��$
 Date��5!   g    6J   �� *
DateTime+6g      RowDetailsTemplate 5#      �� 5$      .R�5%      �� ._�5&      �� .+�5'   "   �  5(   &   �� 5)   *   $	��100 �6;   �� 5*   *   $��* �6;   .+�5,   &   �� $��reciept��6.   $��1��6=   $
��Left=�6M    �� 
IsReadOnly .  $	��100��6�   $��10q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��390��6�   ��6{   �� *	Reciept+6�   �� 5-   &   $��openReceipt��6-   -   5        $��0��5-   @   $��Open Receipt��6P   $
��Left=�6g   $��5,5,5,5q�6�   $	��Top=�6�   $��75��6�   6�   �� 5.   &   $��delete2��6-   -   5        $��0��5.   <   $��Delete��6L   $
��Left=�6]   $��5,30,5,5q�6x   $��Bottom=�6�   $��75��6�   6�   5/   #   50      51      52      54      55      56      57      