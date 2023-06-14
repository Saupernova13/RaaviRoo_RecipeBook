/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauraav_POE_Part_2
{
    internal class externalMethods
    {
        ////Method that will warn the user of a high calorie count via a delegate
         public delegate void caloryWarningDelegate(RecipeComplete currentRecipeDel);
         public void caloryWarning(RecipeComplete currentRecipe)
        {
            if (currentRecipe.totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWARNING: This recipe has over 300 calories! Proceed with caution, keeping health in mind.");
            }
        }
    }
}