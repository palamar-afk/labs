   M S B A M L   `   `   `  ����	  Lab18    Lab18.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5	   
   �� 5
      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   � $��0��6   $	��200��6!   $
��Left=�6-   .+�5      �� -   5         ��Name$ Block��5      6)   �� 5      -   5        $	��180��5      $
��0,10q�6%   $��Create Folders��63   6l   �� 5      -   5        $	��180��5      $
��0,10q�6%   $��Remove Folders��63   6l   �� 5      -   5        $	��180��5      $
��0,10q�6%   $��Create sub Folders��63   6s   �� 5      -   5        $	��180��5      $
��0,10q�6%   $��Check max name of folder��63   6z   5      � 5   
   $��0��6   $��1��6!   .+�5      �� -   5         ��Name$ FilePathTextBox��5      $��0, 10q�6/   $	��200��6>   $��25��6J   $
��Left=�6V   $	��Top=�6q   .��6�   Путь к файлу6�   �� 5      -   5        $ FileNameTextBox��5      $	��200��60   $��25��6<   $
��Left=�6H   $	��Top=�6c   .��6{   Имя файла6�   �� 5      -   5        $ FileOuputText��5      $	��200��6.   $	��300��6:   $
��Left=�6G   $	��Top=�6b   6|   �� 5      -	   5        $	��100��5      $��25��6!   $��20, 0q�6-   $��Center=�6<   $	��Top=�6Y   .��6�   Найти файл6�   �� 5      -
   5        .��5   :   " Очистить все поля6M   5      5       5!      