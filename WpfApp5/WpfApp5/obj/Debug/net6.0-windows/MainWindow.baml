   M S B A M L   `   `   `  ����  WpfApp5    DailyPlanner.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Daily Planner��5   	   $	��450��6   $	��800��6,    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName��%  &	        �� 5   
   " ��6$   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5	       � ��$ 14(�6)   �� 5
       � ��$ Segoe UI)�6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �����6+   �� 5       � �� �#3F51B56+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 5q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ border��6%   #��z��65   $ 5��6_   �� 5      $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   �� $ border��6)    � �� �#5C6BC06S   5      5      5      5       5!      .��5"      � ���#ECEFF1 � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $��* �6   .+�5(   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datePicker��5(      $��10q�6O      SelectedDate 6)   �� *SelectedDate+6O   �� 5*   
   $��1��6   $��10q�6d   ��6    �� *Notes+ �� SelectedItem 6>   �� *SelectedNote+ �� View 5+      �� 5,      .P�5-      �� $��Title��6%    �� DisplayMemberBinding 64   �� *Title+�� 5.      $��Description��6%    6:   �� *Description+�� 5/      $
��Date��6%    63   �� *Date+50      52      �� 54   
   $��1��6   $��Right=�6"   $��10q�6>   .+�55      �� $��Add Note��6   #��[  6K   $��0 0 0 5q�6p   ��6(   �� *AddNoteCommand+6p   �� 56      $��	Edit Note��6   #��[  6M   $��0 0 0 5q�6r   ��6)   �� *EditNoteCommand+6r   �� 57      $��Delete Note��6   #��[  6Q   ��6+   �� *DeleteNoteCommand+6Q   58      59      5:      