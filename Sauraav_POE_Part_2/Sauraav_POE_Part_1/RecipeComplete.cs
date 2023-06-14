/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sauraav_POE_Part_2
{
    //Inherits from Recipe class, and is used to store all the details of a recipe
    class RecipeComplete : Recipe
    {
        public string recipeName;
        public int recipeNumber;
        public double totalCalories;
        ////Method that prints out the recipe details
        public void printRecipeDetails()
        {
            Console.Clear();
            RecipeActions.printBorder();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string people;
            if (recipeServingSize == 1)
            {
                people = "person";
            }
            else
            {
                people = "people";
            }

            Console.WriteLine("\nRecipe Name:\t\t{0}", recipeName);
            Console.WriteLine("\nRecipe Number:\t\t{0}", recipeNumber);
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("\nRecipe Description:\n{0}", recipeDescription);
            Console.WriteLine("\nRecipe Author:\t\t{0}", recipeAuthor);
            Console.WriteLine("\nRecipe Serving Size:\t{0} {1}", recipeServingSize, people);
            Console.WriteLine("\nRecipe Total Time:\t{0}", recipeTotalTime);
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("\nRecipe Ingredients:\t");
            Console.WriteLine("__________________________________________________");
            int ingredientCount = 0;
            foreach (var ingredient in ingredients)
            {
                ingredientCount++;
                Console.WriteLine("\nIngredient {0})\t", ingredientCount);
                Console.WriteLine("\nIngredient Name=\t{0}", ingredient.name);
                Console.WriteLine("\nIngredient Calories=\t{0}", ingredient.calories);
                Console.WriteLine("\nIngredient Food Group=\t{0}", ingredient.foodGroup);
                Console.WriteLine("\nIngredient Quantity=\t{0}", ingredient.quantity);
                Console.WriteLine("\nIngredient Unit=\t{0}", ingredient.measurementUnit);

            }
            Console.WriteLine("__________________________________________________");
            int stepCount = 0;
            Console.WriteLine("\nRecipe Steps:\t");
            foreach (var step in descriptionOfSteps)
            {
                Console.WriteLine("\nStep {0})\t", stepCount + 1);
                Console.WriteLine("\n{0}", step);
                stepCount++;
            }
        }
        public void printAllRecipeDetails()
        {
            Console.Clear();
            RecipeActions.printBorder();
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
                RecipeActions.printBorder();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nYou have NO recipe to PRINT.\n\n");
            }
            mainClass.bootMessage();
        }
        ////Method that allows the user to scale the recipe
        public void scaleRecipe()
        {
            Console.Clear();
            RecipeActions.printBorder();
            if (ingredients.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlease ENTER in the VALUE of by which you would like to scale the recipe.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYour options are:\n1)\t0.5 (Half)\n2)\t2 (Double)\n3)\t3 (Triple)\n");
                Console.ForegroundColor = ConsoleColor.White;
                string scaleValueString;
                double scaleValue = 0;
                bool loopTrigger = true;
                while (loopTrigger)
                {
                    scaleValueString = Console.ReadLine();
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease ENTER in a VALID OPTION for the SCALING the below by typing in the corresponding number.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                }

                for (int i = 0; i < ingredients.Count; i++)
                {
                    ingredients[i].quantity = ingredients[i].quantity * scaleValue;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\nAll receipe ingredient quantities have been SCALED to the value you entered.\n\n");
            }
            else
            {
                RecipeActions.printBorder();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nYou have NO recipe to SCALE.\n\n");

            }

        }
        ////Method lets user delete the recipe

        ////Method lets user reset the recipe to default values
        public void resetIngredientQuantities()
        {
            Console.Clear();
            RecipeActions.printBorder();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (ingredients.Any())
            {
                RecipeActions.printBorder();
                // listOfIngredientQuantities = listOfIngredientQuantitiesOG;
                for (int i = 0; i < ingredients.Count; i++)
                {
                    ingredients[i].quantity = ingredients[i].quantityOG;
                }
                Console.WriteLine("\n\nAll receipe ingredient quantities have been RESET to the INITIAL values you entered.\n\n");

            }
            else
            {
                RecipeActions.printBorder();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nYou have NOT entered in a recipe to reset.\n\n");

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