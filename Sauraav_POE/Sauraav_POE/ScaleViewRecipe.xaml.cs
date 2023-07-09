//Sauraav Jayrajh
//ST10024620
using Sauraav_POE_Part_2;
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
namespace Sauraav_POE
{
    public partial class ScaleViewRecipe
    {
        public RecipeComplete scaledRecipe;
        public int parser;
        public ScaleViewRecipe(RecipeComplete inputRecipe, int index)
        {
            scaledRecipe = inputRecipe;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            addLists();
        }

        public void addLists()
        {
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0)
            };
            Label recipeNameLabelHalf = new Label()
            {
                Name = $"scaleLabel_Half",
                Content = "Would you like to scale this recipe's ingredients by 50%?",
                Foreground = Brushes.White,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Rectangle rectangleHalf = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            Label recipeNameLabelDouble = new Label()
            {
                Name = $"scaleLabel_2",
                Content = "Would you like to scale this recipe's ingredients by 200%?",
                Foreground = Brushes.White,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Rectangle rectangleDouble = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            Label recipeNameLabelTriple = new Label()
            {
                Name = $"scaleLabel_3",
                Content = "Would you like to scale this recipe's ingredients by 300%?",
                Foreground = Brushes.White,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Rectangle rectangleTriple = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            Label recipeNameLabelReset = new Label()
            {
                Name = $"scaleLabel_Reset",
                Content = "Would you like to reset this recipe to it's default ingredient values?",
                Foreground = Brushes.White,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Rectangle rectangleReset = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            Grid gridHalf = new Grid()
            {
                Margin = new Thickness(10)
            };
            Grid gridDouble = new Grid()
            {
                Margin = new Thickness(10)
            };
            Grid gridTriple = new Grid()
            {
                Margin = new Thickness(10)
            };
            Grid gridReset = new Grid()
            {
                Margin = new Thickness(10)
            };
            rectangleHalf.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                foreach (Ingredient ing in scaledRecipe.ingredients)
                {
                    ing.quantity = ing.quantity * 0.5;
                    saveChanges();
                }
            };

            rectangleDouble.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                foreach (Ingredient ing in scaledRecipe.ingredients)
                {
                    ing.quantity = ing.quantity * 2;
                    saveChanges();
                }
            };

            rectangleTriple.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                foreach (Ingredient ing in scaledRecipe.ingredients)
                {
                    ing.quantity = ing.quantity * 3;
                    saveChanges();
                }
            };

            rectangleReset.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                foreach (Ingredient ing in scaledRecipe.ingredients)
                {
                    ing.quantity = ing.quantityOG;
                    saveChanges();
                }
            };

            gridHalf.Children.Add(rectangleHalf);
            gridHalf.Children.Add(recipeNameLabelHalf);
            stackPanelSteps.Children.Add(gridHalf);
            gridDouble.Children.Add(rectangleDouble);
            gridDouble.Children.Add(recipeNameLabelDouble);
            stackPanelSteps.Children.Add(gridDouble);
            gridTriple.Children.Add(rectangleTriple);
            gridTriple.Children.Add(recipeNameLabelTriple);
            stackPanelSteps.Children.Add(gridTriple);
            gridReset.Children.Add(rectangleReset);
            gridReset.Children.Add(recipeNameLabelReset);
            stackPanelSteps.Children.Add(gridReset);
            viewScaledList_StackPnl.Children.Add(stackPanelSteps);
        }
        public void saveChanges()
        {
            MainWindow.allRecipes[parser] = scaledRecipe;
            customShowMessage csm = new customShowMessage("Success!", "Your Recipe has been scaled by your selected value!\nPlease exit this window and go to\nthe View Recipe Tab to see your changes.");
            csm.Show();
        }
        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }
    }
}
