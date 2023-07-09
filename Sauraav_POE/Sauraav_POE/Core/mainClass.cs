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
    }
}