   M S B A M L   `   `   `  ����H  DHCIProject1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HCIProject1._2HCIProject1._2  5   	       HCIProject1._2.WindowTip   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HCIProject1._2     5   	     � Title$  Dodavanje tipa resursa��5   	   $	��450��6(   $	��800��65    � Icon$ /Images/type.png��6A    � WindowStartupLocation$ CenterScreen=�5	   	    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$! local:DemoCommands.ExitDemo��5      6     5   
   -   5        $ ApplicationCommands.Help��5      6<   .��5      ��  �� Padding$ 10q�6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#    � RowDefinitions 5      �� 5      $��10 �6    �� 5      $
��0.2* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��2* �6    �� 5       $
��1.5* �6    �� 5!      $��1* �6    .+�5#      ��  � ToolTip$< 6Zvjezdica (*) označava da je obavezno popuniti polje.��6   $��10 0 0 0q�6X   $��1��6k   $��2��6{   $
��Left=�6�   $
��14px(�6�   
Oznaka*:6�   �� 5$      $< 6Zvjezdica (*) označava da je obavezno popuniti polje.��6   $��10 0 0 0q�6X   $��1��6k   $��3��6{   $
��Left=�6�   $
��14px(�6�   Ime*:6�   �� 5%      $��10 0 0 0q�6   $��1��6+   $��4��6;   $
��Left=�6H   $
��14px(�6c   
Ikonica:6}   �� 5&      $��10 0 0 0q�6   $��1��6+   $��5��6;   $
��Left=�6H   $
��14px(�6c   Opis:6z   �� 5)      -   5        $��xOznaka��5)   �   	 ^� ShowDuration$	 20000��6   $i cOvde unesite jedinstvenu oznaku resursa.Neophodno je da se oznaka sastoji od najmanje 3 karaktera.��6:   $��0 0 0 13q�6�   $��3��6�   $��2��6�   $��Stretch=�6�   .��6+  ��5*      �� 5+      
 �� Path$
 Oznaka�6    �� UpdateSourceTrigger$ 	LostFocus=�6,    �� ValidationRules 5,      ,   &HCIProject1._2.ValidacijaOznakeResursa  5-      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6<   50      .��52        =� ErrorTemplate 53      �� 54      .R�55      �� .+�56      ��  �� Orientation$ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�57   "   �� 
���  ��$��20��6:   $��20��6E    �� CornerRadius$ 10��6Q    6c   �� $
 /ErrorContent�._�58   &   �� $��!��60   $��Center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   59   #   �� 5:   "   $��5 0 0 0q�6,   
���  ����6N   �� *[0].ErrorContent+5;      �� 5<      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X    6d   �� $
 /ErrorContent�._�5=   "   �� $��textBox��6<   5>      5?      5@      .��5A   ,   5B      �� 5E      -   5        $
��xIme��5E   �   $	 20000��6   $\ VOvde unesite ime tipa resursa.Neophodno je da se ime sastoji od najmanje 3 karaktera.��6:   $��0 3 0 10q�6�   $��3��6�   $��3��6�   $��Stretch=�6�   .��6  ��5G      �� 5H      $	
 Ime�6   $ 	LostFocus=�6)    5I      &    HCIProject1._2.ValidacijaResursa  5J      $ RawProposedValue=�66   5L      .��5M        5N      �� 5O      .R�5P      �� .+�5Q      �� $ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�5R   "   �� 
���  ��$��20��6:   $��20��6E   $ 10��6Q    5S   )   ��  �� ElementName$	 Ime��$-
 'Ime.(Validation.Errors)[0].ErrorContent�._�5T   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   5U   #   �� 5V   "   $��5,5,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+5W      �� 5X      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X   ._�5Y   "   �� $��textBox��6<   5Z      5[      5\      .��5]   ,   5`      � 5d      $��0 0 0 3q�6   $��3��6$   $��4��64   $��Stretch=�6A    5e      �� 5f      $��* �6'   �� 5g      $��* �6'   .+�5j      �� -   5        $��imgPhoto��5j   �   $	 20000��6   $u oOvo predstavlja podrazumijevanu ikonicu tipa resursa.Ukoliko želite da je promijenite idite na dugme Odaberi.��6<   $��5q�6�   $
��Fill=�6�   $��0��6�   �� 5k      $��1��6   $
��Left=�6.   $��	10 0 0 20q�6I   $��Bottom=�6\   .+�5l      �� -   5        $��
btnOdaberi��5l   �   $	 20000��6   $} wPritiskom na ovo dugme otvoriće se dijalog gde je potrebnoda izaberete ikonicu koju želite da dodelite tipu resursa.��6Z   $��0 0 0 5q�6�   $��75��6  .��6  
_Odaberi6  �� 5m      -   5        $��	btnOdbaci��5m   �   $	 20000��6   $P JPritiskom na ovo dugme postaviće sepodrazumijevana ikonica tipa resursa.��6[   $��75��6�   .��6�   	_Odbaci6�   5n      5o      �� 5p      -   5        $��xOpisScroll��5p   g   $��0 0 0 3q�6   $��3��6,   $��5��6<   $��Stretch=�6I   .��5q      �� -	   5        $��xOpis��5q   h   $	 20000��6   $% Ovde unesite opis tipa resursa.��6>    �� AcceptsReturn . 6�   5r      �� 5s      -
   5         ��Name$ PotvrdiDugme��5s   �    ^� ShowOnDisabled . $� �Kako bi dodavanje tipa resursa bilo moguće neophodno je da popunitesva polja sa zvjezdicom (*). Pritiskom na dugme tip resursa će biti dodat.��6P   $��1��6  $��6��6  $��80��6!  $��30��6,  $��Right=�68  .��6T  	Potvrdi6]  �� 5t      -   5        $ 	xOdustani��5t   P   $	 20000��6   $6 0Pritiskom na dugme tip resursa neće biti dodat.��6c   $��3��6�   $��6��6�   $��80��6�   $��30��6�   $
��Left=�6�   .��6�   
Odustani6�   5x      5y      5z      