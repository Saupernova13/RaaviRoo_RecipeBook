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
    {
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
        }
        ////Populates the recipe details by prompting the user for input
        public void populateRecipe(List<RecipeComplete> parsedRecipe)
        {
            recipeNumber = parsedRecipe.Count + 1;
            RecipeComplete currentRecipe = new RecipeComplete();
            ///Prompting user for recipe details
            currentRecipe.recipeNumber = recipeNumber;
            dynamic parseVar = 0;
            bool loopTrigger = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease ENTER in a recipe NAME below:");
            Console.ForegroundColor = ConsoleColor.White;
            currentRecipe.recipeName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nPlease ENTER in a recipe DESCRIPTION below:");
            Console.ForegroundColor = ConsoleColor.White;
            currentRecipe.recipeDescription = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease ENTER in an AUTHOR for this recipe below:");
            Console.ForegroundColor = ConsoleColor.White;
            currentRecipe.recipeAuthor = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease ENTER in a SERVING SIZE for this recipe below:");
            //While loop to ensure user enters in a valid number
            while (loopTrigger)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    currentRecipe.recipeServingSize = Int32.Parse(Console.ReadLine());
                    loopTrigger = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease ENTER in a valid NUMBER for the serving size:");
                }

            }
            loopTrigger = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease ENTER in the total TIME it takes to make this recipe below in MINUTES:");
            while (loopTrigger)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    currentRecipe.recipeTotalTime = Int32.Parse(Console.ReadLine());
                    loopTrigger = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease ENTER in a valid amount of TIME it takes to make the recipe below:");
                }

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlease ENTER in HOW MANY Ingredients the recipe below has:");
            loopTrigger = true;
            while (loopTrigger)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    currentRecipe.amountOfIngredients = Int32.Parse(Console.ReadLine());
                    loopTrigger = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease ENTER in a valid AMOUNT of Ingredients it takes to make the recipe below:");
                }

            }
            for (int i = 0; i < currentRecipe.amountOfIngredients; i++)
            {
                Ingredient activeIngredient = new Ingredient();
                int amount = i + 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPlease ENTER in the NAME of Ingredient #{amount} below:");
                Console.ForegroundColor = ConsoleColor.White;
                activeIngredient.name = (Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPlease ENTER in the NUMBER of CALORIES that Ingredient #{amount} contains below:");
                loopTrigger = true;
                while (loopTrigger)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        parseVar = Double.Parse(Console.ReadLine());
                        loopTrigger = false;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease ENTER in a VALID NUMBER of CALORIES for the ingredient below:");
                    }
                }
                activeIngredient.calories = parseVar;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPlease ENTER in the FOOD GROUP that Ingredient #{amount} belongs to below:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n1)\tStarchy foods\n2)\tVegetables and fruits\n3)\tDry beans, peas, lentils and soya\n4)\tChicken, fish, meat and eggs\n5)\tMilk and dairy products\n6)\tFats and oils\n7)\tWater\n");
                Console.ForegroundColor = ConsoleColor.White;
                string foodGroup = "";
                loopTrigger = true;
                while (loopTrigger)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            foodGroup = "Starchy foods";
                            loopTrigger = false;
                            break;
                        case "2":
                            foodGroup = "Vegetables and fruits";
                            loopTrigger = false;
                            break;
                        case "3":
                            foodGroup = "Dry beans, peas, lentils and soya";
                            loopTrigger = false;
                            break;
                        case "4":
                            foodGroup = "Chicken, fish, meat and eggs";
                            loopTrigger = false;
                            break;
                        case "5":
                            foodGroup = "Milk and dairy products";
                            loopTrigger = false;
                            break;
                        case "6":
                            foodGroup = "Fats and oils";
                            loopTrigger = false;
                            break;
                        case "7":
                            foodGroup = "Water";
                            loopTrigger = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease ENTER in a VALID FOODGROUP for the ingredient below by typing in the corresponding number.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                activeIngredient.foodGroup = foodGroup;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlease ENTER in the UNIT OF MEASUREMENT of the above ingredient that will be used below\nby typing in the corresponding number.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYour options are:\n1)\tGrams\n2)\tMiligrams\n3)\tKilograms\n4)\tMililetres\n5)\tLitres\n6)\tTablespoons\n7)\tTeaspoons\n8)\tCups\n9)\tPieces");
                Console.ForegroundColor = ConsoleColor.White;
                string unitOfMeasurement = "";
                loopTrigger = true;
                while (loopTrigger)
                {
                    string optionMeasurement = Console.ReadLine();
                    switch (optionMeasurement)
                    {
                        case "1":
                            unitOfMeasurement = "Grams";
                            loopTrigger = false;
                            break;
                        case "2":
                            unitOfMeasurement = "Miligrams";
                            loopTrigger = false;
                            break;
                        case "3":
                            unitOfMeasurement = "Kilograms";
                            loopTrigger = false;
                            break;
                        case "4":
                            unitOfMeasurement = "Mililetres";
                            loopTrigger = false;
                            break;
                        case "5":
                            unitOfMeasurement = "Litres";
                            loopTrigger = false;
                            break;
                        case "6":
                            unitOfMeasurement = "Tablespoons";
                            loopTrigger = false;
                            break;
                        case "7":
                            unitOfMeasurement = "Teaspoons";
                            loopTrigger = false;
                            break;
                        case "8":
                            unitOfMeasurement = "Cups";
                            loopTrigger = false;
                            break;
                        case "9":
                            unitOfMeasurement = "Pieces";
                            loopTrigger = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease ENTER in a VALID unit of measurement for the ingredient below by typing in the corresponding number.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                activeIngredient.measurementUnit = unitOfMeasurement;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlease ENTER in the QUANTITY the above Ingredient that will be used below:");
                loopTrigger = true;
                while (loopTrigger)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        parseVar = Int32.Parse(Console.ReadLine());
                        loopTrigger = false;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease ENTER in a VALID QUANTITY of the ingredient it takes to make the recipe below:");
                    }
                }
                activeIngredient.quantity = parseVar;
                activeIngredient.quantityOG = activeIngredient.quantity;
                currentRecipe.ingredients.Add(activeIngredient);
                currentRecipe.totalCalories = currentRecipe.returnTotalCalories(currentRecipe.ingredients);
                externalMethods eM = new externalMethods();
                caloryWarningDelegate runDelegate = new caloryWarningDelegate(eM.caloryWarning);
                runDelegate.Invoke(currentRecipe);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("\nPlease ENTER in HOW MANY steps this recipe will have below:");
            parseVar = 0;
            loopTrigger = true;
            while (loopTrigger)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    parseVar = Int32.Parse(Console.ReadLine());
                    loopTrigger = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease ENTER in a valid NUMBER OF STEPS for this recipe below:");
                }
            }
            currentRecipe.stepsToRecipe = (int)parseVar;
            for (int i = 0; i < currentRecipe.stepsToRecipe; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlease DESCRIBE step number {0} in the recipe below:", i + 1);
                Console.ForegroundColor = ConsoleColor.White;
                currentRecipe.descriptionOfSteps.Add(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;

            parsedRecipe.Add(currentRecipe);
            Console.WriteLine("\n\nA recipe has been CREATED successfully!");
            mainClass.bootMessage();
        }
    }
}