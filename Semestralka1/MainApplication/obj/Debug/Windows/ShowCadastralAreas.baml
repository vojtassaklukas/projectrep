   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   0    *MainApplication.Windows.ShowCadastralAreas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$  All cadastral areas��5   	   $	��300��6%   $	��300��62    � DataContext 5	      (   "MainApplication.Windows.MainWindow  5
   
   .��5      � .+�5   
   �� -   5         ��Name$ StackPanelCadastrals��5      $
��Left=�64   $	��Top=�5      $
��Auto��6-   $
��Auto��6;   .+�5      �� $��Cadastral areas��6   $��Center=�6.   $��Center=�6I   &   System.Windows.Controls.DataGrid  5      -   5        $��CadastralProperties��5         CanUserAddRows .  $	��Top=�6I      
IsReadOnly . ��. $
��Auto=�5      $	��200��5      $
��Left=�6$   $
��Auto��6?      AutoGenerateColumns .  ��6L   ��  �� Path$ 
Cadastrals�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Cadastral Name��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *CadastralName+  5      $ Cadastral Id��6)   	 6?   �� *CadastralId+5      5      5      5      