   M S B A M L   `   `   `  ����F  BSauraav_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Sauraav_POE.MVM.ViewModelSauraav_POE.MVM.ViewModel  5   	   )clr-namespace:Sauraav_POESauraav_POE  5   	       Sauraav_POE.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =	viewModel'clr-namespace:Sauraav_POE.MVM.ViewModel     5   	   +localclr-namespace:Sauraav_POE     5   	   $	��600��5	   	   $	��760��5
   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5      -   'Sauraav_POE.MVM.ViewModel.MainViewModel  5   
   .��5      �� ���#65394C �� CornerRadius$ 15��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   61   �� 5      6%    � RowDefinitions 5      �� 5      $��75 �6    6.   �� 5      6"   .+�5      �� ���	#9A311C25 J� IsHitTestVisible .  $��0��5       $��1��5!      �� 5#      ���	#9A311C25 .  $��0��5%      $��0��5&      �� 5(      $��0��6   $��RaaviRoo Recipe's��5)      $��Center=�5*      $��Center=�5+      
�������$��22(�5-      6(   �� 5.      $��1��6   $��0,0,0,0q�5/      .+�50      	� -   5        	 	�Name$	 HomeRadioButton��50      $
��Home��51      $��50��52      
�������$��14(�54         menuButtonTheme#��[  55      
 d� 	IsChecked$

 TrueY�56      ��57      �� *HomeViewNewViewCommand+	� 58      $��Create Recipe��59      $��50��5:      
�������$��14(�5<      #��[  5=      ��5>      �� *AddRecipeViewCommand+	� 5?      $��View Recipes��6   $��50��5@      
�������$��14(�5B      #��[  5C      ��5D      �� *ViewRecipeViewCommand+	� 5E      $��Edit Recipes��6   $��50��5F      
�������$��14(�5H      #��[  5I      ��5J      �� *EditViewViewCommand+	� 5K      $��Scale Recipes��6   $��50��5L      
�������$��14(�5N      #��[  5O      ��5P      �� *ScaleViewCommand+	� 5Q      $��Menus��6   $��50��5R      
�������$��14(�5T      #��[  5U      ��5V      �� *PieViewCommand+	� 5W      -   5        $��Close Program��5W      $��50��5X      
�������$��14(�5Z      #��[  5[      5\      5]      �� 5^      -   5         ��Name$ activeTimeTextBlock��5^      $��16(�5_      
�������$��1��69   $��0��6I   $��20,20,40,20q�6V   $��Center=�6k   $��Right=�6�   �� 5a      -   5         ��Name$ 
tabControl��5a      $��1��5b      $��1��5c      $��10q�5d      ��5e      �� *CurrentView+�� 5f      $
��Left=�6   $	��600��5g      $��	197,0,0,0q�5h      $��2��5i      $	��Top=�5j      $��5��5k      ���#311c25$��2��5m      $y�Hidden=�6,   5n      5o      5p      