//Sauraav Jayrajh
//ST10024620
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Sauraav_POE_Part_2;
using System.Text.RegularExpressions;
using System;
using System.Windows.Documents;

namespace Sauraav_POE
{
    public partial class DisplayViewRecipe : Window
    {
        ////Public variables for the class
        public static dynamic converter = new System.Windows.Media.BrushConverter();
        public static dynamic brush = (Brush)converter.ConvertFromString("#9A311C25");
        public RecipeComplete currentRecipe;
        public int ingredientCount = 0;
        public int stepCount = 0;

        ////method to start the window
        public DisplayViewRecipe(RecipeComplete passRecipe = null)
        {
            currentRecipe = passRecipe;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            addForm();
        }

        ////Method to load the UI
        private void addForm()
        {
            Grid mainGrid = new Grid();
            mainGrid.Margin = new Thickness(0);

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
            recipeNameTextBox.IsReadOnly = true;
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
            recipeAuthorNameTextBox.IsReadOnly = true;

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
            servingSizeTextBox.IsReadOnly = true;

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
            describeRecipeRichTextBox.IsReadOnly = true
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
            preparationTimeTextBox.IsReadOnly = true;
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
            ingredientQuantityTextBox.IsReadOnly = true;
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
            numberOfStepsTextBox.IsReadOnly = true;
            numberOfStepsTextBox.PreviewTextInput += onlyNumbers;

            Label calorieLabel = new Label();
            calorieLabel.Content = $"Total Calorie Count: {currentRecipe.returnTotalCalories(currentRecipe.ingredients)}";
            calorieLabel.Foreground = Brushes.White;


            stackPanel2.Children.Add(preparationTimeLabel);
            stackPanel2.Children.Add(preparationTimeTextBox);
            stackPanel2.Children.Add(ingredientQuantityLabel);
            stackPanel2.Children.Add(ingredientQuantityTextBox);
            stackPanel2.Children.Add(numberOfStepsLabel);
            stackPanel2.Children.Add(numberOfStepsTextBox);
            stackPanel2.Children.Add(calorieLabel);


            mainGrid.Children.Add(stackPanel);
            mainGrid.Children.Add(describeRecipeRichTextBox);
            mainGrid.Children.Add(stackPanel2);
            //Content = mainGrid;
            DisplayViewRecipes_Body.Children.Add(mainGrid);
            ingredientCount = currentRecipe.ingredients.Count;
            stepCount = currentRecipe.descriptionOfSteps.Count;
            populateUI(ingredientCount, stepCount);
        }

        ////Method to load the ingredients the recipe
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
                Text = currentRecipe.ingredients[n].name,
                IsReadOnly = true
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
                Text = "" + currentRecipe.ingredients[n].quantity,
                IsReadOnly = true
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
                IsReadOnly = true
            };
            ingredientComboBoxMeasurementUnit.Items.Add(currentRecipe.ingredients[n].measurementUnit);
            ingredientComboBoxMeasurementUnit.SelectedIndex = 0;
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
                IsReadOnly = true
            };
            ingredientComboBoxFoodGroup.Items.Add(currentRecipe.ingredients[n].foodGroup);
            ingredientComboBoxFoodGroup.SelectedIndex = 0;
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
                Text = "" + currentRecipe.ingredients[n].calories,
                IsReadOnly = true
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
            grid.Margin = new Thickness(0, 10, 0, 0);
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
            DisplayViewRecipes_Body_Left.Children.Add(grid);
        }

        ////Method to add steps to the recipe
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
                Text = currentRecipe.descriptionOfSteps[n],
                IsReadOnly = true

            };
            stackPanelSteps.Children.Add(stepCountLabel);
            stackPanelSteps.Children.Add(stepDescLabel);
            stackPanelSteps.Children.Add(stepTextBox);
            Grid grid = new Grid();
            grid.Margin = new Thickness(0, 10, 0, 0);
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
            DisplayViewRecipes_Body_Right.Children.Add(grid);
        }

        ////Method to populate the UI with the recipe details
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

        ////Method toensure only numbers are entered in the textbox
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

        ////Exit method
        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ////Method to keep the window on top
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }
    }
}