/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauraav_POE_Part_2
{
    class Recipe
    {
        ////Variables needed in class for recipe metadata
        public string recipeDescription;
        public string recipeAuthor;
        public int recipeServingSize;
        public double recipeTotalTime;
        public int stepsToRecipe;
        public int amountOfIngredients;
        public double scaledResult;
        ////Lists needed in class to store recipe details
        public List<string> descriptionOfSteps = new List<string>();
        public List<Ingredient> ingredients = new List<Ingredient>();
    }
}