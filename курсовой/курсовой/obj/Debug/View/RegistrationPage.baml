   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   '    !курсовой.RegistranionPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	     � Title$  Регистрация��5   	   $	��500��6   $	��700��6*   $��16(�66    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � WindowStartupLocation$ CenterScreen=�6(    � 	Resources 5
         StyleButton �� 
TargetType �� Property �� Value��%X  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 	0 10 0 10q�6'   6;   �� 5       � ��$ Candara)�67   6I   �� 5       � ��$ 16(�65   6B   �� 5       � ��$	 400��6)   67   �� 5       � ��$ Center=�6;   6L   �� 5       � ��
 � ���6;   �� 5       � ��
 � ���6;   5      5      .��5      � $��0,0,-5,0q�6   ��5   
   �� 5       �� ImageSource$ /Resourses/1.jpg��6    �� Opacity$	 0.4Q�68   	 � ColumnDefinitions	 5   
   �� 5      5      .+�5   
   �� $��0��6   $��Center=�6%   $��Center=�6B   .+�5      �� -   5        $��Label1��5   "   $��Имя��6   $��Candara)�60   $
��Bold"�6E   $��Italic$�6W   6l   �� 5       -   5        $��TextBox1��5       ���	#FF3656FB��6>   �� *Name+�� 5!      -   5        $��Label2��5!   &   $��Фамилия��6   $��Candara)�64   $
��Bold"�6I   $��Italic$�6[   6p   �� 5"      -   5        $��TextBox2��5"      ���	#FF3656FB��6>   �� *	Surname+�� 5#      -   5        $��Label3��5#   $   $��
Логин��6   $��Candara)�62   $
��Bold"�6G   $��Italic$�6Y   6n   �� 5$      -   5        $��TextBox3��5$      ���	#FF3656FB��6>   �� *Login+�� 5%      -   5        $��Label4��5%   %   $��Пароль��6   $��Candara)�63   $
��Bold"�6H   $��Italic$�6Z   6o   �� 5&      -   5        $��PasswordBox1��5&      ���	#FF3656FB��6B   �� *
Password+�� 5'      -	   5        $��Label5��5'   3   $-��'Подтверждение пароля��6   $��Candara)�6A   $
��Bold"�6V   $��Italic$�6h   6}   �� 5(      -
   5        $��PasswordBox2��5(      ���	#FF3656FB��6B   �� *	Password2+�� 5)      #��[  6   $+��% Зарегистрироваться��6:   
����������	#FF3656FB���	#FF3656FB$
��Bold"�6�   $��Italic$�6�   ��6X   �� *Registration+6�   �� 5-      #��[  6   $��Отменить��6:   ���	#FFF7343D���	#FFF7343D
�������$
��Bold"�6�   $��Italic$�6�   ��6M   �� *Cancel+6�   50      51      52      