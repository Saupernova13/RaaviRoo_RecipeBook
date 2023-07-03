﻿using Sauraav_POE.MVM.View;
using Sauraav_POE.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sauraav_POE
{
    /// <summary>
    /// Interaction logic for customShowMessage.xaml
    /// </summary>
    public partial class customShowMessage : Window
    {
        public static bool isNull = false;
        public static addIng_Step closeThis;
        public customShowMessage(string windowName, string WindowDetails, addIng_Step closeWindow = null)
        {
            InitializeComponent();
            CreateUIElements(windowName, WindowDetails);
            if (!(closeWindow == null))
            {
                isNull = false;
                closeThis = closeWindow;
            }
            else
            {
                isNull = true;
            }
        }

        private void CreateUIElements(string windowName, string WindowDetails)
        {
            Border outerBorder = new Border();
            outerBorder.Background = new SolidColorBrush(Color.FromRgb(49, 28, 37));
            outerBorder.CornerRadius = new CornerRadius(15);
            this.Content = outerBorder;
            Border innerBorder = new Border();
            innerBorder.Background = new SolidColorBrush(Color.FromRgb(101, 57, 76));
            innerBorder.CornerRadius = new CornerRadius(20);
            innerBorder.Margin = new Thickness(10);
            outerBorder.Child = innerBorder;
            Grid grid = new Grid();
            innerBorder.Child = grid;
            Button button = new Button();
            button.Margin = new Thickness(315, 166, 10, 10);
            button.Style = (Style)FindResource("ModernButton");
            button.Content = "OK";
            button.Click += OK_Click;
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37));
            rectangle.Margin = new Thickness(0, 39, 0, 188);
            Label label = new Label();
            label.Content = windowName;
            label.FontSize = 20;
            label.Margin = new Thickness(10, 0, 257, 196);
            label.Foreground = Brushes.White;
            TextBlock textBlock = new TextBlock();
            textBlock.Foreground = Brushes.White;
            textBlock.FontSize = 15;
            textBlock.Text = WindowDetails;
            textBlock.Margin = new Thickness(15, 54, 15, 69);


            grid.Children.Add(button);
            grid.Children.Add(rectangle);
            grid.Children.Add(label);
            grid.Children.Add(textBlock);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.allRecipes.Add(AddRecipeView.currentRecipe);
            this.Close();
            if (!isNull)
            {
                closeThis.Close();
            }

        }
    }
}
