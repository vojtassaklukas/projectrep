   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   2    ,MainApplication.Windows.FindPropertyListById   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$  FindPropertyListById��5   	   $	��300��6&   $	��300��63   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ IdLabel��5      $��Cadastral Id:��6!   $��Right=�69   $��Center=�6U   �� 5   
   -   5         ��Name$ CadastralId��5      $��1��6'   $
��Left=�67   $��20��6R   $��10q�6^    �� TextWrapping$
 Wrap=�6j   $��Center=�6~   $	��120��6�   $��0��6�   �� 5   
   -   5        $ PropertyListIdLabel��5      $��Propoerty List Id:��6-   $��Right=�6J   $��Center=�6f   $��1��6�   $��0��6�   $��0,29.6,0.2,34.8q�6�   �� 5   
   -   5        $ PropertyListId��5      $��1��6*   $
��Left=�6:   $��20��6U   $��10q�6a   $
 Wrap=�6m   $��Center=�6�   $	��120��6�   $��1��6�   �� 5   
   -   5         ��Name$ FindPropoertyListById��5      $
��Find��60   $��Center=�6?   $��2��6\   $��0��6i   $��Center=�6y   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��2��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5      