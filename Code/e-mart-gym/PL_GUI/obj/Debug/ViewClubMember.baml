   M S B A M L   `   `   `  ����
  PL_GUI    PL_GUI.ViewClubMember   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
leftSplite��5      $��0��6'   $��1��67   .+�5      �   5      �� 5      $	��150 �6$   �� 5      $	��220 �6$   .+�5      �� -   5        $��allClubMember��5      $��View All Club Members��6.   $��Center=�6N   $��
10,20,10,0q�6k   $��0��6   $	��Top=�6�   $	��150��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ 	#FFEEEEEE��6+    � Offset$ 0Q�6=   � 5      $ White��6+   $ 0.744Q�69   5      5      �� 5      -   5        $	��add��5      $��Add Club Member��6$   $��Center=�6>   $��
10,60,10,0q�6[   $��0��6o   $	��Top=�6|   $	��150��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5       �� 5!      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5"      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5#      $ White��6+   $ 0.744Q�69   5$      5&      �� 5'      -   5        $��searchBy��5'      $��	Search By��6)   $��Center=�6=   $��10,100,10,0q�6Z   $��0��6o   $	��Top=�6|   $	��150��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5(      �� 5)      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5*      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5+      $ White��6+   $ 0.744Q�69   5,      5.      �� 5/      -   5        $��stringPanel��5/      $��0��60   $��1��6@   $y�	Collapsed=�6M   .+�50      �� -   5        $��headLine��50      $��what do you want to find:��6,   $
��Left=�6P   $��40��6k   $��	10,50,0,0q�6w   $	��Top=�6�   $	��170��6�   �� 51      -   5        $��toSearch��51      $
��Left=�6.   $��23��6I   $��34,0,0,0q�6U    �� TextWrapping$
 Wrap=�6g   $	��Top=�6|   $	��130��6�   �� 52      -   5        $��stringSearch��52      $��Search��61   $
��Left=�6B   $��
105,50,0,0q�6]   $	��Top=�6q   $��75��6�   $��Comic Sans MS)�6�   $��13(�6�   ��53      �� 54      $ 0.5,1&�62   $ 0.5,0&�6C   .��55   "   � $ 	#FFEEEEEE��6/   $ 0Q�6A   � 56   "   $ White��6/   $ 0.744Q�6=   57      59      5:      �� 5;      -	   5        $��
rangePanel��5;      $��0��6/   $��1��6?   $y�	Collapsed=�6L   .+�5<      �� -
   5        $��	headLine1��5<      $��From:��6-   $
��Left=�6=   $��40��6X   $��	10,40,0,0q�6d   $	��Top=�6w   $��50��6�   �� 5=      -   5        $��fromSearchR��5=      $
��Left=�61   $��23��6L   $��
65,-35,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��110��6�   �� 5>      -   5        $��	headLine2��5>      $	��To:��6-   $
��Left=�6;   $��40��6V   $��	10,10,0,0q�6b   $	��Top=�6u   $��50��6�   �� 5?      -   5        $��	toSearchR��5?      $
��Left=�6/   $��23��6J   $��
65,-35,0,0q�6V   $
 Wrap=�6j   $	��Top=�6   $	��110��6�   �� 5@      -   5        $��RangeSearch��5@      $��Search��60   $
��Left=�6A   $��
105,40,0,0q�6\   $	��Top=�6p   $��75��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5A      �� 5B      $ 0.5,1&�62   $ 0.5,0&�6C   .��5C   "   � $ 	#FFEEEEEE��6/   $ 0Q�6A   � 5D   "   $ White��6/   $ 0.744Q�6=   5E      5G      5H      �� 5I      -   5        $��
DatePanel1��5I      $��0��6/   $��1��6?   $y�	Collapsed=�6L   .+�5J      �� -   5        $��	headLineD��5J      $%��pick the date you want to find:��6-   $
��Left=�6W   $��40��6r   $��	10,20,0,0q�6~   $	��Top=�6�   $	��170��6�   (  "System.Windows.Controls.DatePicker  5K      -   5        $��DtoFind��5K   !   $��40��61   $��10,0,0,0q�6=   $	��Top=�6O   $	��170��6h   �� 5L      -   5        $��
DateSearch��5L      $��Search��6/   $
��Left=�6@   $��
105,70,0,0q�6[   $	��Top=�6o   $��75��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5M      �� 5N      $ 0.5,1&�62   $ 0.5,0&�6C   .��5O   "   � $ 	#FFEEEEEE��6/   $ 0Q�6A   � 5P   "   $ White��6/   $ 0.744Q�6=   5Q      5S      5T      �� 5U      -   5        $��
DatePanel2��5U      $��0��6/   $��1��6?   $y�	Collapsed=�6L   .+�5V      �� -   5        $��
headLineD1��5V      $
��From��6.   $
��Left=�6=   $��40��6X   $��	10,20,0,0q�6d   $	��Top=�6w   $	��170��6�     5W      -   5        $��	DFromFind��5W   !   $��40��63   $��
10,-10,0,0q�6?   $	��Top=�6S   $	��170��6l   �� 5X      -   5        $��
headLineD2��5X      $��To��6.   $
��Left=�6;   $��40��6V   $��10,0,0,0q�6b   $	��Top=�6t   $	��170��6�     5Y      -   5        $��DToFind��5Y   !   $��40��61   $��
10,-10,0,0q�6=   $	��Top=�6Q   $	��170��6j   �� 5Z      -   5        $��DateSearch2��5Z      $��Search��60   $
��Left=�6A   $��
105,20,0,0q�6\   $	��Top=�6p   $��75��6�   $��Comic Sans MS)�6�   $��13(�6�   ��5[      �� 5\      $ 0.5,1&�62   $ 0.5,0&�6C   .��5]   "   � $ 	#FFEEEEEE��6/   $ 0Q�6A   � 5^   "   $ White��6/   $ 0.744Q�6=   5_      5a      5b      5c      5d      �� 5e   
   -   5        $��	tableShow��5e      $��1��6&   $��1��66   5f       � 	Resources 5g       
  search��%�
  &	        �� 5h   
   .@�5i      m� $	��sTZ��6   -   5        $��Teudat Zehute��5i   $   $��Comic Sans MS)�6M   ��5j      �� 5k      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5l      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5m      $ White��6'   $ 0.744Q�65   5n      5p      m� 5q      $	��sFN��6   -   5        $��
First Name��5q   #   $��Comic Sans MS)�6I   ��5r      �� 5s      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5t      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5u      $ White��6'   $ 0.744Q�65   5v      5x      m� 5y      $	��sLN��6   -   5        $��	Last Name��5y   #   $��Comic Sans MS)�6H   ��5z      �� 5{      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5|      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5}      $ White��6'   $ 0.744Q�65   5~      5�      m� 5�      $��sMembID��6   -   5        $��	Member ID��5�   (   $��Comic Sans MS)�6Q   ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5�      $ White��6'   $ 0.744Q�65   5�      5�      m� 5�      $��sDateOB��6   $��Date Of Birth��6'   $��Comic Sans MS)�6>   ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5�      $ White��6'   $ 0.744Q�65   5�      .@�5�      m� $��sDateOB1��6   -   5        $��Specific��5�   +   $��Comic Sans MS)�6T   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5�      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5�      $ White��6+   $ 0.744Q�69   5�      5�      m� 5�      $��sDateOB2��6   -   5        $��Range��5�   +   $��Comic Sans MS)�6Q   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5�      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5�      $ White��6+   $ 0.744Q�69   5�      5�      5�      m� 5�      $��sGender��6   $��Gender��6'   $��Comic Sans MS)�67   ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ 	#FFEEEEEE��6'   $ 0Q�69   � 5�      $ White��6'   $ 0.744Q�65   5�      .@�5�      m� $
��male��6   -    5        $
��Male��5�   '   $��Comic Sans MS)�6H   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5�      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5�      $ White��6+   $ 0.744Q�69   5�      5�      m� 5�      $��female��6   -!   5        $��Female��5�   )   $��Comic Sans MS)�6N   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5�      � $ 	#FFEEEEEE��6+   $ 0Q�6=   � 5�      $ White��6+   $ 0.744Q�69   5�      5�      5�      5�      5�      5�      