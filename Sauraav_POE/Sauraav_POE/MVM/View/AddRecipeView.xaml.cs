using Sauraav_POE.MVM.ViewModel;
using Sauraav_POE.Windows;
using Sauraav_POE_Part_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
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
using static Sauraav_POE.MVM.ViewModel.MainViewModel;

namespace Sauraav_POE.MVM.View
{

    public partial class AddRecipeView : UserControl
    {
        public static RecipeComplete currentRecipe = new RecipeComplete();
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
        public AddRecipeView()
        {
            InitializeComponent();
        }

        private void describeRecipe_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            describeRecipe.Document.Blocks.Clear();
            describeRecipe.Foreground = Brushes.White;
        }

        public void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void saveRecipeDetails(object sender, RoutedEventArgs e)
        {
            int badFields = 0;
            if (nullOrNumber(recipeNameTextBox.Text))
            {
                currentRecipe.recipeName = recipeNameTextBox.Text;
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in the NAME for the\nrecipe!");
                badFields++;
            }
            if (nullOrNumber(new TextRange(describeRecipe.Document.ContentStart, describeRecipe.Document.ContentEnd).Text))
            {
                currentRecipe.recipeDescription = new TextRange(describeRecipe.Document.ContentStart, describeRecipe.Document.ContentEnd).Text;
            }
            else
            {
                showMessageCustom("Error", "Please ENTER in a DESCRIPTION for the\nrecipe!");
                badFields++;
            }

            if (nullOrNumber(recipeAuthorNameTextBox.Text))
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
                addIng_Step newWindow = new addIng_Step();
                newWindow.Show();
            }
            clearForm();
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
                showMessageCustom("Error", "Please ENTER in a valid NUMBER for the serving size!");
                result = false;
            }
            return (result);
        }

        private void clearForm() {
            recipeNameTextBox.Clear();
            recipeAuthorNameTextBox.Clear();
            servingSizeTextBox.Clear();
            preparationTimeTextBox.Clear();
            numberOfStepsTextBox.Clear();
            ingredientQuantityTextBox.Clear();
        }
    }
}
