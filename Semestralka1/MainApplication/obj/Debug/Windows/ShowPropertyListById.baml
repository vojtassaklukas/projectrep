   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   2    ,MainApplication.Windows.ShowPropertyListById   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$$  Show property list information��5   	   $	��300��60   $	��400��6=    � DataContext 5	      2   ,MainApplication.Windows.FindPropertyListById  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$  StackPanelPropertyListInfo��5      $
��Left=�6:   $	��Top=�5      $
��Auto��6-   $
��Auto��6;   $��0��6H   .+�5      �� $��Propety list information��6   $��Center=�67   $��Center=�6R   &   System.Windows.Controls.DataGrid  5      -   5        $��PropertyListInformation��5         CanUserAddRows .  $	��Top=�6M      
IsReadOnly . $
��Auto��5      $
��Left=�6%   $
��Auto��6@      AutoGenerateColumns .  ��6M   ��  �� Path$ PropertyList�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Property list Id��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6C   �� *PropertyListId+  5      $	 Cadastral Id��6)   
 6?   �� *Cadastral.CadastralId+  5      $	 Cadastral Name��6)   
 6A   �� *Cadastral.CadastralName+5      5      �� 5   
   -   5        $&  StackPanelPropertyListProperties��5      $
��Left=�6@   $	��Top=�5       $
��Auto��6-   $��1��6:   .+�5!      �� $��Propety list properties��6   $��Center=�66   $��Center=�6Q     5"      -   5        $��PropertyListProperties��5"       .  $	��Top=�6L    . $
��Left=�5#      $
��Auto��62    .  ��. $
��Auto=�5%      $	��100��6G   ��5#   ?   �� $ PropertyListProperties� 5&        5'      $	 Property Id��6)   
 6>   �� *
PropertyId+  5(      $	 Adress��6)   
 69   �� *Adress+  5)      $	 Description��6)   
 6>   �� *Description+5+      5,      �� 5-   
   -   5        $" StackPanelPropertyListOwners��5-      $
��Left=�6<   $	��Top=�5.      $
��Auto��6-   $
��Auto��6;   $��2��6H   .+�5/      �� $��Propety list owners��6   $��Center=�62   $��Center=�6M     50      -   5        $��PropertyListOwners��50       .  $	��Top=�6H    . $
��Auto��51      $
��Left=�6%   $
��Auto��6@    .  ��6M   �� $ PropertyListOwners� 52        53      $	 
Owner Name��6)   
 6=   �� *Citizen.Name+  54      $	 	Owner Ean��6)   
 6<   �� *Citizen.EAN+  55      $	 Ownership Interest��6)   
 6E   �� *
Interest+57      58      59      5:      