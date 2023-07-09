//Sauraav Jayrajh
//ST10024620
using Sauraav_POE.MVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Sauraav_POE_Part_2;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Security.Cryptography;
using OpenAI_API;
using OpenAI_API.Completions;

namespace Sauraav_POE.Windows
{
    public partial class addIng_Step : Window
    {
        private static bool isMessageBoxOpen = false;
        public double calories = 0;
        public RecipeComplete currentRecipe = new RecipeComplete();
        public static void showMessageCustom(string windowName, string windowText)
        {
            if (!isMessageBoxOpen)
            {
                customShowMessage showMessage = new customShowMessage(windowName, windowText);
                showMessage.Show();
                isMessageBoxOpen = true;
                showMessage.Closed += (sender, args) => isMessageBoxOpen = false;
            }
        }
        public static dynamic converter = new System.Windows.Media.BrushConverter();
        public static dynamic brush = (Brush)converter.ConvertFromString("#9A311C25");
        public static int amountOfIngredients;
        public static int stepsToRecipe;
        public addIng_Step(RecipeComplete inputRecipe)
        {
            currentRecipe = inputRecipe;
            amountOfIngredients = currentRecipe.amountOfIngredients;
            stepsToRecipe = currentRecipe.stepsToRecipe;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
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
                Width = 150,
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
                Width = 150,
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
                Width = 150,
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
                Width = 150,
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
                Width = 150,
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
            grid.Margin = new Thickness(5);
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = brush;
            rectangle.Height = 395;
            rectangle.Width = 207;
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
            grid.Margin = new Thickness(5);
            Rectangle rectangle = new Rectangle();
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#9A311C25");
            rectangle.Fill = brush;
            rectangle.Height = 130;
            rectangle.Width = 210;
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
        public List<Ingredient> readTextBoxValuesIngredients()
        {
            int badFields = 0;
            string name = "";
            int quantity = 0;
            string measurementUnit = "";
            string foodGroup = "";
            int calorieCount = 0;
            List<Ingredient> ingredients = new List<Ingredient>();
            int ingredientCount = addIng_Step_Body.Children.Count;
            for (int i = 0; i < ingredientCount; i++)
            {
                Grid grid = (Grid)addIng_Step_Body.Children[i];
                StackPanel stackPanelIngredients = (StackPanel)grid.Children[1];
                TextBox nameTextBox = (TextBox)stackPanelIngredients.Children[2];
                TextBox quantityTextBox = (TextBox)stackPanelIngredients.Children[4];
                ComboBox measurementUnitComboBox = (ComboBox)stackPanelIngredients.Children[6];
                ComboBox foodGroupComboBox = (ComboBox)stackPanelIngredients.Children[8];
                TextBox calorieCountTextBox = (TextBox)stackPanelIngredients.Children[10];
                if (!((nameTextBox.Text.Equals("")) || (nameTextBox.Text.Equals(null))))
                {
                    name = nameTextBox.Text;
                }
                else
                {
                    showMessageCustom("Error", $"Please ENTER in a NAME for\nIngredient{i + 1}!");
                    badFields++;
                }
                if (nullOrNumber(quantityTextBox.Text))
                {
                    quantity = int.Parse(quantityTextBox.Text);
                }
                else
                {
                    showMessageCustom("Error", $"Please ENTER in the quantity of\nIngredient{i + 1}!");
                    badFields++;
                }
                if (!((measurementUnitComboBox.SelectedItem == null) || (measurementUnitComboBox.SelectedIndex == -1)))
                {
                    measurementUnit = measurementUnitComboBox.SelectedItem.ToString();
                }
                else
                {
                    showMessageCustom("Error", $"Please SELECT a MEASUREMENT UNIT for\nIngredient{i + 1}!");
                    badFields++;
                }
                if (!((foodGroupComboBox.SelectedItem == null) || (foodGroupComboBox.SelectedIndex == -1)))
                {
                    foodGroup = foodGroupComboBox.SelectedItem.ToString();
                }
                else
                {
                    showMessageCustom("Error", $"Please SELECT a FOOD GROUP for\nIngredient{i + 1}!");
                    badFields++;
                }
                if (nullOrNumber(calorieCountTextBox.Text))
                {
                    calorieCount = int.Parse(calorieCountTextBox.Text);
                    calories = calories + calorieCount;
                    currentRecipe.totalCalories = calories;
                }
                else
                {
                    showMessageCustom("Error", $"Please ENTER in the amount of CALORIES\nin Ingredient{i + 1}!");
                    badFields++;
                }
                if (badFields > 0)
                {
                    showMessageCustom("Error", "Please COMPLETE the form PROPERLY!");
                    return null;
                }
                else
                {
                    Ingredient ingredient = new Ingredient(name, quantity, quantity, measurementUnit, foodGroup, calorieCount);
                    ingredients.Add(ingredient);
                }

            }
            return ingredients;
        }
        public List<string> readTextBoxValuesDesc()
        {
            int counter = 0;
            List<string> values = new List<string>();
            foreach (Grid grid in addIng_Step_Body_2.Children)
            {
                StackPanel stackPanelSteps = grid.Children.OfType<StackPanel>().FirstOrDefault();
                if (stackPanelSteps != null)
                {
                    counter++;
                    TextBox stepTextBox = stackPanelSteps.Children.OfType<TextBox>().FirstOrDefault();
                    if (!((stepTextBox.Text.Equals("")) || (stepTextBox.Text.Equals(null))))
                    {
                        string value = stepTextBox.Text;
                        values.Add(value);
                    }
                    else
                    {
                        showMessageCustom("Error", $"Please Describe Step{counter}!");
                        return null;
                    }
                }
            }
            return values;
        }

        private void saveRecipeDetails_All(object sender, RoutedEventArgs e)
        {
            int success = 0;
            List<string> steps = readTextBoxValuesDesc();
            if (steps == null)
            {
                return;
            }
            else
            {
                currentRecipe.descriptionOfSteps = steps;
                success++;
            }
            List<Ingredient> ingredients = readTextBoxValuesIngredients();
            if (ingredients == null)
            {
                return;
            }
            else
            {
                currentRecipe.ingredients = ingredients;
                success++;
            }
            MainWindow.allRecipes.Add(currentRecipe);
            if (success == 2)
            {

                if (calories > 300)
                {
                    customShowMessage csmCalorie = new customShowMessage("Warning!", "This recipe contains over 300 calories!");
                    csmCalorie.Show();
                }
                customShowMessage csm = new customShowMessage("Details Captured!", "The details you entered have been\nsuccessfully captured!", this);
                csm.Show();
            }


        }

        public void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static bool nullOrNumber(string input)
        {
            bool result = false;

            if ((input == null || input == "") || !(isDigit(input)))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return (result);
        }

        public static bool isDigit(string input)
        {
            bool result = false;
            if (input.All(char.IsDigit))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return (result);
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
