   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.EmployeeT   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��5 �6   �� 5      $	��330 �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��670 �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��save��5      $��2��6   $��3��6-   $
��save��6:   $��5q�6\   $��Comic Sans MS)�6g   $��16(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 0.744Q�61   5      5      �� 5   
   -   5        $��
tablePanel��5   &   $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gridEmployee��5   4   $��1��6   $��0��6$      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6w   	   SelectionMode$	 Extended=�6�   
 �� AlternationCount$
 2��6�      AreRowDetailsFrozen . $��	10,10,0,0q�6�   ��6�   �� ��6�   Z� ��6  Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6&    �� Opacity$	 0.3Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . -   5        cTZ��   Header$ Teudat Zehute��5    i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *TeudatZehute+6i     5!      -   5        cFirstN��$ 
First Name��5!   X    6:   �� *	FirstName+6X     5"      -   5        
cLastN��$ 	Last Name��5"   V    69   �� *
LastName+6V     5#      -   5        
cDepID��$ Department ID��5#   Z    69   �� *DepartmentID+6Z     5$      -   5        cSalary��$ Salary��5$   U    6:   �� *Salary+6U     5%       . -	   5        cGender��$ Gender��5%   h    6M   �� *Gender+6h     5&      -
   5        cSuperID��$ His Supervisor ID��5&   \    6;   �� *SupervisorID+6\      RowDetailsTemplate 5(      �� 5)      .R�5*      �� ._�5+      �� .+�5,   "   �� $��headLine��6(   $*��$You can change the following fields:��68   $
��Left=�6g   $��40��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��170��6�   �� 5-   "   $��	firstName��6(   $��First Name :��69   $
��Left=�6P   $��30��6k   $��20,0,0,0q�6w   $	��Top=�6�   $	��170��6�   �� 5.   "   $��editFirstName��6*   $
��Left=�6?    �� 
IsReadOnly .  $��30��6�   $��180,-25,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6m   �� *	FirstName+6�   �� 5/   "   $��lastName��6(   $��Last Name :��68   $
��Left=�6N   $��30��6i   $��20,0,0,0q�6u   $	��Top=�6�   $	��170��6�   �� 50   "   $��editLastName��6*   $
��Left=�6>    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6l   �� *
LastName+6�   �� 51   "   $��depID��6(   $ ��Location (department ID) :��65   $
��Left=�6Z   $��30��6u   $��20,0,0,0q�6�   $	��Top=�6�   $	��170��6�   �� 52   "   $��	editDepID��6*   $
��Left=�6;    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6i   �� *DepartmentID+6�   �� 53   "   $��salary��6(   $��Salary :��66   $
��Left=�6I   $��30��6d   $��20,0,0,0q�6p   $	��Top=�6�   $	��170��6�   �� 54   "   $��
editSalary��6*   $
��Left=�6<    .  $��30��6�   $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6W   �� *Salary+6�   �� 55   "   $��superID��6(   $��Supervisor ID :��67   $
��Left=�6Q   $��30��6l   $��20,0,0,0q�6x   $	��Top=�6�   $	��170��6�   �� 56   "   $��	editSuper��6*   $
��Left=�6;   $��30��6t    .  $��180,-25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   ��6V   �� *SupervisorID+6�   �� 57   "   $
��edit��6)   -   5        $��Save Changes��57   5   $
��Left=�6L   $��340,-25,0,0q�6g   $	��Top=�6|   $��75��6�   6�   �� 58   "   $��delete2��6)   -   5        $��Delete��58   8   $
��Left=�6I   $��440,-25,0,0q�6d   $	��Top=�6y   $��75��6�   6�   59      5:      5;      5=      5>      5?      5@      