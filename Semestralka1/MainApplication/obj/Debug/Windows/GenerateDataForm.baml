   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   .    (MainApplication.Windows.GenerateDataForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$  GenerateDataForm��5   	   $	��500��6"   $	��300��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��Cadastral count:��6   $��Right=�6,   $��Center=�6H   $��0��6c   $��0��6p   $��0,29.6,0.2,34.8q�6�   �� 5   
   -   5         ��Name$ CadastralCount��5      $��1��6*   $
��Left=�6:   $��20��6U   $��10q�6a    �� TextWrapping$
 Wrap=�6m   $��Center=�6�   $	��120��6�   $��0��6�   �� 5   
   $��Citizen count:��6   $��Right=�6*   $��Center=�6F   $��1��6a   $��0��6n   $��0,29.6,0.2,34.8q�6~   �� 5   
   -   5        $ CitizenCount��5      $��1��6(   $
��Left=�68   $��20��6S   $��10q�6_   $
 Wrap=�6k   $��Center=�6   $	��120��6�   $��1��6�   �� 5   
   $��Property list count:��6   $��Right=�60   $��Center=�6L   $��2��6g   $��0��6t   $��0,29.6,0.2,34.8q�6�   �� 5   
   -   5        $ PropertyListCount��5      $��1��6-   $
��Left=�6=   $��20��6X   $��10q�6d   $
 Wrap=�6p   $��Center=�6�   $	��120��6�   $��2��6�   �� 5   
   $��Properties count:��6   $��Right=�6-   $��Center=�6I   $��3��6d   $��0��6q   $��0,29.6,0.2,34.8q�6�   �� 5   
   -   5        $ PRopertiesCount��5      $��1��6+   $
��Left=�6;   $��20��6V   $��10q�6b   $
 Wrap=�6n   $��Center=�6�   $	��120��6�   $��3��6�   �� 5   
   -   5         ��Name$ Generate��5      $��Generate��6#   $��Center=�66   $��4��6S   $��0��6`   $��Center=�6p   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��4��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5       