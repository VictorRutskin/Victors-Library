   M S B A M L   `   `   `  ���� J  FVictors Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Victors_LibraryVictors_Library  #    Victors_Library.AddBookWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:Victors_Library     $	��720��$
��1280��  � Title$#  Victor's Library - Add A Book��.��� ����  �� ImageSource$ /Entrance.png��.+�� $��50,0,0,0q�$
��Left=�$��Center=�$	��241��$	��658�� � ColumnDefinitions �� $
��628* ��� .+��� -    ��Name$ Genre_ComboBox��$��Center=�$	��Top=�$	��180�� �� Text$ 
Main Genre�� �� 
IsEditable . $��30(�$��50��$��0,41,0,0q� �� 
IsReadOnly .  � 	Resources  �� 
TargetType	 �� Property
 �� Value��%/   '��       �� " ��.��� 	 � ��

 �\\��.@��� $��Manga���� $��Comic���� $��Journal���� $��Fantasy���� $��	Adventure���� $��Romance���� $��Horror���� $��Thriller���� $��Children���� $��Cooking���� $��Crime���� $��	Education���� $��Comedy���� $��History���� $��	Biography���� $��Science���� $��Religion���� -    ��Name$ Name_TextBox��$��Center=�$��	0,279,0,0q� �� TextWrapping$
 Wrap=�$
��Name��$	��Top=�$	��180��$��30(�$��50���� -   $ Author_TextBox��$��Center=�$��	0,355,0,0q�$
 Wrap=�$��Author��$	��Top=�$	��180��$��30(�$��50���� -   $ Price_TextBox��$��Center=�$��	0,437,0,0q�$
 Wrap=�$��Price��$	��Top=�$	��180��$��30(�$��50���� -   $ Pages_TextBox��$��Center=�$��	0,519,0,0q�$
 Wrap=�$��Pages��$	��Top=�$	��180��$��30(�$��50��!   Victors_Library.Colorpicker  -     Name$ 
superCombo��$	��180��$��50��$��	0,598,0,0q�$��Center=�$	��Top=�$��30(��� -   $ Genre_ComboBox_Second��$��Center=�$	��Top=�$	��180��$ Genre 2�� . $��30(�$��50��$��	0,121,0,0q� .  ��%/   '��       �� " ��.��� 	 � ��

 �\\��.@��� $��Fantasy���� $��	Adventure���� $��Romance���� $��Horror���� $��Thriller���� $��Children���� $��Cooking���� $��Crime���� $��	Education���� $��Comedy���� $��History���� $��	Biography���� $��Science���� $��Religion���� -   $ Genre_ComboBox_Third��$��Center=�$	��Top=�$	��180��$ Genre 3�� . $��30(�$��50��$��	0,201,0,0q� .  ��%/   '��       �� " ��.��� 	 � ��

 �\\��.@��� $��Fantasy���� $��	Adventure���� $��Romance���� $��Horror���� $��Thriller���� $��Children���� $��Cooking���� $��Crime���� $��	Education���� $��Comedy���� $��History���� $��	Biography���� $��Science���� $��Religion��� -	    �Name$ BookGrid��$	��300��$	��420��$��490,92,490,192q�.+��� -
    ��Name$ 	BookColor��
���   �$��0,1,0,-1q�$	��300��$	��420��$��5������ *SelectedColor+ �� ElementName$ 
superCombo���� -    ��Name$ 	NameBlock��$
��Wrap=�$	��280��$��51��$��Center=�$	��Top=�$��0,37,0,0q�$��20(� �� TextAlignment$ Center=�$
��Bold"�$��	Underline{����� *Text+$ Name_TextBox���� -   $ AuthorBlock��$
��Wrap=�$	��280��$��50��$��Center=�$	��Top=�$��0,93,0,0q�$��20(�$ Center=����� *Text+$ Author_TextBox��F� :�����ހ�1 ���QUU�?`�j���QUU�?7�zQ�>���C���?	���	#FFD61D1D$
��Left=�$��92��$��0,1,0,0q�
���   � �� Stretch$
 Fill=�$	��Top=�$��95���� -   $ PriceTextBlock��$
��Wrap=�$��Price$��$	��107��$��39��$
��Left=�$	��Top=�$��
-16,19,0,0q�$��20(�$ Center=� J� RenderTransformOrigin$ 0.5,0.5&�$
��Bold"�z�V� .~��� �� ��  �� Angle$ -43.923Q�T� �� -   $ 
PagesBlock��$
��Wrap=�$��Pages:��$	��140��$��39��$
��Left=�$	��Top=�$��160,381,0,0q�$��15(�$ Center=��� -    ��Name$ 
Add_Button��$��10q�$��Add Book To Library��$��Right=�$��Center=�$��30(�$	��185��$	��305��$��	0,0,200,0q����	#FF31646D���	#FFFBDB7A����  �� Color$ 	#FF8E1242�� �� Opacity$	 0.9Q��� -    ��Name$ Librarian_Image��$
��None=�$	��500�� �� Left$ 0��
 �� Top$ 0��$	��500��$��Right=�$��Bottom=��� -   $ MainTextBlock��$
��Wrap=�$��	TextBlock��$��60��$ 0.501,0.589&�$��50(�$��Center=�$��Bottom=�$��0,0,0,10q����	#FF2E7A8E�� -   $ Button_Menu��$��10q�$��Back To Library��$	��100��$	��200�����	#FF31646D���	#FFFDE975$��25(�$��Right=�$	��Top=�$��0,5,10,0q����� $ 	#FF9A134E��$
 0.85Q�