/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sauraav_POE_Part_2
{
    //Inherits from Recipe class, and is used to store all the details of a recipe
    public class RecipeComplete : Recipe
    {
        public string recipeName;
        public int recipeNumber;
        public double totalCalories;
        ////Method that prints out the recipe details
        public string printRecipeDetails()
        {
            StringBuilder sb = new StringBuilder();
            string people = (recipeServingSize == 1) ? "person" : "people";

            sb.AppendLine($"\nRecipe Name:\t\t{recipeName}");
            sb.AppendLine($"\nRecipe Number:\t\t{recipeNumber}");
            sb.AppendLine("__________________________________________________");
            sb.AppendLine($"\nRecipe Description:\n{recipeDescription}");
            sb.AppendLine($"\nRecipe Author:\t\t{recipeAuthor}");
            sb.AppendLine($"\nRecipe Serving Size:\t{recipeServingSize} {people}");
            sb.AppendLine($"\nRecipe Total Time:\t{recipeTotalTime}");
            sb.AppendLine("__________________________________________________");
            sb.AppendLine("\nRecipe Ingredients:\t");
            sb.AppendLine("__________________________________________________");

            int ingredientCount = 0;
            foreach (var ingredient in ingredients)
            {
                ingredientCount++;
                sb.AppendLine($"\nIngredient {ingredientCount})\t");
                sb.AppendLine($"\nIngredient Name=\t{ingredient.name}");
                sb.AppendLine($"\nIngredient Calories=\t{ingredient.calories}");
                sb.AppendLine($"\nIngredient Food Group=\t{ingredient.foodGroup}");
                sb.AppendLine($"\nIngredient Quantity=\t{ingredient.quantity}");
                sb.AppendLine($"\nIngredient Unit=\t{ingredient.measurementUnit}");
            }

            sb.AppendLine("__________________________________________________");
            int stepCount = 0;
            sb.AppendLine("\nRecipe Steps:\t");
            foreach (var step in descriptionOfSteps)
            {
                stepCount++;
                sb.AppendLine($"\nStep {stepCount})\t");
                sb.AppendLine($"\n{step}");
            }

            return sb.ToString();
        }
        public void printAllRecipeDetails()
        {
            if (mainClass.allRecipes.Any())
            {
                List<RecipeComplete> sortedRecipes = mainClass.allRecipes.OrderBy(recipe => recipe.recipeName).ToList();
                foreach (RecipeComplete forEachRecipe in sortedRecipes)
                {
                    forEachRecipe.printRecipeDetails();
                }
            }
            else
            {
                MessageBox.Show("You have NO recipe to PRINT.");
            }
        }
        ////Method that allows the user to scale the recipe
        public void scaleRecipe(dynamic input)
        {
            if (ingredients.Any())
            {
                string scaleValueString;
                double scaleValue = 0;
                bool loopTrigger = true;
                while (loopTrigger)
                {
                    scaleValueString = input;
                    switch (scaleValueString)
                    {
                        case "1":
                            scaleValue = 0.5;
                            loopTrigger = false;
                            break;
                        case "2":
                            scaleValue = 2;
                            loopTrigger = false;
                            break;
                        case "3":
                            scaleValue = 3;
                            loopTrigger = false;
                            break;
                        default:
                            MessageBox.Show("Please ENTER in a VALID OPTION for the SCALING the below by typing in the corresponding number.");
                            break;
                    }

                }

                for (int i = 0; i < ingredients.Count; i++)
                {
                    ingredients[i].quantity = ingredients[i].quantity * scaleValue;
                }
                MessageBox.Show("All receipe ingredient quantities have been SCALED to the value you entered.");
            }
            else
            {
                MessageBox.Show("You have NO recipe to SCALE.");

            }

        }

        ////Method lets user reset the recipe to default values
        public void resetIngredientQuantities()
        {
            if (ingredients.Any())
            {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    ingredients[i].quantity = ingredients[i].quantityOG;
                }
                MessageBox.Show("All receipe ingredient quantities have been RESET to the INITIAL values you entered.");

            }
            else
            {
                MessageBox.Show("You have NO recipe to RESET.");
            }
        }
        ////Method contains logic for the delete recipe method
        public double returnTotalCalories(List<Ingredient> listOfIng)
        {
            double totalCalories = 0;
            foreach (Ingredient ingredient in listOfIng)
            {
                totalCalories += ingredient.calories;
            }
            return totalCalories;
        }
    }
}