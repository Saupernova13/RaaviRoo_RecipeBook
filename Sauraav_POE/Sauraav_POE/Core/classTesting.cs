/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauraav_POE_Part_2
{
    public class classTesting
    {
        ////Method that will be tested
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