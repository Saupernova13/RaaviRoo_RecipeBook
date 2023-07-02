using Sauraav_POE.MVM.View;
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

namespace Sauraav_POE.Windows
{
    /// <summary>
    /// Interaction logic for addIng_Step.xaml
    /// </summary>
    public partial class addIng_Step : Window
    {
        public addIng_Step()
        {
            InitializeComponent();
            populateUI(AddRecipeView.currentRecipe.amountOfIngredients, AddRecipeView.currentRecipe.stepsToRecipe);
        }

        public void addIngredients(int n)
        {
            StackPanel stackPanelIngredients = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10)

            };


            Label ingredientLabelName = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter name for Ingredient No.{n}:",
                Foreground = Brushes.White
            };

            TextBox ingredientTextBoxName = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Name for Ingredient No.{n}..."
            };

            Label ingredientLabelQty = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter quantity for Ingredient No.{n}:",
                Foreground = Brushes.White
            };

            TextBox ingredientTextBoxQty = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Quantity for Ingredient No.{n}..."
            };

            Label ingredientLabelMeasurementUnit = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter Unit for Ingredient No.{n}:",
                Foreground = Brushes.White
            };

            ComboBox ingredientComboBoxMeasurementUnit = new ComboBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernComboBox"],
                Tag = $"Unit for Ingredient No.{n}...",
                Items = { "Grams", "Milligrams", "Kilograms", "Milliliters", "Liters", "Tablespoons", "Teaspoons", "Cups", "Pieces", "Slices" }
            };

            Label ingredientLabelFoodGroup = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Select food group for Ingredient No.{n}:",
                Foreground = Brushes.White
            };

            ComboBox ingredientComboBoxFoodGroup = new ComboBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernComboBox"],
                Tag = $"Food group for Ingredient No.{n}...",
                Items = { "Starchy foods", "Vegetables and fruits", "Dry beans, peas, lentils and soy", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oils", "Water" }
            };

            Label ingredientLabelCalories = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter calorie count for Ingredient No.{n}:",
                Foreground = Brushes.White
            };

            TextBox ingredientTextBoxCalories = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Calorie count for Ingredient No.{n}..."
            };


            stackPanelIngredients.Children.Add(ingredientLabelName);
            stackPanelIngredients.Children.Add(ingredientTextBoxName);
            stackPanelIngredients.Children.Add(ingredientLabelQty);
            stackPanelIngredients.Children.Add(ingredientTextBoxQty);
            stackPanelIngredients.Children.Add(ingredientLabelMeasurementUnit);
            stackPanelIngredients.Children.Add(ingredientComboBoxMeasurementUnit);
            stackPanelIngredients.Children.Add(ingredientLabelFoodGroup);
            stackPanelIngredients.Children.Add(ingredientComboBoxFoodGroup);
            stackPanelIngredients.Children.Add(ingredientLabelCalories);
            stackPanelIngredients.Children.Add(ingredientTextBoxCalories);
            Grid grid = new Grid();
            grid.Margin = new Thickness(10);
            Rectangle rectangle = new Rectangle();
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#9A311C25");
            rectangle.Fill = brush;
            rectangle.Height = 370;
            rectangle.Width = 225;
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.HorizontalAlignment = HorizontalAlignment.Left;
            rectangle.VerticalAlignment = VerticalAlignment.Center;

            grid.Children.Add(rectangle);
            grid.Children.Add(stackPanelIngredients);
            addIng_Step_Body.Children.Add(grid);
        }

        public void addSteps(int n)
        {
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10)

            };

            Label stepLabel = new Label()
            {
                Name = $"stepLabel_{n}",
                Content = $"Enter in Step No.{n}",
                Foreground = Brushes.White
            };

            TextBox stepTextBox = new TextBox()
            {
                Name = $"stepTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Enter in Step No.{n}..."
            };

            stackPanelSteps.Children.Add(stepLabel);
            stackPanelSteps.Children.Add(stepTextBox);
            addIng_Step_Body_2.Children.Add(stackPanelSteps);
        }

        public void populateUI(int ingredientNo, int stepNo)
        {
            for (int i = 0; i < ingredientNo; i++)
            {
                addIngredients(i + 1);
            }
            for (int i = 0; i < stepNo; i++)
            {
                addSteps(i + 1);
            }

        }

        private void saveRecipeDetails_All(object sender, RoutedEventArgs e)
        {

        }
    }

}
