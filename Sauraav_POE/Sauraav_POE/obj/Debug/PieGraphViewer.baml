   M S B A M L   `   `   `  ����F  BSauraav_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sauraav_POESauraav_POE  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	        Sauraav_POE.PieGraphViewer   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   +localclr-namespace:Sauraav_POE     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   $	��600��5	   	   $	��760��5
   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency . .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   61   �� 5      $��* �6#   6/    � RowDefinitions 5      �� 5      $��70 �6    6.   �� 5      $��* �6    6-   .+�5      �� ���	#8F65394C$��0��5      $��1��5      6'   �� 5      ���#65394C$��2��5       �� RadiusX$ 15��5        �� RadiusY$ 15��5!      6'   �� 5"      
������ $��0��5#      $��1��5$      5%      �� 5&      ���#65394C$��2��5'      $��1��5(      $ 15��5)      $ 15��5*      6'   �� 5+      -   5         ��Name$ viewGraph_Scroller��5/      $
��Auto=�5+      $��1��5,      $��1��5-      $��10, 10 ,10 ,10q�5.      .��50      � .+�53      � .+�54      � $��-250,20,20,110q�6   .+�55        LiveCharts.Wpf.PieChart  -   5        &   LiveCharts.Wpf.Charts.Base.Chart	   LegendLocation$
	 Left=�55   +   
   	Hoverable
 . $��	0,20,0,20q�58   +   $��Center=�5:   +   $	��250��5;   +      Series 56   +   �� *SeriesCollection+   ChartLegend 5<   "   "  LiveCharts.Wpf.DefaultLegend  5=   &      
BulletSize$ 30Q�68   $��15(�5>   8   
�������5?   M      DataTooltip 5A   "   #  LiveCharts.Wpf.DefaultTooltip  5B   &      
BulletSize$ 10Q�69   6K   5D      5E      5F      5I      5K      �� 5M      ���#462834$��0��5N      $��0��5O      $ 15��5P      $ 15��5Q      6'   �� 5R      -   5        $��0��5R      $��<----��5S      $��Center=�5T      $
��Left=�5U      
�������$��22(�5W      $��50,0,0,0q�5X         ModernButton#��[  5Y      $��0��5[      �� 5\      $��1��6   $��View Pie Graph��5]      $	��Top=�5^      $
��Left=�5_      
�������$��22(�5a      $��20q�5b      6&   5e      5f      5g      