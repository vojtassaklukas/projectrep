   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   =    7MainApplication.Windows.AssignExistingOwnershipInterest   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$(  "Assign Existing Ownership Interest��5   	   $	��300��64   $	��300��6A   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ PropertyLabel��5      $��Property list Id:��6'   $��Right=�6C   $��Center=�6_   $��0��6z   $��0��6�   �� 5   
   -   5         ��Name$ PropertyListId��5      $��1��6*   $
��Left=�6:   $��20��6U   $��10q�6a    �� TextWrapping$
 Wrap=�6m   $��Center=�6�   $	��120��6�   $��0��6�   �� 5   
   -   5        $ CadastralLabel��5      $��Cadastral Id:��6(   $��Right=�6@   $��Center=�6\   $��1��6w   $��0��6�   �� 5   
   -   5        $ CadastralId��5      $��1��6'   $
��Left=�67   $��10q�6R   $��1��6^   $��Center=�6k   $	��120��6�   �� 5   
   -   5         ��Name$ AssignInterest��5      $��Assign��6)   $��Center=�6:   $��2��6W   $��0��6d   $��Center=�6t   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��2��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5      