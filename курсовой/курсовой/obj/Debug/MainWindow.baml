   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   !    курсовой.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	     � Title$  Учет финансов��5   	   $	��430��6   $	��575��6,   $��16(�68    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � WindowStartupLocation$ CenterScreen=�6(    � 	Resources 5
         StyleButton �� 
TargetType �� Property �� Value��%X  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 	0 10 0 10q�6'   6;   �� 5       � ��$ Candara)�67   6I   �� 5       � ��$ 16(�65   6B   �� 5       � ��$	 200��6)   67   �� 5       � ��$ Center=�6;   6L   �� 5       � ��
 � ���6;   �� 5       � ��
 � ���6;   5      5      .��5      � $��0,0,-5,0q�6   ��5   
   �� 5       �� ImageSource$ Resourses/1.jpg��6    �� Opacity$	 0.7Q�67   	 � ColumnDefinitions	 5   
   �� 5      5      .+�5   
   �� $��0��6   $��Center=�6%   $��Center=�6B   .+�5       �� $��Candara)�6   
���   �$
��Bold"�6<   $��Italic$�6N   ��5!      �� 5"      
 �� Color$
 	#FF231111��6&   $ 0Q�68   .��5#   $   Логин:5$      �� 5%      -   5        $��TextBox1��5%   .   $��Candara)�6>   ���	#FF0023FF��6   �� *Login+6S   �� 5'      $��Candara)�6   
���   �$
��Bold"�6<   $��Italic$�6N   ��5(      �� 5)      $
 Black��6&   $ 0Q�64   .��5*   $   Пароль:5+      �� 5,      -   5        $��PasswordBox1��5,   0   $��Candara)�6D   ���	#FF002EFF��6   �� *
Password+6Y   �� 5-      #��[  6   $��
Войти��6\    � IsSharedSizeScope . ���	#FF3656FB���	#FF3656FB
�������$
��Bold"�6�   $��Italic$�6�   ��6:   �� *Authorization+6�   �� 5.      #��[  6   $��Регистрация��6:   ���	#FFF7343D
����������	#FFF7343D$
��Bold"�6�   $��Italic$�6�   ��6P   �� *Registration+6�   52      53      54      