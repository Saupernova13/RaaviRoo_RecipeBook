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
        public RecipeComplete currentRecipe;
        public DisplayViewRecipe(RecipeComplete passRecipe = null)
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
            recipeNameTextBox.Tag = "Recipe Name...";

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
            recipeAuthorNameTextBox.Tag = "Author Name...";

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
            servingSizeTextBox.Tag = "Serving Size...";
            servingSizeTextBox.PreviewTextInput += onlyNumbers;

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


            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run("Describe the Dish..."));
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
            preparationTimeTextBox.Tag = "Enter Time in Minutes...";
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
            ingredientQuantityTextBox.Tag = "Number of Ingredients...";
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
            numberOfStepsTextBox.Tag = "Number of Steps...";
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
            DisplayViewRecipes_Body.Children.Add(mainGrid);
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

    }
}
