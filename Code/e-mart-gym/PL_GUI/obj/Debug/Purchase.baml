   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.Purchase   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �   � RowDefinitions  5	   
   �� 5
      $
��303* �6   �� 5      $
��117* �6   �� 5      $	��80* �6   .+�5   
   	� -   5        $
��cash��5      $
��Cash��6"   $
��Left=�61   $��
429,0,0,54q�6L   $��1��6`   $��18(�6m   $��Bottom=�6{   $��25��6�   $	��110��6�    	� 	GroupName$ PayMaent��6�   6�   	� 5   
   -   5        $��check��5      $��Check��6#   $
��Left=�63   $��
429,45,0,0q�6N   $��1��6b   $��18(�6o   $	��Top=�6}   $��46��6�   $	��124��6�   $ PayMaent��6�   6�   	� 5   
   -   5        $��credit��5      $��Credit��6%   $
��Left=�66   $��
429,70,0,0q�6Q   $��1��6e   $��95��6r   $��18(�6}   $ PayMaent��6�   $��37��6�   $	��Top=�6�   �� 5   
   -   5        $��isMemberWithCRC��5      $y�	Collapsed=�6(   $#��Pay With exsicting CreditCard��6?   $
��Left=�6�   $��	10,72,0,0q�6�   $��1��6�   $	��Top=�6�   $	��188��6�   $��28��6�   �� 5   
   -   5        $��oneTimeShop��5      $y�	Collapsed=�6$   $��One Time Shop��6<   $
��Left=�6T   $��
253,68,0,0q�6o   $��1��6�   $	��Top=�6�   $	��125��6�   $��30��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��recieptGrid��5         
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 68      AutoGenerateColumns .  $
��Left=�6|   $��	10,10,0,0q�6�   $	��Top=�6�   $	��219��6�   $	��568��6�   ��6H   �� ��6�   Z� ��6�   Z�    AlternatingRowBackground 5      �� 5       �� Color$ 	#FFB8D9EE��6"    �� Opacity$	 0.3Q�64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	cName��,  &System.Windows.Controls.DataGridColumn	   Header$	 
Product ID��5   S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *	ProductID+6S     5      -	   5        	cType��$
	 Name��5   M   
 64   �� *Name+6M     5      -
   5        
cPrice��$	 Price��5   O   
 65   �� *Price+6O     5      -   5        
cCount��$	 Amount��5   P   
 65   �� *Amount+6P   5      �� 5   
   -   5        $��onTimeCredit��5      $y�	Collapsed=�6&    �� 	MaxLength$ 16��6>   $
��Left=�6M   $��23��6h   $��
258,19,0,0q�6t   $��1��6�    �� TextWrapping$
 Wrap=�6�   $��Enter your crdit card��6�   $	��Top=�6�   $	��148��6�   6�   �� 5    
   -   5        $	��sum��5       $��19(�6   $�� ��6)   $
��Left=�64   $��	27,15,0,0q�6O   $��1��6b   $	��Top=�6o   $	��400��6�   $��48��6�   �� 5!   
   -   5        $	��buy��5!      $	��Buy��6   $��2��6+   $��Center=�68   $��253,0,265,35q�6U   $��Bottom=�6l   $��82��6�   $��30��6�   $��Comic Sans MS)�6�   $��16(�6�   ��5"      �� 5#       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5$      �  � Color$ 	#FFEEEEEE��6#    � Offset$ 0Q�65   � 5%      $ White��6#   $ 0.744Q�61   5&      5(      5)      5*      