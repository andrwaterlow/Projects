   M S B A M L   `   `   `  ����F  BAppsControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AppsControlAppsControl  5           AppsControl.WorkerControls   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:AppsControl     5      .��5	      � -   5          �Name$  workerControl��5	      .+�5
   
   �� -   5         ��Name$ lbl_FirstName��5
      $��Имя��6'   $
��Left=�65   $��	25,22,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ lbl_LastName��5      $��Фамилия��6&   $
��Left=�68   $��	25,64,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ lbl_SecondName��5      $)��#Отчество/Матчество��6(   $
��Left=�6E   $��
25,110,0,0q�6`   $	��Top=�6t   �� 5   
   -   5         ��Name$ tb_FirstName��5      $
��Left=�6J   $��23��6e   $��
155,25,0,0q�6q    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6(   �� *worker.FirstName+6�   �� 5   
   -   5        $ tb_LastName��5      $
��Left=�6H   $��23��6c   $��
155,68,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6'   �� *worker.LastName+6�   �� 5   
   -   5        $ tb_SecondName��5      $
��Left=�6L   $��23��6g   $��155,110,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6)   �� *worker.SecondName+6�   �� 5   
   -   5         ��Name$ cb_Department��5      $
��Left=�6u   $��155,151,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6*   �� *ListDepartment+ �� Text 6R   �� *worker.Department+6�   �� 5   
   -	   5        $ 	cb_Status��5      $
��Left=�6h   $��155,232,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6&   �� *
ListStatus+ 6I   �� *worker.Status+6�   �� 5   
   -
   5        $ lbl_Department��5      $��Департамент��6(   $
��Left=�6>   $��
25,151,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ 	lbl_Phone��5      $��Телефон��6#   $
��Left=�65   $��
25,270,0,0q�6P   $	��Top=�6d   �� 5   
   -   5         ��Name$ chb_Diploma��5      $*��$Два и  более диплома��6Y   $
��Left=�6x   $��
25,315,0,0q�6�   $	��Top=�6�    d� 	IsChecked 6)   �� *worker.TwoOrMoreDiploma+6�   �� 5   
   -   5        $ tb_Cash��5      $
��Left=�6H   $��23��6c   $��155,190,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6#   �� *worker.CashInMounth+6�   �� 5   
   -   5        $ lbl_Cash��5      $��Зарплата��6"   $
��Left=�65   $��
25,190,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ 
lbl_Status��5      $��Статус��6$   $
��Left=�65   $��
25,228,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ tb_Phone��5      $
��Left=�6B   $��23��6]   $��155,274,0,0q�6i   $
 Wrap=�6~   $	��Top=�6�   $	��120��6�   ��6$   �� *worker.Phone+6�   5      5      