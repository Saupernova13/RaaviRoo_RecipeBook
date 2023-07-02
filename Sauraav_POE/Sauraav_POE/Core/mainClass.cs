/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sauraav_POE_Part_2
{
    class mainClass
    {
        //List handles storage multiple recipes, actice recipe keeps current recipe in memory
        public static List<RecipeComplete> allRecipes = new List<RecipeComplete>();
        static RecipeComplete activeRecipe = new RecipeComplete();
        public static bool justStarted = true;
      
        public static void bootMessage()
        {
            if (allRecipes.Count == 0)
            {
                justStarted = true;
            }
            else
            {
                justStarted = false;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\nYou currently have {allRecipes.Count} recipe(s) in your recipe book.\n");
            RecipeActions startAction = new RecipeActions();
            bool trigger = true;
            if (justStarted)
            {
                Console.WriteLine($"\n\nBefore you get started, you need to have at least ONE Recipe in your book.\nPlease enter in your first Recipe\n");
                startAction.populateRecipe(allRecipes);
                justStarted = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPlease SELECT an operation from below by entering in the corresponding number:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n1)\tENTER in a Recipe\n2)\tDISPLAY A Recipe\n3)\tDISPLAY ALL Recipes\n4)\tCALCULATE Calories In Recipe\n5)\tSCALE Recipe\n6)\tRESET To Default Quantities\n7)\tDELETE Recipe\n8)\tEXIT Program");
                Console.ForegroundColor = ConsoleColor.White;
                while (trigger)
                {
                    string inputVal = Console.ReadLine();
                    int index = 0;
                    switch (inputVal)
                    {
                        case "1":
                            Console.Clear();
                            startAction.populateRecipe(allRecipes);
                            trigger = false;
                            break;
                        case "2":
                            Console.Clear();
                            index = startAction.checkIfValidIntAndPrint(allRecipes, activeRecipe);
                            bootMessage();
                            trigger = false;
                            break;
                        case "3":
                            Console.Clear();
                            activeRecipe.printAllRecipeDetails();
                            trigger = false;
                            break;
                        case "4":
                            Console.Clear();
                            index = startAction.checkIfValidIntAndPrint(allRecipes, activeRecipe);
                            activeRecipe = allRecipes[index];
                            Console.WriteLine("\n\nThe total calories in this recipe is: " + activeRecipe.totalCalories);
                            bootMessage();
                            trigger = false;
                            break;
                        case "5":
                            Console.Clear();
                            index = startAction.checkIfValidIntAndPrint(allRecipes, activeRecipe);
                            activeRecipe = allRecipes[index];
                            //activeRecipe.scaleRecipe();
                            allRecipes[index] = activeRecipe;
                            bootMessage();
                            trigger = false;
                            break;
                        case "6":
                            Console.Clear();
                            index = startAction.checkIfValidIntAndPrint(allRecipes, activeRecipe);
                            activeRecipe = allRecipes[index];
                            activeRecipe.resetIngredientQuantities();
                            allRecipes[index] = activeRecipe;
                            bootMessage();
                            trigger = false;
                            break;
                        case "7":
                            bool ifDeleteConfirm = false;
                            Console.Clear();
                            index = startAction.checkIfValidIntAndPrint(allRecipes, activeRecipe);
                            Console.Clear();
                          //  RecipeActions.printBorder();
                            Console.WriteLine($"Are you sure you want to delete Recipe {index + 1}?\nRespond by entering in the corresponding number:\n1)\tNO\n2)\tYES");
                            Console.ForegroundColor = ConsoleColor.White;
                            string answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "1":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("The Operation has been aborted.");
                                    break;
                                case "2":
                                  allRecipes.RemoveAt(index);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Recipe {index + 1} has been delteded.\nNote that other recipes have moved down a number in the recipe book.", index);
                                    break;
                                default:
                                    break;
                            }
                            bootMessage();
                            trigger = false;
                            break;

                        case "8":
                            Console.Clear();
                            Environment.Exit(0);
                            trigger = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please ENTER in a VALID number from the list above");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}