   M S B A M L   `   `   `  ����  MainApplication(    "MainApplication.Windows.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��600��6)   .��5      �  � RowDefinitions 5	   
   �� 5
      $	��19* �6   �� 5      $	��11* �6   �� 5      $
��251* �6   �� 5      $��4* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   o� -   5         o�Name$
 Menu��5      $
��Left=�6   $
��Auto��68   $��0��6E   $��0��6R   $	��Top=�6b   .@�5      m� $��Cadastral areas��6   $��26��60   $
��Auto��6<   .@�5      m� -   5        $��Add cadastral area��5      67   m� 5      -   5        $��Show areas by name��5      67   m� 5      -   5        $��Show properties��5      64   m� 5      -   5        $��Delete cadastral area��5      6:   5      m� 5      $��Citizens��6   $��26��6)   $
��Auto��65   .@�5      m� -   5        $��Add citizen��5      60   m� 5      -   5        $ ��Assign permanent residence��5      6?   m� 5      -   5        $'��!Show citizens permanent residence��5      6F   m� 5      -	   5        $"��Show properties in cadastral��5      6A   m� 5      -
   5        $��Show all properties��5      68   5       m� 5!      $��Property Lists��6   $��26��6/   $
��Auto��6;   .@�5"      m� -   5        $��Add Property list��5"      66   m� 5#      -   5        $��Add new ownership��5#      66   m� 5$      -   5        $ ��Assign ownership interests��5$      6?   m� 5%      -   5        $!��Unassign existing ownership��5%      6@   m� 5&      -   5        $(��"Find property list by cadastral id��5&      6G   m� 5'      -   5        $*��$Find property list by cadastral name��5'      6I   m� 5(      -   5        $��Delete property list��5(      69   5)      m� 5*      $��
Properties��6   $��26��6+   $
��Auto��67   .@�5+      m� -   5        $��Add Property��5+      61   m� 5,      -   5        $��Assign owner��5,      61   m� 5-      -   5        $#��Find property by cadastral id��5-      6B   m� 5.      -   5        $%��Find property by cadastral name��5.      6D   m� 5/      -   5        $$��Show property permanent people��5/      6C   m� 50      -   5        $��Delete property��50      64   51      m� 52      $
��Data��6   $��26��6%   $
��Auto��61   .@�53      m� -   5        $��Generate��53      6-   m� 54      -   5        $��Save to file��54      61   m� 55      -   5        $��Load from file��55      63   56      57      �� 58   
   -   5         ��Name$ StackPanelCadastrals��58      $
��Left=�64   $	��Top=�59      $
��Auto��6.   $
��Auto��6<   $��2��6I   $��0��6V   $y�Hidden=�6g   .+�5:      �� $-��'Choose cadastral for your property list��6   $��Center=�6F   $��Center=�6a   &   System.Windows.Controls.DataGrid  5;      -   5          Name$ DataGridCadastrals��5;         
IsReadOnly .    CanUserAddRows .  ��. $
��Auto=�5<      $	��300��6G      Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Cadastral id��6I   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6)   �� *CadastralId+6I     5?      $	 Cadastral name��6K   
 6)   �� *CadastralName+6K   4  .System.Windows.Controls.DataGridTemplateColumn  5@         CellTemplate 5A      �� 5B      .R�5C   "   �� -   5        .��5C   L   
Add here6V   5D      5F      5H      �� 5I      -   5        .��5I   /   Close66   5J      �� 5L   
   -   5        $' !StackPanelCadastralsForProperties��5L      $
��Left=�6A   $	��Top=�5M      $
��Auto��6-   $
��Auto��6;   $��2��6H   $��0��6U   $y�Hidden=�6e   $��	0,0.2,0,0q�6y   .+�5N      �� $(��"Choose cadastral for your property��6   $��Center=�6A   $��Center=�6\     5O      -    5        $% DataGridCadastralsForProperties��5O       .  .  ��. $
��Auto=�5P      $	��300��6G    5Q        5R      $	 Cadastral id��6I   
 6)   �� *CadastralId+6I     5S      $	 Cadastral name��6K   
 6)   �� *CadastralName+6K     5T       5U      �� 5V      .R�5W   "   �� -!   5        .��5W   N   Choose6V   5X      5Z      5\      �� 5]      -"   5        .��5]   :   Close6A   5^      �� 5`   
   -#   5        $ StackPanelPropertyLists��5`      $
��Left=�67   $	��Top=�5a      $
��Auto��6-   $
��Auto��6;   $��2��6H   $��1��6U   $y�Hidden=�6e   $��	0,0.2,0,0q�6y   .+�5b      �� $'��!Choose property list for property��6   $��Center=�6@   $��Center=�6[     5c      -$   5        $ DataGridPropertyLists��5c       .  .  ��. $
��Auto=�5d      $	��300��6G    5e        5f      $	 Property list id��6L   
 6)   �� *PropertyListId+6L     5g       5h      �� 5i      .R�5j   "   �� -%   5        .��5j   =   
Add here6G   5k      5m      5o      �� 5p      -&   5        .��5p   .   Close65   5q      5r      5s      