   M S B A M L   `   `   `  ����F  BSauraav_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Sauraav_POE.MVM.ViewSauraav_POE.MVM.View  5      (    "Sauraav_POE.MVM.View.AddRecipeView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Sauraav_POE.MVM.View     5      .��5      � .+�5   
   � $��10q�6     � ColumnDefinitions  5      �� 5      $	��300 �6#   61   �� 5      $
��Auto �6#   62    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      �� $��0��6   .+�5      �� $��Recipe Name:��6   
�������5   -   �� 5      -   5         ��Name$ recipeNameTextBox��5      $	��200��5      $��40��5      $	��Top=�5      $
��Left=�5         ModernTextBox#��[  5      
 � Tag$ Recipe Name...��5      �� 5       $��Author Name:��6   
�������5!   -   �� 5"      -   5        $ recipeAuthorNameTextBox��5"      $	��200��5#      $��40��5$      $	��Top=�5%      $
��Left=�5&      #��[  5'      $ Author Name...��5(      �� 5+      $��Serving Size:��6   
�������5,   -   �� 5-      -   5        $ servingSizeTextBox��5-      $	��200��5.      $��40��5/      $	��Top=�50      $
��Left=�51      #��[  52      $ Serving Size...��53      54      �� 58      $��Recipe Description:��6   
�������59   -   5;      �� 5<      -   5         ��Name$ describeRecipe��5@        ModernRichTextBox#��[ 5<      $	��Top=�5=      $
��Left=�5>      $��0q�5A      $	��200��5B      $	��500��5C      ���#d3d3d3$��1��5E      $��0,5,0,0q�5F      $��2��5G      . �5H      /� .T�5I      J� .*�6    Describe the Dish...66   5J      5K      �� 5L      $��1��6   .+�5N      �� $��Preparation Time:��6   
�������5O   -   �� 5P      -   5        $ preparationTimeTextBox��5P      $	��200��5Q      $��40��5R      $	��Top=�5S      $
��Left=�5T      #��[  5U      $ Enter Time in Minutes...��5V      5W      �� 5[      $��Number of Ingredients:��6   
�������5\   -   �� 5]      -   5        $ ingredientQuantityTextBox��5]      $	��200��5^      $��40��5_      $	��Top=�5`      $
��Left=�5a      #��[  5b      $ Number of Ingredients...��5c      5d      �� 5e      $��Number of Steps:��6   
�������5f   -   �� 5g      -   5        $ numberOfStepsTextBox��5g      $	��200��5h      $��40��5i      $	��Top=�5j      $
��Left=�5k      #��[  5l      $ Number of Steps...��5m      5n      5q      �� 5r      -   5        $��1��5r      $
��Next��5s      $
��Left=�5t      $��100,211,0,0q�5u      $��1��5v      $	��Top=�5w        ModernButton#��[ 5x      $	��100��5y      5z      �� 5{      -	   5        $��1��5{      $��Autofill��5|      $
��Left=�5}      $��-10,211,0,0q�5~      $��1��5      $	��Top=�5�      #��[ 5�      $	��100��5�      5�      5�      5�      5�      