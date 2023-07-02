/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sauraav_POE_Part_2.externalMethods;

namespace Sauraav_POE_Part_2
{
    internal class RecipeActions
    {/*
        public int recipeNumber = 0;

        ////Checks if the entered recipe number is valid and prints the recipe details if valid
        public int checkIfValidIntAndPrint(List<RecipeComplete> parsedRecipe, RecipeComplete activeRecipe)
        {
            int parseVar = 0;
            try
            {
                Console.WriteLine("\nPlease enter the NUMBER of the recipe you want to work with below:");
                bool loopTrigger = true;
                if (parsedRecipe.Any())
                {
                    while (loopTrigger)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out parseVar) && parseVar >= 1 && parseVar <= parsedRecipe.Count)
                        {
                            loopTrigger = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid RECIPE NUMBER! Please enter a valid RECIPE NUMBER:");
                        }
                    }
                    activeRecipe = parsedRecipe[parseVar - 1];
                    activeRecipe.printRecipeDetails();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nYou have NO recipes to PRINT.\n\n");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no recipes to check details for.");
                Console.ForegroundColor = ConsoleColor.White;

            }

            return (parseVar - 1);
        }*/
    }
}