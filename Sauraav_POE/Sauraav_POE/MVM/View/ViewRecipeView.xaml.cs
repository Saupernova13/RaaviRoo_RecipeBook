//Sauraav Jayrajh
//ST10024620

using Sauraav_POE_Part_2;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sauraav_POE.MVM.View
{

    public partial class ViewRecipeView
    {
        public int index;
        public List<string> items;
        public List<RecipeComplete> listRecipe;
        public ViewRecipeView()
        {
            listRecipe = MainWindow.allRecipes;
            InitializeComponent();
            for (int i = 0; i < MainWindow.allRecipes.Count; i++)
            {

                addLists(i);
            }
        }
        public void addLists(int n)
        {
            index = n;
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0)

            };
            Label recipeNameLabel = new Label()
            {
                Name = $"recipeNameLabel_{n}",
                Content = $"Recipe No.{n + 1}: {(listRecipe[n]?.recipeName ?? "")}",
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
            DisplayViewRecipe displayVR = new DisplayViewRecipe(MainWindow.allRecipes[index]);
            displayVR.Show();
        }
    }
}
