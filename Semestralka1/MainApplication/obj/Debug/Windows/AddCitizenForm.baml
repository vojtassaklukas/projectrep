   M S B A M L   `   `   `  ����J  FMainApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MainApplication.WindowsMainApplication.Windows  5   	   ,    &MainApplication.Windows.AddCitizenForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MainApplication.Windows     5   	     � Title$  Add Citizen��5   	   $	��300��6   $	��300��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 	NameLabel��5      $��Name and Surname:��6#   $��Right=�6?   $��Center=�6[   �� 5   
   -   5         ��Name$
 Name��5      $��1��6    $
��Left=�60   $��20��6K   $��10q�6W    �� TextWrapping$
 Wrap=�6c   $��Center=�6w   $	��120��6�   $��0��6�   �� 5   
   -   5        $ EanLabel��5      $
��EAN:��6"   $��Right=�61   $��Center=�6M   $��1��6h   $��0��6u   �� 5   
   -   5        $	 Ean��5      $��1��6   $
��Left=�6/   $��20��6J   $��10q�6V   $
 Wrap=�6b   $��Center=�6v   $	��120��6�   $��1��6�   �� 5   
   -   5        $ BirthDateLabel��5      $��Birth date:��6(   $��Right=�6>   $��Center=�6Z   $��2��6u   $��0��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	BirthDate��5      $��1��6(   $
��Left=�68   $��10q�6S   $��2��6_   $��Center=�6l   $	��120��6�   �� 5   
   -   5         ��Name$ AddcadastralArea��5      $	��Add��6+   $��Center=�69   $��3��6V   $��0��6c   $��Center=�6s   $��75��6�   6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $��Center=�62   $��3��6O   $��1��6\   $��Center=�6l   $��75��6�   6�   5      5      