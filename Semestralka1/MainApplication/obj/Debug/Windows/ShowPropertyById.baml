   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   .    (MainApplication.Windows.ShowPropertyById   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$   Show Property Informations��5   	   $	��500��6,   $	��400��69    � DataContext 5	      9   3MainApplication.Windows.FindPropertyCadastralIdForm  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$# StackPanelPropertyInformation��5      $
��Left=�6=   $	��Top=�5      $
��Auto��6-   $
��Auto��6;   $��0��6H   .+�5      �� $��Property information��6   $��Center=�63   $��Center=�6N   &   System.Windows.Controls.DataGrid  5      -   5        $��PropertyInformation��5         CanUserAddRows .  $	��Top=�6I      
IsReadOnly . $
��Auto��5      $
��Left=�6%   $
��Auto��6@      AutoGenerateColumns .  ��6M   ��  �� Path$ Property�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Property Id��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6>   �� *
PropertyId+  5      $	 Adress��6)   
 69   �� *Adress+  5      $	 Description��6)   
 6>   �� *Description+5      5      �� 5    
   -   5        $% StackPanelPermanentsInformation��5       $
��Left=�6?   $	��Top=�5!      $
��Auto��6-   $��1��6:   .+�5"      �� $"��Permanent people information��6   $��Center=�6;   $��Center=�6V     5#      -   5        $��PermanentsInformation��5#       .  $	��Top=�6K    . $
��Left=�5$      $
��Auto��62    .  ��. $
��Auto=�5&      $	��100��6G   ��5$   ?   �� $ PermanentPeople� 5'        5(      $
	 Name��6)   
 67   �� *Name+  5)      $		 Ean��6)   
 66   �� *EAN+  5*      $	 
Birth date��6)   
 6=   �� *	BirthDate+5,      5-      �� 5.   
   -   5        $  StackPanelPropertyListInfo��5.      $
��Left=�6:   $	��Top=�5/      $
��Auto��6-   $
��Auto��6;   $��2��6H   .+�50      �� $��Propety list information��6   $��Center=�67   $��Center=�6R     51      -   5        $��PropertyListInformation��51       .  $	��Top=�6M    . $
��Auto��52      $
��Left=�6%   $
��Auto��6@    .  ��6M   �� $ PropertyList� 53        54      $	 Property list Id��6)   
 6C   �� *PropertyListId+  55      $	 Cadastral Id��6)   
 6?   �� *Cadastral.CadastralId+  56      $	 Cadastral Name��6)   
 6A   �� *Cadastral.CadastralName+58      59      �� 5:   
   -   5        $&  StackPanelPropertyListProperties��5:      $
��Left=�6@   $	��Top=�5;      $
��Auto��6-   $��3��6:   .+�5<      �� $��Propety list properties��6   $��Center=�66   $��Center=�6Q     5=      -   5        $��PropertyListProperties��5=       .  $	��Top=�6L    . $
��Left=�5>      $
��Auto��62    .  ��. $
��Auto=�5@      $	��100��6G   ��5>   ?   �� $ PropertyListProperties� 5A        5B      $	 Property Id��6)   
 6>   �� *
PropertyId+  5C      $	 Adress��6)   
 69   �� *Adress+  5D      $	 Description��6)   
 6>   �� *Description+5F      5G      �� 5H   
   -	   5        $" StackPanelPropertyListOwners��5H      $
��Left=�6<   $	��Top=�5I      $
��Auto��6-   $
��Auto��6;   $��4��6H   .+�5J      �� $��Propety list owners��6   $��Center=�62   $��Center=�6M     5K      -
   5        $��PropertyListOwners��5K       .  $	��Top=�6H    . $
��Auto��5L      $
��Left=�6%   $
��Auto��6@    .  ��6M   �� $ PropertyListOwners� 5M        5N      $	 
Owner Name��6)   
 6=   �� *Citizen.Name+  5O      $	 	Owner Ean��6)   
 6<   �� *Citizen.EAN+  5P      $	 Ownership Interest��6)   
 6E   �� *
Interest+5R      5S      5T      5U      