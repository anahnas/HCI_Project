   M S B A M L   `   `   `  ����H  DHCIProject1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HCIProject1._2HCIProject1._2  5   	   (    "HCIProject1._2.WindowResursPregled   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HCIProject1._2     5   	     � Title$  Pregled resursa��5   	   $	��450��6!   $	��800��6.    � Icon$ Images/resources.png��6:    � WindowStartupLocation$ CenterScreen=�6V    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Help��5
      6<   .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMain��5   �    � ToolTip$� �Ovde su prikazeni postojeći tipovi. Ukoliko želite da izmijenite ili obrišete neki potrebno je da ga prvo označite, pa zatim izaberete jednu od dole ponuđenih akcija.��6   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     SelectionMode$ Single=�6U  ��6�   ��  �� Path$ Resursi�   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Slika��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 69      
IsReadOnly .    CellTemplate 5      �� 5      .R�5      �� $��32��6%   $��32��60   ��6<   �� *	imagePath+5      5        5      $	 Ime��6)   $ 45 66    .  5       �� 5!      .R�5"      �� $
��Wrap=�6(   ��6<   �� *Ime+6S   5#      5'      0  *System.Windows.Controls.DataGridTextColumn  5(      $ 50 6%   $ Oznaka��60    . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *Oznaka+6p     5)      $ * 6%   $
 Opis��6/    .  6P   �� *Opis+6k   5+      �� 5,   
   $��1��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5-      �� $��15��6   6%   �� 5/      -   5        $
��15px(�5/   )   $K EPritiskom na dugme otvoriće se novi prozor za dodavanje tiparesursa.��69   $��5 5 10 5q�6�   $��99��6�   .��50      �� $ 
Horizontal=�6   .+�51      �� $��20��6   $��/Images/add.png��6(   �� 52      $��5 0 0 0q�6    Dodaj68   53      54      �� 56      -   5         ��Name$ Izmeni��56   �   $U OPritiskom na dugme otvoriće se novi prozor za izmjenu označenog tipa resursa.��6   $��	10 5 10 5q�6�   $	��107��6�   .��57      �� $ 
Horizontal=�6   .+�58      �� $��20��6   $��images/edit.png��6(   �� 59      $
��15px(�6    $��5 0 0 0q�61   
Izmijeni6M   5:      5;      �� 5<      -   5         ^� ShowDuration$ 20000��5<   +   $@ :Pritiskom na dugme označeni tip resursa će biti obrisan.��6P   $��	10 5 10 5q�6�   $	��113��6�   .��5=      �� $ 
Horizontal=�6   .+�5>      �� $��20��6   $��/Images/delete.png��6(   �� 5?      $
��15px(�6    $��5 0 0 0q�60   	Obriši6I   5@      5A      5D      �� 5F   
   $��1��6   .+�5G      �� $
��15px(�6   $� �Ukoliko želite da pronađete određene resurse možete to uraditi popunjavajući polje ili polja po kojim želite da vršite pretragu.��6)   $��Center=�6�    �� Padding$ 
10 10 10 0q�6�   Pronađite resurs6�   �� 5I      $
��15px(�6   $ 10 0 0 0q�6(   $��40��6;   Ime6L   �� 5J      -   5        $
��xIme��5J   ^   $D >Ovde unesite ime resursa po kojem želite da vršite pretragu.��6   $��	10 0 10 0q�6j   $��38��6}   6�   �� 5L      $
��15px(�6   $ 	10 10 0 0q�6(   $��46��6<   Oznaka6P   �� 5M      -   5        $��xOznaka��5M   a   $G AOvde unesite oznaku resursa po kojem želite da vršite pretragu.��6   $��	10 0 10 0q�6p   $��41��6�   6�   �� 5O      $
��15px(�6   $ 10 0 0 0q�6(   $��28��6;   Opis6M   �� 5P      -   5        $��xOpis��5P   r   $X ROvde unesite opis ili dio opisa tipa resursa po kojem želite da vršite pretragu.��6   $��	10 0 10 0q�6   $��38��6�   6�   �� 5Q      $��7 7 7 0q�6   $��0q�6&   �� 5S      -	   5        $ Pretrazi��5S   �   $
��15px(�6   $� �Potrebno je da kliknete ovo dugme kako bi se pretraga izvršila. Nakon što kliknete u tabeli će se pojaviti samo oni resursi koji zadovoljavaju unete vrednosti.��6>   $��	10 5 10 5q�6�   $��36��6  .��5T      �� $ 
Horizontal=�6   .+�5U      �� $��20��6   $��/Images/search.png��6'   �� 5V      $��3 0 0 0q�6    	Pretraži6;   5W      5X      �� 5Y      -
   5        $ Ponisti��5Y   ,   $��	10 5 10 5q�6=   $��46��6Q   .��5Z      �� $ 
Horizontal=�6   .+�5[      �� $��20��6   $��/Images/cancel.png��6'   �� 5\      $
��15px(�6    $^ XKlikom na ovo dugme se pretraga poništava, u tabeli se prikazuju svi postojeći tipovi.��60   $��Poništi pretragu��6�   5]      5^      5_      5a      5b      