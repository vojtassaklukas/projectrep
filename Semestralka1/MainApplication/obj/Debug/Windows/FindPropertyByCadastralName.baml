   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   9    3MainApplication.Windows.FindPropertyByCadastralName   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$%  Find Property By Cadastral Name��5   	   $	��300��61   $	��300��6>   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ IdLabel��5      $��Property Id:��6!   $��Right=�68   $��Center=�6T   �� 5   
   -   5         ��Name$ 
PropertyId��5      $��1��6&   $
��Left=�66   $��20��6Q   $��10q�6]    �� TextWrapping$
 Wrap=�6i   $��Center=�6}   $	��120��6�   $��0��6�   �� 5   
   -   5        $ CadastralNameLabel��5      $��Cadastral Name:��6,   $��Right=�6F   $��Center=�6b   $��1��6}   $��0��6�   $��0,29.6,0.2,34.8q�6�   �� 5   
   -   5        $ CadastralName��5      $��1��6)   $
��Left=�69   $��20��6T   $��10q�6`   $
 Wrap=�6l   $��Center=�6�   $	��120��6�   $��1��6�   �� 5   
   -   5         ��Name$ FindProperty��5      $
��Find��6'   $��Center=�66   $��2��6S   $��0��6`   $��Center=�6p   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��2��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5      