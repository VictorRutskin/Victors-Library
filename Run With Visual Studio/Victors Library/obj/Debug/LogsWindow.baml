   M S B A M L   `   `   `  ����J  FVictors Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Victors_LibraryVictors_Library  5   	        Victors_Library.LogsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Victors_Library     5   	     � Title$   Victor's Library - Reports��5   	   $	��720��6,   $
��1280��69   .��5	      �� -   5        $��CANVAS��5	      |�. ���	#FFCC1752.+�5   
   �� -   5         ��Name$ Librarian_Image��5      $
��None=�6)   $	��500��68    �� Left$ 0��6E   
 �� Top$ 0��6U   $	��500��6d   $��Center=�6p   $��Bottom=�6�   � 5   
   #��Z��6   $
��1076��5      $	��Top=�6   $��Center=�64   $ 62��6Q    � ColumnDefinitions 5      �� 5      $
��239* �6#   �� 5      $
��106* �6#   �� 5      $
��615* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ BookDataGrid��5   {   #��Z��5   L   $	��600��5         
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�6-   $   HorizontalScrollBarVisibility$ Visible=�6S   ���	#FFCC1752���	#FF9C164D���	#FF31646D$��30(�6�   $
��Left=�6�   $	��Top=�6  $��	0,228,0,0q�6  $��3��6,  	 �� SelectedItem	 5      �� *SelectedBook+
 �� Mode$
 TwoWay=�5      �� 5      -   5         ��Name$ BookSearch_Button��5      $��10q�60   $��Back To Library��6F   $	��200��6`   $	��400��6m   ���	#FF31646D���	#FFFDE975$��50(�6�   $��Right=�6�   $	��Top=�6�   $��2��6
  ��5      �� 5       �� Color$ 	#FF9A134E��6&    �� Opacity$
 0.85Q�68   5      �� 5      -   5        $ BoughtBooks_Button��5      $��10q�61   $��Bought Books��6G   $	��150��6^   $	��300��6k   ���	#FF31646D���	#FFFDE975$��40(�6�   $
��Left=�6�   $	��Top=�6�   $��20,0,0,0q�6  ��5      �� 5      $ 	#FFD5B14C��6&   $
 0.85Q�68   5!      �� 5"      -   5        $ RemovedtBooks_Button��5"      $��10q�63   $��Removed Books��6I   $	��150��6a   $	��300��6n   ���	#FF31646D���	#FFFDE975$��40(�6�   $
��Left=�6�   $	��Top=�6�   $��86,0,0,0q�6  $��2��6  ��5#      �� 5$      $ 	#FFD5B14C��6&   $
 0.85Q�68   5&      �� 5'      -   5        $ AddedBooks_Button��5'      $��10q�60   $��Added Books��6F   $	��150��6\   $	��300��6i   ���	#FF31646D���	#FFFDE975$��40(�6�   $
��Left=�6�   $	��Top=�6�   $��3��6   $��	394,0,0,0q�6  ��5(      �� 5)      $ 	#FFD5B14C��6&   $
 0.85Q�68   5+      �� 5,      -   5        $ Exceptions_Button��5,      $��10q�60   $��
Exceptions��6F   $	��150��6[   $	��300��6h   ���	#FF31646D���	#FFFDE975$��40(�6�   $��Center=�6�   $	��Top=�6�   $��2��6  ��5-      �� 5.      $ 	#FFD5B14C��6&   $
 0.85Q�68   50      52      56      57      