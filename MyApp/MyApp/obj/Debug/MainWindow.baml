   M S B A M L   `   `   `  ����@  <MyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyAppMyApp  5   	   F BAppsControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:AppsControl;assembly=AppsControlAppsControl 5   	       MyApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyApp     5   	   FAppsControl.clr-namespace:AppsControl;assembly=AppsControl     5   	     � Title$  List Of Workers��5	   	   $	��450��6!   $	��800��6.   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��145* �6   �� 5      $
��119* �6   .+�5   
   �� -   5         ��Name$ ListOfWorkers��5       �� SelectionMode$ Single=�6*   $
��Left=�6A   $	��399��6\   $��	10,10,0,0q�6i   $	��Top=�6|   $	��390��6�   ��5      �� *	Workers+ �� SelectedItem 5      �� *SelectedWorker+ �� View 5      �� 5      .P�5      ��  �� Width$	 100��6%   $��
Сфера��61    �� DisplayMemberBinding 6@   �� *
Department+�� 5      $
 auto��6%   $��ФИО��62    6?   �� *FIO+5      5         AppsControl.WorkerControls  5   
   -   5          Name$ workerControls��5   %   $
��Left=�6=   $	��394��6X   $��
405,15,0,0q�6e   $	��Top=�6y   $	��295��6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 	btn_Apply��5      $��Применить��6$   $��1��68   $
��Left=�6H   $��190,389,0,0q�6c   $	��Top=�6x   $��75��6�   6�   �� 5   
   -   5        $	 
btn_Delete��5      $��Удалить��6%   $��1��67   $
��Left=�6G   $��	0,389,0,0q�6b   $	��Top=�6u   $��75��6�   6�   �� 5   
   -   5        $	 btn_Add��5      $��Добавить��6"   $��1��65   $
��Left=�6E   $��
95,389,0,0q�6`   $	��Top=�6t   $��75��6�   6�   5      5       