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
        public List<RecipeComplete> listRecipe;

        public ViewRecipeView()
        {
            listRecipe = MainWindow.allRecipes;
            InitializeComponent();
            Label formLabel = new Label()
            {
                Name = $"formLabel",
                Content = $"View Recipes:",
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 20
            };
            viewRecipesList_StackPnl.Children.Add(formLabel);
            for (int i = 0; i < MainWindow.allRecipes.Count; i++)
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
                Content = $"Recipe No.{n + 1}: {(listRecipe[n]?.recipeName ?? "")}",
                Foreground = Brushes.White,
                Margin = new Thickness(10, 8, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 440,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };

            // Use a lambda expression to capture the correct index value
            rectangle.MouseLeftButtonDown += (sender, e) =>
            {
                DisplayViewRecipe displayVR = new DisplayViewRecipe(MainWindow.allRecipes[n]);
                displayVR.Show();
            };

            Grid grid = new Grid()
            {
                Margin = new Thickness(10)
            };
            grid.Children.Add(rectangle);
            grid.Children.Add(recipeNameLabel);

            stackPanelSteps.Children.Add(grid);
            viewRecipesList_StackPnl.Children.Add(stackPanelSteps);
        }
    }
}


