   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Table-Of-Responsibilities*   $Table_Of_Responsibilities.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	   $��357.5��6   $	��520��6+   .��5      � .+�5   
   �� .@�5      �� $��Таблица��6   .��5      � .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ begin��5   !   $��Center=�5      $	��Top=�5      $��0,36,0,0q�5      $	��242��5      $��42��5      *   $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$! Начало периода��5        5      -   5        $	 end��5   !   $��Center=�5      $	��Top=�5      $��133,92,133,0q�5      $	��242��5      $��42��5       . $ Конец периода��5      �� 5      -   5        $��СОЗДАТЬ��5      $��Center=�6/   $��0,0,0,20q�6L   $	��120��6^   $��14(�6j   $��41��6x   $��Bottom=�6�   6�   5       5!      �� 5"      $��Участники��6   .��5#      � .+�5$      �� -   5         ��Name$ 
StewardBox��5$      $	��Top=�5%      $
��Left=�5&      $��	80,36,0,0q�5'      $	��242��5(      $��40��5)         ClearTextButton . $ Фамилия Имя��5+      5,      �� 5-      -   5        $��manager��5-      $ ��Распорядитель��6/   $��20��6G   $	��300��6S   $��	80,96,0,0q�6_   $	��Top=�6r   $
��Left=�6�   �� 5.      -   5        $��panel��5.      $��
Пульт��6,   $��20��6<   $	��300��6H   $��
80,126,0,0q�6T   $	��Top=�6h   $
��Left=�6�   �� 5/      -   5        $��
microphone��5/      $&�� Трибуна, микрофон��61   $��20��6M   $	��300��6Y   $��
80,156,0,0q�6e   $	��Top=�6y   $
��Left=�6�   �� 50      -	   5        $��
SaveButton��50      $��Сохранить��6/   $��Center=�6C   $��
0,0,160,20q�6`   $	��140��6t   $��14(�6�   $��40��6�   $��Bottom=�6�   {�.  6�   �� 51      -
   5        $��Добавить��51      $��Center=�60   $��
160,0,0,20q�6M   $	��140��6a   $��14(�6m   $��40��6{   $��Bottom=�6�   6�   52      53      54      55      56      