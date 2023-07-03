//Sauraav Jayrajh
//ST10024620
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sauraav_POE.MVM.View
{
    public partial class ViewRecipeView
    {
        public ViewRecipeView()
        {
            InitializeComponent();


            for (int i = 1; i < MainWindow.allRecipes.Count; i++)
            {
                addLists(i);
            }


        }
        public void addLists(int n)
        {
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0)

            };

            Label recipeNameLabel = new Label()
            {
                Name = $"recipeNameLabel_{n}",
                Content = $"Recipe No.{n}",
                Foreground = Brushes.White,
                Margin = new Thickness(0, 8, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            rectangle.MouseLeftButtonDown += Rectangle_MouseLeftButtonDown;

            Grid grid = new Grid()
            {
                Margin = new Thickness(10)
            };
            grid.Children.Add(rectangle);
            grid.Children.Add(recipeNameLabel);

            stackPanelSteps.Children.Add(grid);
            viewRecipesList_StackPnl.Children.Add(stackPanelSteps);
        }


        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked");
            DisplayViewRecipe displayVR = new DisplayViewRecipe();
            displayVR.Show();
        }
    }
}
