   M S B A M L   `   `   `  ����H  DHCIProject1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HCIProject1._2HCIProject1._2  5   	   )    #HCIProject1._2.WindowEtiketaPregled   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HCIProject1._2     5   	     � Title$  Pregled Etiketa��5   	   $	��450��6!   $	��800��6.    � Icon$ /Images/label1.png��6:    � WindowStartupLocation$ CenterScreen=�6T    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Help��5
      6<   .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMainEtiketa��5   �    � ToolTip$� �Ovde su prikazane postojeće etikete. Ukoliko želite da izmijenite ili obrišete neku potrebno je da je prvo označite, pa zatim izaberete jednu od dole ponuđenih akcija.��6   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  ��6  ��  �� Path$ Etikete�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Oznaka��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Oznaka+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       � ��$	 120��6C   �� 5       � ��$	 120��6@   �� 5        �@��TextAlignment$
 Left=�6H   5!      5#        5%      $ * 6%   $
 Opis��6/    6=   �� *Opis+ 5&      �� 5'      .�5(      ��  � ��$
 Wrap=�6G   �� 5)       � ��$	 120��6C   �� 5*       � ��$	 120��6@   �� 5+       �@��TextAlignment$
 Left=�6H   5,      5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      $
 Boja��6)   $ 4* 67      CellTemplate 50      �� 51      .R�52      �  53   "   �� 54   &   $��4* �67   �� 55   &   $
��Auto �67   .+�57   "   �� $��0��6,   ��58   &   �� 59   *    �� Color 6:   �� *Boja2+5;   #   5<      5=      5?      5C      �� 5D   
   $��1��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5G      �� -   5        $G APritiskom na dugme otvoriće se novi prozor za dodavanje etikete.��5G      $��5 5 10 5q�6`   $��91��6r   .��5H      �� $ 
Horizontal=�6   .+�5I      �� $��20��6   $��/Images/add.png��6(   �� 5J      $
��16px(�6    $��5 0 0 0q�60   Dodaj6H   5K      5L      �� 5N      -   5         ��Name$ Izmeni��5N   ~   $O IPritiskom na dugme otvoriće se novi prozor za izmjenu označene etikete.��6,   $��	10 5 10 5q�6�   $	��114��6�   .��5O      �� $ 
Horizontal=�6   .+�5P      �� $��20��6   $��images/edit.png��6(   �� 5Q      $
��16px(�6    $��5 0 0 0q�60   $��59��6A   
Izmijeni6W   5R      5S      �� 5T      -   5        $= 7Pritiskom na dugme označena etiketa će biti obrisana.��5T   *   $��	10 5 10 5q�6j   $��93��6}   .��5U      �� $ 
Horizontal=�6   .+�5V      �� $��20��6   $��/Images/delete.png��6(   �� 5W      $
��16px(�6    $��5 0 0 0q�60   $��23��6A   $��51��6M    J� RenderTransformOrigin$ 0.735,0.526&�6X   	Obriši6�   5X      5Y      5\      �� 5^   
   $��1��6   .+�5_      �� $
��15px(�6   $� �Ukoliko želite da pronađete određene etikete resursa možete to uraditi popunjavajući polje ili polja po kojim želite da vršite pretragu.��6)   $��Center=�6�    �� Padding$ 
10 10 10 0q�6�   Pronađite etikete6  �� 5a      $
��15px(�6   $ 10 0 0 0q�6(   $��38��6;   Opis6M   �� 5b      -   5        $
��xIme��5b   ]   $D >Ovde unesite ime etikete po kojem želite da vršite pretragu.��6   $��	10 0 10 0q�6i   $��40��6|   6�   �� 5d      $
��15px(�6   $ 	10 10 0 0q�6(   $��46��6<   Oznaka6P   �� 5e      -   5        $��xOznaka��5e   �    ^� ShowDuration$ 20000��6   $L FOvde unesite oznaku tipa resursa po kojem želite da vršite pretragu.��6<   $��	10 0 10 0q�6�   $��41��6�   6�   �� 5h      $��7 7 7 0q�6   $��0q�6&   �� 5j      -   5        $ Pretrazi��5j   �   $� �Potrebno je da kliknete ovo dugme kako bi se pretraga izvršila. Nakon što kliknete u tabeli će se pojaviti samo one etikete koje zadovoljavaju unijete vrijednosti.��6.   $��	10 5 10 5q�6�   $��53��6  .��5k      �� $ 
Horizontal=�6   .+�5l      �� $��20��6   $��/Images/search.png��6'   �� 5m      $
��18px(�6    $��3 0 0 0q�60   	Pretraži6K   5n      5o      �� 5p      -	   5        $ Ponisti��5p   Q   $ 20000��6,   $��	10 5 10 5q�6b   $��53��6v   .��5q      �� $ 
Horizontal=�6   .+�5r      �� $��20��6   $��/Images/cancel.png��6'   �� 5s      $
��18px(�6    $_ YKlikom na ovo dugme se pretraga poništava, u tabeli se prikazuju sve postojeće etikete.��60   $��Poništi pretragu��6�   6�   5t      5u      5v      5x      5y      