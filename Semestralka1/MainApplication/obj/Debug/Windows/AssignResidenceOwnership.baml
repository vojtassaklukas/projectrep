   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   6    0MainApplication.Windows.AssignResidenceOwnership   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$   Assign Residence Ownership��5   	   $	��300��6,   $	��300��69   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 	EanLabel1��5      $��Ean of old owner:��6#   $��Right=�6?   $��Center=�6[   �� 5   
   -   5         ��Name$ OldOwner��5      $��1��6$   $
��Left=�64   $��20��6O   $��10q�6[    �� TextWrapping$
 Wrap=�6g   $��Center=�6{   $	��120��6�   $��0��6�   �� 5   
   -   5        $ 	EanLabel2��5      $��Ean of new owner:��6#   $��Right=�6?   $��Center=�6[   $��1��6v   $��0��6�   �� 5   
   -   5        $ NewOwner��5      $��1��6$   $
��Left=�64   $��20��6O   $��10q�6[   $
 Wrap=�6g   $��Center=�6{   $	��120��6�   $��1��6�   �� 5   
   -   5        $ PropertyLabel��5      $��Property Id:��6'   $��Right=�6>   $��Center=�6Z   $��2��6u   $��0��6�   �� 5   
   -   5        $ 
PropertyId��5      $��1��6&   $
��Left=�66   $��20��6Q   $��10q�6]   $
 Wrap=�6i   $��Center=�6}   $	��120��6�   $��2��6�   �� 5   
   -   5        $ CadastralLabel��5      $��Cadastral Id:��6(   $��Right=�6@   $��Center=�6\   $��3��6w   $��0��6�   �� 5   
   -   5        $ CadastralId��5      $��1��6'   $
��Left=�67   $��10q�6R   $��3��6^   $��Center=�6k   $	��120��6�   �� 5   
   -	   5         ��Name$ AssignOwnership��5      $��Assign��6*   $��Center=�6;   $��4��6X   $��0��6e   $��Center=�6u   $��75��6�   6�   �� 5   
   -
   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��4��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5       