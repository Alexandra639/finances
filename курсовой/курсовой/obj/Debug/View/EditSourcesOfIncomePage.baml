   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   3    -курсовой.View.EditSourcesOfIncomePage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	     � Title$F  @Редактирование источников доходов��5   	   $	��517��63   $��360.591��6@   $��16(�6P    � 
ResizeMode$ CanResizeWithGrip=�5	   	    � WindowStartupLocation$ CenterScreen=�6(    � 	Resources 5
         StyleButton �� 
TargetType �� Property �� Value��%*  &	        �� 5   
   " ��6$   .�5      ��  � ��$ 	0 10 0 10q�6'   6;   �� 5       � ��$ Candara)�67   6I   �� 5       � ��$ 16(�65   6B   �� 5       � ��$ 8��6)   �� 5       � ��$	 250��6)   �� 5       � ��$ Center=�6;   6L   5      5      .��5      � $��	0,-8,3,-1q�6   ��5   
   �� 5       �� ImageSource$ /Resourses/1.jpg��6    �� Opacity$	 0.4Q�68   	 � ColumnDefinitions	 5   
   �� 5      $
��124* �6   5      �� 5      $	��51* �6   .+�5   
   �� $��0��6   $��Center=�6%   $��Center=�6B   $��-70,-4,-70,-11q�6]   $	��490��6u   $	��510��6�   $��2��6�   .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 	DataGrid1��5   8      
IsReadOnly . $	��188��6+      AutoGenerateColumns .  $��Italic$�6�   $��
95,60,95,0q�6�    J� RenderTransformOrigin$ 0.754,0.508&�6�   ��6K   �� *SourceOfIncomeDataGrid+ �� SelectedIndex 6{   �� *selectedItem+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$# Источник дохода��6)      
FontFamily$ Candara)�6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *income_type+5$      �� 5%      #��[  6   $��Удалить��6:   ���	#FFF7343D���	#FFF7343D
�������$
��Bold"�6�   $��Italic$�6�   $ 0.494,5.167&�6�   $��24��6    K� ZIndex$ -1��6  $��234,15,106,0q�6  ��6L   �� *DeleteSourceOfIncome+6  �� 5&      -   5         ��Name$ Label1��5&   .   $#��Источник дохода��6   $��Candara)�6>   $
��Bold"�6S   $��Italic$�6e   $��120,5,119,0q�6x   �� 5'      -   5         ��Name$ TextBox1��5'      ���	#FF3656FB$��120,0,119,0q�6[   ��6@   �� *	icomeType+6[   �� 5(      #��[  6   $�� Добавить��6:   
����������	#FF3656FB���	#FF3656FB$
��Bold"�6�   $��Italic$�6�   $��95,15,95,10q�6�   ��6N   �� *AddSourceOfIncome+6�   �� 5)      #��[  6   $��
Назад��6:   ���	#FFF7343D���	#FFF7343D
�������$
��Bold"�6�   $��Italic$�6�   $ 0.494,5.167&�6�   $��24��6�   $ -1��6�   $��
95,30,95,0q�6  ��6J   �� *Back+6  5*      5+      5,      