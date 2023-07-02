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
using Sauraav_POE;
using Sauraav_POE_Part_2;
using Sauraav_POE.MVM.ViewModel;
using System.Text.RegularExpressions;

namespace Sauraav_POE.Windows
{
    public partial class addIng_Step : Window
    {
        public static dynamic converter = new System.Windows.Media.BrushConverter();
        public static dynamic brush = (Brush)converter.ConvertFromString("#9A311C25");
        public static int amountOfIngredients = AddRecipeView.currentRecipe.amountOfIngredients;
        public static int stepsToRecipe = AddRecipeView.currentRecipe.stepsToRecipe;
        public addIng_Step()
        {
            InitializeComponent();
            populateUI(amountOfIngredients, stepsToRecipe);
        }

        public void addIngredients(int n)
        {
            StackPanel stackPanelIngredients = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center

            };

            Label ingredientLabel = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Ingredient No.{n}:",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Label ingredientLabelName = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter name:",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBox ingredientTextBoxName = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Name..."
            };

            Label ingredientLabelQty = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter quantity:",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBox ingredientTextBoxQty = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Quantity..."
            };

            Label ingredientLabelMeasurementUnit = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter Measurement Unit:",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            ComboBox ingredientComboBoxMeasurementUnit = new ComboBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernComboBox"],
                Tag = $"Unit...",
                Items = { "Grams", "Milligrams", "Kilograms", "Milliliters", "Liters", "Tablespoons", "Teaspoons", "Cups", "Pieces", "Slices" }
            };

            Label ingredientLabelFoodGroup = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Select food group:",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            ComboBox ingredientComboBoxFoodGroup = new ComboBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernComboBox"],
                Tag = $"Food group...",
                Items = { "Starchy foods", "Vegetables and fruits", "Dry beans, peas, lentils and soy", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oils", "Water" }
            };

            Label ingredientLabelCalories = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Enter calorie count:",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBox ingredientTextBoxCalories = new TextBox()
            {
                Name = $"ingredientTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Calorie count..."
            };

            stackPanelIngredients.Children.Add(ingredientLabel);
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
            rectangle.Fill = brush;
            rectangle.Height = 395;
            rectangle.Width = 222;
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.HorizontalAlignment = HorizontalAlignment.Center;
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
            Label stepCountLabel = new Label()
            {
                Name = $"stepCountLabel_{n}",
                Content = $"Step No.{n}:",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Label stepLabel = new Label()
            {
                Name = $"stepLabel_{n}",
                Content = $"Enter in Step No.{n}",
                Foreground = Brushes.White,
                Margin = new Thickness(40, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBox stepTextBox = new TextBox()
            {
                Name = $"stepTextBox_{n}",
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = (Style)Application.Current.Resources["ModernTextBox"],
                Tag = $"Enter in Step No.{n}...",

            };

            stackPanelSteps.Children.Add(stepCountLabel);
            stackPanelSteps.Children.Add(stepLabel);
            stackPanelSteps.Children.Add(stepTextBox);
            Grid grid = new Grid();
            grid.Margin = new Thickness(10);
            Rectangle rectangle = new Rectangle();
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#9A311C25");
            rectangle.Fill = brush;
            rectangle.Height = 130;
            rectangle.Width = 225;
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.HorizontalAlignment = HorizontalAlignment.Center;
            rectangle.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(rectangle);
            grid.Children.Add(stackPanelSteps);
            addIng_Step_Body_2.Children.Add(grid);
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

        public List<string> readTextBoxValuesDesc()
        {
            List<string> values = new List<string>();

            foreach (Grid grid in addIng_Step_Body_2.Children)
            {
                StackPanel stackPanelSteps = grid.Children.OfType<StackPanel>().FirstOrDefault();
                if (stackPanelSteps != null)
                {
                    TextBox stepTextBox = stackPanelSteps.Children.OfType<TextBox>().FirstOrDefault();
                    if (stepTextBox != null)
                    {
                        string value = stepTextBox.Text;
                        values.Add(value);
                    }
                }
            }

            return values;
        }

        public List<Ingredient> readTextBoxValuesIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            // Get the number of ingredients added
            int ingredientCount = addIng_Step_Body.Children.Count;

            for (int i = 0; i < ingredientCount; i++)
            {
                Grid grid = (Grid)addIng_Step_Body.Children[i];
                StackPanel stackPanelIngredients = (StackPanel)grid.Children[1];

                // Read the values from the TextBoxes and ComboBoxes
                string name = ((TextBox)stackPanelIngredients.Children[2]).Text;
                int quantity = 0;
                int.TryParse(((TextBox)stackPanelIngredients.Children[4]).Text, out quantity);
                string measurementUnit = ((ComboBox)stackPanelIngredients.Children[6]).SelectedItem.ToString();
                string foodGroup = ((ComboBox)stackPanelIngredients.Children[8]).SelectedItem.ToString();
                int calorieCount = 0;
                int.TryParse(((TextBox)stackPanelIngredients.Children[10]).Text, out calorieCount);

                // Create an Ingredient object and add it to the list
                Ingredient ingredient = new Ingredient(name, quantity, quantity, measurementUnit, foodGroup, calorieCount);
                ingredients.Add(ingredient);
            }

            return ingredients;
        }



        private void saveRecipeDetails_All(object sender, RoutedEventArgs e)
        {
            AddRecipeView.currentRecipe.descriptionOfSteps = readTextBoxValuesDesc();
            AddRecipeView.currentRecipe.ingredients = readTextBoxValuesIngredients();
            customShowMessage csm = new customShowMessage(this);
            csm.Show();

        }

        public void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
