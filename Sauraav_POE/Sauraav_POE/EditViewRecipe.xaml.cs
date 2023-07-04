using Sauraav_POE.Windows;
using Sauraav_POE_Part_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for EditViewRecipe.xaml
    /// </summary>
    public partial class EditViewRecipe : Window
    {
        public static dynamic converter = new System.Windows.Media.BrushConverter();
        public static dynamic brush = (Brush)converter.ConvertFromString("#9A311C25");
        public RecipeComplete currentRecipe;
        public int ingredientCount = 0;
        public int stepCount = 0;
        private static bool isMessageBoxOpen = false;

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
        public EditViewRecipe(RecipeComplete passRecipe = null)
        {
            currentRecipe = passRecipe;
            InitializeComponent();
            addForm();
        }
        private void addForm()
        {
            Grid mainGrid = new Grid();
            mainGrid.Margin = new Thickness(10);

            ColumnDefinition column1 = new ColumnDefinition();
            column1.Width = new GridLength(300);
            ColumnDefinition column2 = new ColumnDefinition();
            column2.Width = GridLength.Auto;

            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto;
            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;

            mainGrid.ColumnDefinitions.Add(column1);
            mainGrid.ColumnDefinitions.Add(column2);
            mainGrid.RowDefinitions.Add(row1);
            mainGrid.RowDefinitions.Add(row2);

            StackPanel stackPanel = new StackPanel();
            Grid.SetColumn(stackPanel, 0);

            Label recipeNameLabel = new Label();
            recipeNameLabel.Content = "Recipe Name:";
            recipeNameLabel.Foreground = Brushes.White;

            TextBox recipeNameTextBox = new TextBox();
            recipeNameTextBox.Name = "recipeNameTextBox";
            recipeNameTextBox.Width = 200;
            recipeNameTextBox.Height = 40;
            recipeNameTextBox.VerticalAlignment = VerticalAlignment.Top;
            recipeNameTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            recipeNameTextBox.Style = (Style)FindResource("ModernTextBox");
            recipeNameTextBox.Text = currentRecipe.recipeName;
            ;

            Label authorNameLabel = new Label();
            authorNameLabel.Content = "Author Name:";
            authorNameLabel.Foreground = Brushes.White;

            TextBox recipeAuthorNameTextBox = new TextBox();
            recipeAuthorNameTextBox.Name = "recipeAuthorNameTextBox";
            recipeAuthorNameTextBox.Width = 200;
            recipeAuthorNameTextBox.Height = 40;
            recipeAuthorNameTextBox.VerticalAlignment = VerticalAlignment.Top;
            recipeAuthorNameTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            recipeAuthorNameTextBox.Style = (Style)FindResource("ModernTextBox");
            recipeAuthorNameTextBox.Text = currentRecipe.recipeAuthor;

            Label servingSizeLabel = new Label();
            servingSizeLabel.Content = "Serving Size:";
            servingSizeLabel.Foreground = Brushes.White;

            TextBox servingSizeTextBox = new TextBox();
            servingSizeTextBox.Name = "servingSizeTextBox";
            servingSizeTextBox.Width = 200;
            servingSizeTextBox.Height = 40;
            servingSizeTextBox.VerticalAlignment = VerticalAlignment.Top;
            servingSizeTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            servingSizeTextBox.Style = (Style)FindResource("ModernTextBox");
            servingSizeTextBox.PreviewTextInput += onlyNumbers;
            servingSizeTextBox.Text = "" + currentRecipe.recipeServingSize;

            Label recipeDescriptionLabel = new Label();
            recipeDescriptionLabel.Content = "Recipe Description:";
            recipeDescriptionLabel.Foreground = Brushes.White;

            stackPanel.Children.Add(recipeNameLabel);
            stackPanel.Children.Add(recipeNameTextBox);
            stackPanel.Children.Add(authorNameLabel);
            stackPanel.Children.Add(recipeAuthorNameTextBox);
            stackPanel.Children.Add(servingSizeLabel);
            stackPanel.Children.Add(servingSizeTextBox);
            stackPanel.Children.Add(recipeDescriptionLabel);

            RichTextBox describeRecipeRichTextBox = new RichTextBox();
            describeRecipeRichTextBox.Style = (Style)FindResource("ModernRichTextBox");
            describeRecipeRichTextBox.VerticalAlignment = VerticalAlignment.Top;
            describeRecipeRichTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            describeRecipeRichTextBox.Name = "describeRecipe";
            describeRecipeRichTextBox.BorderThickness = new Thickness(0);
            describeRecipeRichTextBox.Height = 200;
            describeRecipeRichTextBox.Width = 500;
            describeRecipeRichTextBox.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            describeRecipeRichTextBox.PreviewMouseLeftButtonDown += describeRecipe_PreviewMouseLeftButtonDown;
            describeRecipeRichTextBox.Margin = new Thickness(0, 5, 0, 0);
            Grid.SetRow(describeRecipeRichTextBox, 1);
            Grid.SetColumnSpan(describeRecipeRichTextBox, 2);
            ;


            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run(currentRecipe.recipeDescription));
            flowDocument.Blocks.Add(paragraph);
            describeRecipeRichTextBox.Document = flowDocument;

            StackPanel stackPanel2 = new StackPanel();
            Grid.SetColumn(stackPanel2, 1);

            Label preparationTimeLabel = new Label();
            preparationTimeLabel.Content = "Preparation Time:";
            preparationTimeLabel.Foreground = Brushes.White;

            TextBox preparationTimeTextBox = new TextBox();
            preparationTimeTextBox.Name = "preparationTimeTextBox";
            preparationTimeTextBox.Width = 200;
            preparationTimeTextBox.Height = 40;
            preparationTimeTextBox.VerticalAlignment = VerticalAlignment.Top;
            preparationTimeTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            preparationTimeTextBox.Style = (Style)FindResource("ModernTextBox");
            preparationTimeTextBox.Text = "" + currentRecipe.recipeTotalTime;
            preparationTimeTextBox.PreviewTextInput += onlyNumbers;

            Label ingredientQuantityLabel = new Label();
            ingredientQuantityLabel.Content = "Number of Ingredients:";
            ingredientQuantityLabel.Foreground = Brushes.White;

            TextBox ingredientQuantityTextBox = new TextBox();
            ingredientQuantityTextBox.Name = "ingredientQuantityTextBox";
            ingredientQuantityTextBox.Width = 200;
            ingredientQuantityTextBox.Height = 40;
            ingredientQuantityTextBox.VerticalAlignment = VerticalAlignment.Top;
            ingredientQuantityTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            ingredientQuantityTextBox.Style = (Style)FindResource("ModernTextBox");
            ingredientQuantityTextBox.Text = "" + currentRecipe.amountOfIngredients;
            ingredientQuantityTextBox.PreviewTextInput += onlyNumbers;

            Label numberOfStepsLabel = new Label();
            numberOfStepsLabel.Content = "Number of Steps:";
            numberOfStepsLabel.Foreground = Brushes.White;

            TextBox numberOfStepsTextBox = new TextBox();
            numberOfStepsTextBox.Name = "numberOfStepsTextBox";
            numberOfStepsTextBox.Width = 200;
            numberOfStepsTextBox.Height = 40;
            numberOfStepsTextBox.VerticalAlignment = VerticalAlignment.Top;
            numberOfStepsTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            numberOfStepsTextBox.Style = (Style)FindResource("ModernTextBox");
            numberOfStepsTextBox.Text = "" + currentRecipe.stepsToRecipe;
            numberOfStepsTextBox.PreviewTextInput += onlyNumbers;

            stackPanel2.Children.Add(preparationTimeLabel);
            stackPanel2.Children.Add(preparationTimeTextBox);
            stackPanel2.Children.Add(ingredientQuantityLabel);
            stackPanel2.Children.Add(ingredientQuantityTextBox);
            stackPanel2.Children.Add(numberOfStepsLabel);
            stackPanel2.Children.Add(numberOfStepsTextBox);


            mainGrid.Children.Add(stackPanel);
            mainGrid.Children.Add(describeRecipeRichTextBox);
            mainGrid.Children.Add(stackPanel2);
            //Content = mainGrid;
            DisplayEditRecipes_Body.Children.Add(mainGrid);
            ingredientCount = currentRecipe.ingredients.Count;
            stepCount = currentRecipe.descriptionOfSteps.Count;
            populateUI(ingredientCount, stepCount);
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
                Content = $"Ingredient No.{n + 1}:",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Label ingredientLabelName = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Name:",
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
                Text = currentRecipe.ingredients[n].name
            };
            Label ingredientLabelQty = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Quantity:",
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
                Text = "" + currentRecipe.ingredients[n].quantity
            };
            Label ingredientLabelMeasurementUnit = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Measurement Unit:",
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
                Items = { "Grams", "Milligrams", "Kilograms", "Milliliters", "Liters", "Tablespoons", "Teaspoons", "Cups", "Pieces", "Slices" },
                IsReadOnly = true
            };

            switch (currentRecipe.ingredients[n].measurementUnit)
            {

                case "Grams":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 0;
                    break;
                case "Milligrams":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 1;
                    break;
                case "Kilograms":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 2;
                    break;
                case "Milliliters":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 3;
                    break;
                case "Liters":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 4;
                    break;
                case "Tablespoons":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 5;
                    break;
                case "Teaspoons":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 6;
                    break;
                case "Cups":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 7;
                    break;
                case "Pieces":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 8;
                    break;
                case "Slices":
                    ingredientComboBoxMeasurementUnit.SelectedIndex = 9;
                    break;
                default:
                    break;
            }
            Label ingredientLabelFoodGroup = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Food group:",
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
                Items = { "Starchy foods", "Vegetables and fruits", "Dry beans, peas, lentils and soy", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oils", "Water" },
                IsReadOnly = true
            };
            switch (currentRecipe.ingredients[n].foodGroup)
            {
                case "Starchy foods":
                    ingredientComboBoxFoodGroup.SelectedIndex = 0;
                    break;
                case "Vegetables and fruits":
                    ingredientComboBoxFoodGroup.SelectedIndex = 1;
                    break;
                case "Dry beans, peas, lentils and soy":
                    ingredientComboBoxFoodGroup.SelectedIndex = 2;
                    break;
                case "Chicken, fish, meat and eggs":
                    ingredientComboBoxFoodGroup.SelectedIndex = 3;
                    break;
                case "Milk and dairy products":
                    ingredientComboBoxFoodGroup.SelectedIndex = 4;
                    break;
                case "Fats and oils":
                    ingredientComboBoxFoodGroup.SelectedIndex = 5;
                    break;
                case "Water":
                    ingredientComboBoxFoodGroup.SelectedIndex = 6;
                    break;
                default:
                    break;
            }
            Label ingredientLabelCalories = new Label()
            {
                Name = $"ingredientLabel_{n}",
                Content = $"Calorie count:",
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
                Text = "" + currentRecipe.ingredients[n].calories
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
            rectangle.HorizontalAlignment = HorizontalAlignment.Left;
            rectangle.VerticalAlignment = VerticalAlignment.Center;
            stackPanelIngredients.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanelIngredients.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(rectangle);
            grid.Children.Add(stackPanelIngredients);
            DisplayEditRecipes_Body_Left.Children.Add(grid);
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
                Content = $"Step No.{n + 1}:",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Label stepDescLabel = new Label()
            {
                Name = $"stepCountLabel_{n}",
                Content = $"Description:",
                Foreground = Brushes.White,
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
                Text = currentRecipe.descriptionOfSteps[n]

            };
            stackPanelSteps.Children.Add(stepCountLabel);
            stackPanelSteps.Children.Add(stepDescLabel);
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
            rectangle.HorizontalAlignment = HorizontalAlignment.Left;
            rectangle.VerticalAlignment = VerticalAlignment.Center;
            stackPanelSteps.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanelSteps.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(rectangle);
            grid.Children.Add(stackPanelSteps);
            DisplayEditRecipes_Body_Right.Children.Add(grid);
        }

        public void populateUI(int ingredientNo, int stepNo)
        {
            for (int i = 0; i < ingredientNo; i++)
            {
                addIngredients(i);
            }
            for (int i = 0; i < stepNo; i++)
            {
                addSteps(i);
            }
        }
        private void describeRecipe_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }
        private void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            // Only allow numbers
            foreach (char c in e.Text)
            {
                if (!Char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            //saveRecipeDetails(5);
        }
        /*
        private void saveRecipeDetails(int index)
        {
            int badFields = 0;
            if (!((recipeNameTextBox.Text.Equals("")) || (recipeNameTextBox.Text.Equals(null))))
            {
                currentRecipe.recipeName = recipeNameTextBox.Text;
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in the NAME for the\nrecipe!");
                badFields++;
            }
            string desc = new TextRange(describeRecipe.Document.ContentStart, describeRecipe.Document.ContentEnd).Text;

            if (!((desc.Equals("")) || (desc.Equals(null))))
            {
                currentRecipe.recipeDescription = desc;
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in a DESCRIPTION for the\nrecipe!");
                badFields++;
            }

            if (!((recipeAuthorNameTextBox.Text.Equals("")) || (recipeAuthorNameTextBox.Text.Equals(null))))
            {
                currentRecipe.recipeAuthor = recipeAuthorNameTextBox.Text;
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in the AUTHOR NAME for the\nrecipe!");
                badFields++;
            }
            if (nullOrNumber(servingSizeTextBox.Text))
            {
                currentRecipe.recipeServingSize = Int32.Parse(servingSizeTextBox.Text);
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in a valid NUMBER for the\nserving size!");
                badFields++;
            }

            if (nullOrNumber(preparationTimeTextBox.Text))
            {
                currentRecipe.recipeTotalTime = Convert.ToDouble(preparationTimeTextBox.Text);
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in a valid amount of TIME\nto make the recipe!");
                badFields++;
            }

            if (nullOrNumber(numberOfStepsTextBox.Text))
            {
                currentRecipe.stepsToRecipe = Int32.Parse(numberOfStepsTextBox.Text);
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in HOW MANY steps this\nrecipe will have!");
                badFields++;
            }

            if (nullOrNumber(ingredientQuantityTextBox.Text))
            {
                currentRecipe.amountOfIngredients = Int32.Parse(ingredientQuantityTextBox.Text);
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in HOW MANY ingredients\nthis recipe will have!");
                badFields++;
            }
            if (badFields > 0)
            {
                showMessageCustom("Error", "Please COMPLETE the form PROPERLY!");
            }
            else
            {
                addIng_Step newWindow = new addIng_Step(currentRecipe);
                newWindow.Show();
            }
        }
        */
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

        private void saveChanges(object sender, RoutedEventArgs e)
        {

        }
    }
}
