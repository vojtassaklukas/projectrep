   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   9    3MainApplication.Windows.ShowPropertyPermanentPeople   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$   People with permanent stay��5   	   $	��300��6,   $	��300��69    � DataContext 5	      =   7MainApplication.Windows.ShowpropertyPermanentPeopleForm  5
   
   .��5      � .+�5   
   �� -   5         ��Name$% StackPanelPermanentsInformation��5      $
��Left=�6?   $	��Top=�5      $
��Auto��6-   .+�5      �� $"��Permanent people information��6   $��Center=�6;   $��Center=�6V   &   System.Windows.Controls.DataGrid  5      -   5        $��PermanentsInformation��5         CanUserAddRows .  $	��Top=�6K      
IsReadOnly . $
��Left=�5      $
��Auto��62      AutoGenerateColumns .  ��. $
��Auto=�5      $	��100��6G   ��5   ?   ��  �� Path$ PermanentPeople�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *Name+  5      $	 Ean��6)   	 66   �� *EAN+  5      $ 
Birth date��6)   	 6=   �� *	BirthDate+5      5      5      5      