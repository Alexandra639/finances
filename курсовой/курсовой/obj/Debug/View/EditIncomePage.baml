   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   *    $курсовой.View.EditIncomePage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	     � Title$+  %Редактировать доход��5   	   $��326.203��6%   $��437.968��66   $��16(�6F    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � WindowStartupLocation$ CenterScreen=�6(    � 	Resources 5
         StyleButton �� 
TargetType �� Property �� Value��%?  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 	0 10 0 10q�6'   �� 5       � ��$ Candara)�67   �� 5       � ��$ 16(�65   �� 5       � ��$	 400��6)   �� 5       � ��$ Center=�6;   �� 5       � ��
 � ���6+   �� 5       � ��
 � ���6,   5      5      .��5      � $��0,0,-5,0q�6   ��5   
   �� 5       �� ImageSource$ /Resourses/1.jpg��6    �� Opacity$	 0.4Q�68   	 � ColumnDefinitions	 5   
   �� 5      $
��Auto �6   5      �� 5      $	��79* �6   �� 5      $
��356* �6   .+�5    
   �� $��3��6   $��Center=�6)   $��Center=�6F   $��18,14,17,15q�6a   .+�5!      �� -   5        $��Label1��5!   .   $#��Источник дохода��6   $��Candara)�6=   $
��Bold"�6R   $��Italic$�6d   �� 5"      -   5        $��Sources��5"      ���	#FF3656FB
 �� DisplayMemberPath$
 income_type��6?    �� SelectedItem 6_   �� *SelectedSourceUpdate+ �� SelectedIndex 6�   �� *SelectedSourceIdUpdate+��6�   �� *SourcesUpdate+�� 5#      -   5        $��Label2��5#   *   $��Дата дохода��6   $��Candara)�68   $
��Bold"�6M   $��Italic$�6_   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$
 Date��5$   =   $	��0,5q�6K   $��Candara)�6X   ���	#FF3656FB$
��Bold"�6�   $��Italic$�6�   $	��397��6�      SelectedDate 6   �� *
DateUpdate+6�   �� 5%      -   5        $��Label4��5%   $   $��
Сумма��6   $��Candara)�62   $
��Bold"�6G   $��Italic$�6Y   �� 5&      -   5        $��
SizeUpdate��5&      ���	#FF3656FB��6@   �� *
SizeUpdate+�� 5(      #��[  6   $��Сохранить��6:   ���	#FF3656FB���	#FF3656FB
�������$
��Bold"�6�   $��Italic$�6�   $	��339��6�   ��6N   �� *UpdateIncome+6�   �� 5)      #��[  6   $��Отмена��6:   
����������	#FFF7343D���	#FFF7343D$
��Bold"�6�   $��Italic$�6�   $	��229��6�   ��6K   �� *Cancel+6�   5,      5/      50      