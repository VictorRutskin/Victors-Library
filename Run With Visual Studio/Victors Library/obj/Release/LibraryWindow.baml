   M S B A M L   `   `   `  ���� J  FVictors Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Victors_LibraryVictors_Library  #    Victors_Library.LibraryWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:Victors_Library     $	��720��$
��1280��  � Title$'  !Victor's Library - Search And Buy�����	#FFA8254B
���   �.���  � ColumnDefinitions �� .+�&   System.Windows.Controls.DataGrid  -     Name$ BookDataGrid��   
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=����	#FFCC1752���	#FF9C164D���	#FF31646D$��30(�$��	0,141,0,0q� �� SelectedItem ��  �� Path$ SelectedBook� �� Mode$ TwoWay=�   Columns �� $��Advanced search:��$
��Left=�$	��Top=�$��20(�$��	0,105,0,0q����	#FFFBE974���	#FF31646D� $��169,110,0,0q�$
��Left=�$	��Top=�$
��1111�� �� $��2* ��� $	��14* ��� $	��77* ��� $	��43* ��� $	��37* ��� $
��152* ��� $��6* ��� $
��778* ��� $��2* �.+��� -   	 ��Name$	 Genre_ComboBox��$
��Left=�$��Center=�$	��133��
 �� Text$
 Genre�� �� 
IsEditable . $��18(�$��26��$��4��$��8,0,0,0q� �� 
IsReadOnly . $��1�� � 	Resources  �� 
TargetType �� Property �� Value��%/   '��       �� " ��.���  � ��
 �\\��.@��� .��Any�� .��Manga�� .��Comic�� .��	Journal�� .��	Fantasy�� .��	Adventure�� .��	Romance�� .��Horror�� .��
Thriller�� .��
Children�� .��	Cooking�� .��Crime�� .��	Education�� .��Comedy�� .��	History�� .��	Biography�� .��	Science�� .��
Religion�� -    ��Name$ Name_TextBox��$
��Left=�$��32,0,0,0q� �� TextWrapping$
 Wrap=�$
��Name��$��Center=�$	��143��$��18(�$��4��$��26��$��2���� -   $ Author_TextBox��$
��Left=�$��1,0,0,0q�$
 Wrap=�$��Author��$��Center=�$	��143��$��18(�$��7��$��26���� -   $ 
ID_TextBox��$
��Left=�$��	162,0,0,0q�$
 Wrap=�$��ID��$��Center=�$	��143��$��18(�$��7��$��26���� -   $ Pages_TextBox��$
��Left=�$��	484,0,0,0q�$
 Wrap=�$��Pages Number��$��Center=�$	��143��$��18(�$��7��$��26���� -   $ Price_TextBox��$
��Left=�$��	324,0,0,0q�$
 Wrap=�$��Price��$��Center=�$	��143��$��18(�$��7��$��26���� -    ��Name$ Search_Button��$��7��$��Search��$
��Left=�$��	647,0,0,0q�$��Center=�$��26��$	��100��$��18(��� -	    ��Name$ Librarian_Image��$
��None=�$	��500��$	��500��$��Right=�$��Bottom=�$��	0,0,830,0q��� -
    ��Name$ MainTextBlock��$
��Wrap=�$��60�� J� RenderTransformOrigin$ 0.465,0.417&�$��50(�$
��Left=�$��Bottom=�$��
487,0,0,16q����	#FF2E7A8E�� -   $ Button_Remove��$��10q�$��Remove��$��Right=�$	��Top=�$��80��$	��160�����	#FF31646D���	#FFFDE974$��25(�$��	0,5,191,0q�����  �� Color$ 	#FFDA2C2C�� �� Opacity$
 0.85Q��� -   $ Button_Menu��$��10q�$��	Main Menu��$��80��$	��160�����	#FF31646D���	#FFFDE975$��25(�$��Right=�$	��Top=�$��0,5,10,0q����� $ 	#FF9A134E��$
 0.85Q��� -   $ 
Button_Buy��$��10q�$	��Buy��$��Right=�$	��Top=�$��80��$	��160�����	#FF31646D���	#FFFDE974$��25(�$��	0,5,373,0q����� $ 	#FF4BB236��$
 0.85Q��� -   $ Button_Edit��$��10q�$
��Edit��$��Right=�$	��Top=�$��80��$	��160�����	#FF31646D���	#FFFDE974$��25(�$��	0,6,560,0q����� $ 	#FF81987C��$
 0.85Q��� -   $ 
Button_Add��$��10q�$	��Add��$��80��$	��160�����	#FF31646D���	#FFFDE975$��25(�$��Right=�$	��Top=�$��	0,5,744,0q����� $ 	#FF42A1D2��$
 0.85Q��� -   $ Logs_Button��$��10q�$
��Logs��$��80��$	��160�����	#FF31646D���	#FFFDE975$��25(�$��Right=�$	��Top=�$��	0,5,929,0q����� $ 	#FFCEA32D��$
 0.85Q��� -   $ PrintReport_Button_Copy��$��10q�$��Print Search��$��80��$	��160�����	#FF31646D���	#FFFDE975$��25(�$��Right=�$	��Top=�$��
0,5,1115,0q����� $ 	#FF2D54CE��$
 0.85Q�