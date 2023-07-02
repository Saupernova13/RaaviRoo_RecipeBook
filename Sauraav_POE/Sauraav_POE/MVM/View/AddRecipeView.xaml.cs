using Sauraav_POE.MVM.ViewModel;
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
using static Sauraav_POE.MVM.ViewModel.MainViewModel;

namespace Sauraav_POE.MVM.View
{
   
    public partial class AddRecipeView : UserControl
    {
        public static RecipeComplete currentRecipe = new RecipeComplete();
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
            currentRecipe.recipeName = recipeNameTextBox.Text;
            currentRecipe.recipeDescription = new TextRange(describeRecipe.Document.ContentStart, describeRecipe.Document.ContentEnd).Text;
            currentRecipe.recipeAuthor = recipeAuthorNameTextBox.Text;
            try
            {
                currentRecipe.recipeServingSize = Int32.Parse(servingSizeTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ENTER in a valid NUMBER for the serving size:");
            }


            try
            {
                currentRecipe.recipeTotalTime = Convert.ToDouble(preparationTimeTextBox.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Please ENTER in a valid amount of TIME it takes to make the recipe below:");
            }


            try
            {
                currentRecipe.stepsToRecipe = Int32.Parse(numberOfStepsTextBox.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Please ENTER in HOW MANY steps this recipe will have below:");
            }

            try
            {
                currentRecipe.amountOfIngredients = Int32.Parse(ingredientQuantityTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ENTER in HOW MANY ingredients this recipe will have below:");
            }
            
            //display currentRecipe in showmessage
            MessageBox.Show("Recipe Name:\t\t" + currentRecipe.recipeName + "\nRecipe Description:\t\t" + currentRecipe.recipeDescription + "\nRecipe Author:\t\t" + currentRecipe.recipeAuthor + "\nRecipe Serving Size:\t\t" + currentRecipe.recipeServingSize + "\nRecipe Total Time:\t\t" + currentRecipe.recipeTotalTime + "\nSteps to Recipe:\t\t" + currentRecipe.stepsToRecipe + "\nAmount of Ingredients:\t\t" + currentRecipe.amountOfIngredients);
        
            addIng_Step newWindow = new addIng_Step();
            newWindow.Show();
        }
    }
}
