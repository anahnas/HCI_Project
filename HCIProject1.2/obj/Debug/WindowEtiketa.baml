   M S B A M L   `   `   `  ����H  DHCIProject1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HCIProject1._2HCIProject1._2  5   	   "    HCIProject1._2.WindowEtiketa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   (localclr-namespace:HCIProject1._2  5   	     � Title$  Etiketa��5
   	   $	��450��6   $	��800��6&    � Icon$ /Images/label1.png��62    � WindowStartupLocation$ CenterScreen=�6L    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      ��  �� Padding$ 30q�6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $
��2.5* �6    �� 5      $
��1.1* �6    .+�5      ��  � ToolTip$9 3Zvjezdica * oznacava da je polje obavezno popuniti.��6   $��	50,25,0,0q�6V   $��0��6i   $��0��6y   $
��Left=�6�   $
��18px(�6�   
Oznaka*:6�   �� 5       $��	50,25,0,0q�6   $��0��6+   $��1��6;   $
��18px(�6H   $
��Left=�6X   Boja:6z   �� 5!      $��	50,25,0,0q�6   $��0��6+   $��2��6;   $
��18px(�6H   $
��left=�6X   Opis:6z   #  Xceed.Wpf.Toolkit.ColorPicker  5#      -   5        $��ColorPickerPolje��5#   "   $ Unos boje etikete��6;   $	��Top=�6w   	   AvailableColorsHeader$	 Izaberite boju��6�   
   RecentColorsHeader$
 Prethodno korištene boje��6�      ShowRecentColors .    StandardColorsHeader$
 Boje��6�   !   AvailableColorsSortingMode$ HueSaturationBrightness=�6     AdvancedButtonHeader$ Napredno��6M     StandardButtonHeader$ 	Standarno��6m   J� RenderTransformOrigin$ 
1.21,4.705&�6�  $��1��6�  $��1��6�  $��51��6�  $��0,10,0,0q�6�     SelectedColor 6W   �� *Boja2+6�  �� 5$      -   5        $��xOznaka��5$   3   $��0��6   $��1��6#   .��6d   ��5&      �� 5'       �� Path$ Oznaka�6    �� UpdateSourceTrigger$ 	LostFocus=�6,    �� ValidationRules 5(      ,   &HCIProject1._2.ValidacijaOznakeResursa  5)      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6<   5,      .��5.        =� ErrorTemplate 5/      �� 50      .R�51      �� .+�52      ��  �� Orientation$ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�53   "   �� 
���  ��$��20��6:   $��20��6E    �� CornerRadius$ 10��6Q    6c   �� $ /ErrorContent�._�54   &   �� $��!��61   $��Center=�6:   $��center=�6U   $
��Bold"�6r   
�������6�   56   #   �� 57   "   $��5 0 0 0q�6,   
���  ����6N   �� *[0].ErrorContent+59      �� 5:      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X    6d   �� $ /ErrorContent�._�5;   "   �� $��textBox��6<   5<      5=      5?      .��5A   ,   5B      �� 5F      $��0 0 0 3q�6   $��2��6,   $��2��6<   $��Stretch=�6I   .��5G      �� -   5        $��	opisPolje��5G   �   $( "Ovde unesite opis etikete resursa.��6b    �� AcceptsReturn . $	��371��6�   ��6   �� $ OpisEtikete�$ PropertyChanged=�6�   5H      �� 5I      -   5         ��Name$ PotvrdiEtiketaBtn��5I      $��Potvrdi��6F   $
��Left=�6X   $��
145,32,0,0q�6s   $��3��6�   $	��Top=�6�   $	��100��6�   $��35��6�   �� 5J      -   5        $ OtkaziEtiketaBtn��5J      $��Odustani��6F   $��1��6Y   $
��Left=�6i   $��
176,32,0,0q�6�   $��3��6�   $	��Top=�6�   $	��100��6�   $��35��6�   5M      5N      5O      