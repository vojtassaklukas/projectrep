   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   =    7MainApplication.Windows.ShowpropertyPermanentPeopleForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$(  "Show permanent people of property ��5   	   $	��300��64   $	��300��6A   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ PropertyLabel��5      $��Property Id:��6'   $��Right=�6>   $��Center=�6Z   �� 5   
   -   5         ��Name$ 
PropertyId��5      $��1��6&   $
��Left=�66   $��20��6Q   $��10q�6]    �� TextWrapping$
 Wrap=�6i   $��Center=�6}   $	��120��6�   $��0��6�   �� 5   
   -   5        $ CadastralLabel��5      $��Cadastral Id:��6(   $��Right=�6@   $��Center=�6\   $��1��6w   $��0��6�   �� 5   
   -   5        $ CadastralId��5      $��1��6'   $
��Left=�67   $��20��6R   $��10q�6^   $
 Wrap=�6j   $��Center=�6~   $	��120��6�   $��1��6�   �� 5   
   -   5        $ PropertyListLabel��5      $��Property List Id:��6+   $��Right=�6G   $��Center=�6c   $��2��6~   $��0��6�   �� 5   
   -   5        $ PropertyListId��5      $��1��6*   $
��Left=�6:   $��10q�6U   $��2��6a   $��Center=�6n   $	��120��6�   �� 5   
   -   5         ��Name$ ShowAllPermanentPeople��5      $
��Show��61   $��Center=�6@   $��3��6]   $��0��6j   $��Center=�6z   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��3��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5      