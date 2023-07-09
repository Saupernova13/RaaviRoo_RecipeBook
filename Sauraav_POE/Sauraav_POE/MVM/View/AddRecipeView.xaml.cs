//Sauraav Jayrajh
//ST10024620
using Sauraav_POE.MVM.ViewModel;
using Sauraav_POE.Windows;
using Sauraav_POE_Part_2;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Net.NetworkInformation;

namespace Sauraav_POE.MVM.View
{

    public partial class AddRecipeView : UserControl
    {
        public  RecipeComplete currentRecipe = new RecipeComplete();
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
            clearForm();

            var mainWindow = Window.GetWindow(this) as MainWindow;
            var mainViewModel = mainWindow.DataContext as MainViewModel;
            mainViewModel.CurrentView = mainViewModel.HomeViewNewVM;
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

        private void clearForm()
        {
            recipeNameTextBox.Clear();
            recipeAuthorNameTextBox.Clear();
            servingSizeTextBox.Clear();
            preparationTimeTextBox.Clear();
            numberOfStepsTextBox.Clear();
            ingredientQuantityTextBox.Clear();
            describeRecipe.Document.Blocks.Clear();
        }

        private async void savePromptGPT(object sender, RoutedEventArgs e)
        {
            if (IsConnectedToInternet())
            {

                string RecipeName = "";
                string RecipeAuthorName = "";
                string RecipeServingSize = "";
                string RecipePreparationTime = "";
                string RecipeNumberOfSteps = "";
                string RecipeIngredientQuantity = "";
                string RecipeDescription = "";

                var OpenAPI = new OpenAIAPI("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");
                CompletionRequest completionRequest = new CompletionRequest();

                //Generate Recipe Name
                completionRequest.Prompt = "Please give me a recipe name without quotation marks";
                completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
                var completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);
                foreach (var completion in completions.Completions)
                {
                    RecipeName = completion.Text.TrimStart('\n');
                }
                recipeNameTextBox.Text = RecipeName;

                //Generate Recipe Description
                completionRequest.Prompt = $"Please generate ONLY a paragraph describing {RecipeName}";
                completionRequest.MaxTokens = 200;
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipeDescription = completion.Text.TrimStart('\n');
                }

                //Generate Author Name
                completionRequest.Prompt = $"Please generate a persons name only. No quotation marks.";
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipeAuthorName = completion.Text.TrimStart('\n');
                }
                recipeAuthorNameTextBox.Text = RecipeAuthorName;

                //Generate Serving Size
                completionRequest.Temperature = 0.0;
                completionRequest.Prompt = $"Generate ONLY an integer between 1 and 15 for how may people {RecipeName} can serve";
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipeServingSize = completion.Text.TrimStart('\n');
                }
                servingSizeTextBox.Text = RecipeServingSize;

                //Generate Preparation Time
                completionRequest.Prompt = $"Give me ONLY a positive integer between 20 and 60 for how long it takes to make {RecipeName}. DO NOT PUT ANY STRING TEXT. INTEGER ONLY";
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipePreparationTime = completion.Text.TrimStart('\n');
                }
                preparationTimeTextBox.Text = RecipePreparationTime;

                //Generate Number of Ingredients
                completionRequest.Prompt = $"Respond ONLY with a positive integer for how many ingredients are needed to make {RecipeName}";
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipeIngredientQuantity = completion.Text.TrimStart('\n');
                }
                ingredientQuantityTextBox.Text = RecipeIngredientQuantity;

                //Generate Number of Steps
                completionRequest.Prompt = $"Pretend you are a number generator. Generate ONLY a single integer for how many steps are needed to make {RecipeName}. DO NOT PUT ANY STRING TEXT.";
                completions = await OpenAPI.Completions.CreateCompletionAsync(completionRequest);

                foreach (var completion in completions.Completions)
                {
                    RecipeNumberOfSteps = completion.Text.TrimStart('\n');

                }
                numberOfStepsTextBox.Text = RecipeNumberOfSteps;

                describeRecipe.Document.Blocks.Clear();
                describeRecipe.Document.Blocks.Add(new Paragraph(new Run(RecipeDescription)));
            }
            else
            {
                showMessageCustom("Attention!","You need an internet connection to use this feature!");
            }
        }

        ////Check for internet connection
        public bool IsConnectedToInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "platform.openai.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
