   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   ,    &MainApplication.Windows.ShowProperties   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$  ShowProperties��5   	   $	��400��6    $	��400��6-    � DataContext 5	      0   *MainApplication.Windows.ShowPropertiesForm  5
   
   .��5      � .+�5   
   �� -   5         ��Name$&  StackPanelPropertyListProperties��5      $
��Left=�6@   $	��Top=�5      $
��Auto��6-   .+�5      �� $��Cadastral properties��6   $��Center=�63   $��Center=�6N   &   System.Windows.Controls.DataGrid  5      -   5        $��CadastralProperties��5         CanUserAddRows .  $	��Top=�6I      
IsReadOnly . $
��Left=�5      $
��Auto��62      AutoGenerateColumns .  ��. $
��Auto=�5      $	��300��6G   ��5   ?   ��  �� Path$ 
Properties�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Property Id��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6>   �� *
PropertyId+  5      $ Adress��6)   	 69   �� *Adress+  5      $ Description��6)   	 6>   �� *Description+5      5      5      5      