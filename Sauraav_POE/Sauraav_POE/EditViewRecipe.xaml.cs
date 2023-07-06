//Sauraav Jayrajh
//ST10024620
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
    public partial class EditViewRecipe : Window
    {
        public static dynamic converter = new System.Windows.Media.BrushConverter();
        public static dynamic brush = (Brush)converter.ConvertFromString("#9A311C25");
        public RecipeComplete currentRecipe = new RecipeComplete();
        public RecipeComplete importedRecipe;
        public RecipeComplete toEditRecipe;
        public List<RecipeComplete> duplicateRecipeList = new List<RecipeComplete>();
        public int ingredientCount = 0;
        public int stepCount = 0;
        public double calories = 0;
        private static bool isMessageBoxOpen = false;
        private TextBox recipeNameTextBox = new TextBox();
        private TextBox recipeAuthorNameTextBox = new TextBox();
        private TextBox servingSizeTextBox = new TextBox();
        private RichTextBox describeRecipeRichTextBox = new RichTextBox();
        private TextBox preparationTimeTextBox = new TextBox();
        private TextBox ingredientQuantityTextBox = new TextBox();
        private TextBox numberOfStepsTextBox = new TextBox();
        public int parser = 0;
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
        public EditViewRecipe(RecipeComplete passRecipe = null, dynamic index = null)
        {
            importedRecipe = passRecipe;
            InitializeComponent();
            DisplayEditRecipes_Body.Children.Clear();
            DisplayEditRecipes_Body_Left.Children.Clear();
            DisplayEditRecipes_Body_Right.Children.Clear();
            duplicateRecipeList = MainWindow.allRecipes;
            toEditRecipe = duplicateRecipeList[index];
            addHeader();
            parser = index;
            populateUI(importedRecipe.amountOfIngredients, importedRecipe.stepsToRecipe);
        }
        private void addHeader()
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
            recipeNameTextBox.Name = "recipeNameTextBox";
            recipeNameTextBox.Width = 200;
            recipeNameTextBox.Height = 40;
            recipeNameTextBox.VerticalAlignment = VerticalAlignment.Top;
            recipeNameTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            recipeNameTextBox.Style = (Style)FindResource("ModernTextBox");
            recipeNameTextBox.Text = importedRecipe.recipeName;
            Label authorNameLabel = new Label();
            authorNameLabel.Content = "Author Name:";
            authorNameLabel.Foreground = Brushes.White;
            recipeAuthorNameTextBox.Name = "recipeAuthorNameTextBox";
            recipeAuthorNameTextBox.Width = 200;
            recipeAuthorNameTextBox.Height = 40;
            recipeAuthorNameTextBox.VerticalAlignment = VerticalAlignment.Top;
            recipeAuthorNameTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            recipeAuthorNameTextBox.Style = (Style)FindResource("ModernTextBox");
            recipeAuthorNameTextBox.Text = importedRecipe.recipeAuthor;
            Label servingSizeLabel = new Label();
            servingSizeLabel.Content = "Serving Size:";
            servingSizeLabel.Foreground = Brushes.White;
            servingSizeTextBox.Name = "servingSizeTextBox";
            servingSizeTextBox.Width = 200;
            servingSizeTextBox.Height = 40;
            servingSizeTextBox.VerticalAlignment = VerticalAlignment.Top;
            servingSizeTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            servingSizeTextBox.Style = (Style)FindResource("ModernTextBox");
            servingSizeTextBox.PreviewTextInput += onlyNumbers;
            servingSizeTextBox.Text = "" + importedRecipe.recipeServingSize;
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
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run(importedRecipe.recipeDescription));
            flowDocument.Blocks.Add(paragraph);
            describeRecipeRichTextBox.Document = flowDocument;
            StackPanel stackPanel2 = new StackPanel();
            Grid.SetColumn(stackPanel2, 1);
            Label preparationTimeLabel = new Label();
            preparationTimeLabel.Content = "Preparation Time:";
            preparationTimeLabel.Foreground = Brushes.White;
            preparationTimeTextBox.Name = "preparationTimeTextBox";
            preparationTimeTextBox.Width = 200;
            preparationTimeTextBox.Height = 40;
            preparationTimeTextBox.VerticalAlignment = VerticalAlignment.Top;
            preparationTimeTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            preparationTimeTextBox.Style = (Style)FindResource("ModernTextBox");
            preparationTimeTextBox.Text = "" + importedRecipe.recipeTotalTime;
            preparationTimeTextBox.PreviewTextInput += onlyNumbers;
            Label ingredientQuantityLabel = new Label();
            ingredientQuantityLabel.Content = "Number of Ingredients:";
            ingredientQuantityLabel.Foreground = Brushes.White;
            ingredientQuantityTextBox.Name = "ingredientQuantityTextBox";
            ingredientQuantityTextBox.Width = 200;
            ingredientQuantityTextBox.Height = 40;
            ingredientQuantityTextBox.VerticalAlignment = VerticalAlignment.Top;
            ingredientQuantityTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            ingredientQuantityTextBox.Style = (Style)FindResource("ModernTextBox");
            ingredientQuantityTextBox.Text = "" + importedRecipe.amountOfIngredients;
            ingredientQuantityTextBox.PreviewTextInput += onlyNumbers;
            ingredientQuantityTextBox.IsReadOnly = true;
            Label numberOfStepsLabel = new Label();
            numberOfStepsLabel.Content = "Number of Steps:";
            numberOfStepsLabel.Foreground = Brushes.White;
            numberOfStepsTextBox.Name = "numberOfStepsTextBox";
            numberOfStepsTextBox.Width = 200;
            numberOfStepsTextBox.Height = 40;
            numberOfStepsTextBox.VerticalAlignment = VerticalAlignment.Top;
            numberOfStepsTextBox.HorizontalAlignment = HorizontalAlignment.Left;
            numberOfStepsTextBox.Style = (Style)FindResource("ModernTextBox");
            numberOfStepsTextBox.Text = "" + importedRecipe.stepsToRecipe;
            numberOfStepsTextBox.PreviewTextInput += onlyNumbers;
            numberOfStepsTextBox.IsReadOnly = true;
            stackPanel2.Children.Add(preparationTimeLabel);
            stackPanel2.Children.Add(preparationTimeTextBox);
            stackPanel2.Children.Add(ingredientQuantityLabel);
            stackPanel2.Children.Add(ingredientQuantityTextBox);
            stackPanel2.Children.Add(numberOfStepsLabel);
            stackPanel2.Children.Add(numberOfStepsTextBox);
            mainGrid.Children.Add(stackPanel);
            mainGrid.Children.Add(describeRecipeRichTextBox);
            mainGrid.Children.Add(stackPanel2);
            DisplayEditRecipes_Body.Children.Add(mainGrid);
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
                Text = importedRecipe.ingredients[n].name
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
                Text = "" + importedRecipe.ingredients[n].quantity
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
            switch (importedRecipe.ingredients[n].measurementUnit)
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
            switch (importedRecipe.ingredients[n].foodGroup)
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
                Text = "" + importedRecipe.ingredients[n].calories
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
                Text = importedRecipe.descriptionOfSteps[n]
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
            saveRecipeDetails();
        }
        private void saveRecipeDetails()
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
            string desc = new TextRange(describeRecipeRichTextBox.Document.ContentStart, describeRecipeRichTextBox.Document.ContentEnd).Text;

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
                saveRecipeDetails_All();

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
            int ingredientCount = DisplayEditRecipes_Body_Left.Children.Count;
            for (int i = 0; i < ingredientCount; i++)
            {
                Grid grid = (Grid)DisplayEditRecipes_Body_Left.Children[i];
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
            foreach (Grid grid in DisplayEditRecipes_Body_Right.Children)
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
        private void saveRecipeDetails_All()
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
            toEditRecipe = currentRecipe;
            duplicateRecipeList[parser] = toEditRecipe;
            mainClass.allRecipes = duplicateRecipeList;
            int dupIngNum = duplicateRecipeList[parser].ingredients.Count;
            int mainIngNum = mainClass.allRecipes[parser].ingredients.Count;
            if (dupIngNum > mainIngNum)
            {
                int diff = dupIngNum - mainIngNum;
                Ingredient emptyIng = new Ingredient("", 0, 0, "", "", 0);
                for (int i = 0; i < diff; i++)
                {
                    mainClass.allRecipes[parser].ingredients.Add(emptyIng);
                }
            }
            if (success == 2)
            {
                if (calories > 300)
                {
                    customShowMessage csmCalorie = new customShowMessage("Warning!", "This recipe contains over 300 calories!");
                    csmCalorie.Show();
                }
                customShowMessage csm = new customShowMessage("Details Captured!", "The details you entered have been\nsuccessfully Updated!");
                csm.Show();
                this.Close();
            }
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
    }
}
