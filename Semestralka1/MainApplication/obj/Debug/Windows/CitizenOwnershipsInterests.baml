   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   A%clr-namespace:MainApplication.ClassesMainApplication.Classes  5   	   8    2MainApplication.Windows.CitizenOwnershipsInterests   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	   9classes%clr-namespace:MainApplication.Classes     5   	     � Title$)  #Update citizen Ownerships Interests��5	   	   $	��300��65   $	��300��6B    � DataContext 5
      5   /MainApplication.Windows.AssignOwnershipInterest  5   
   .��5      � .+�5   
   �� -   5         ��Name$' !StackPanelCadastralsForProperties��5      $
��Left=�6A   $	��Top=�5      $
��Auto��6-   $
��Auto��6;   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridOwners��5         CanUserAddRows .  $	��Top=�6@   $
��Auto��5      $
��Left=�6!   $
��Auto��6<   $��0��6I      AutoGenerateColumns .  ��6V   ��  �� Path$ Owners�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$
 Name��67   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6E   �� *Citizen.Name+  5       . $	 Ean��67   	 6D   �� *Citizen.EAN+  5       .  $ Interest��6<   	 6N   �� *
Interest+5      �� 5   
   -   5        .��5   ,   Apply63   5      5      5      