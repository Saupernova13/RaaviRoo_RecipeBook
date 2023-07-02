/////Sauraav Jayrajh 
///ST10024620
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauraav_POE_Part_2
{
    ////Class were ingredient objects derive from
    public class Ingredient
    {
        public string name { get; set; }
        public double quantity { get; set; }
        public double quantityOG { get; set; }
        public string measurementUnit { get; set; }
        public string foodGroup { get; set; }
        public double calories { get; set; }

        public Ingredient(string name, double quantity, double quantityOG,  string measurementUnit, string foodGroup, double calories)
        {
            this.name = name;
            this.quantity = quantity;
            this.quantityOG = quantityOG;
            this.measurementUnit = measurementUnit;
            this.foodGroup = foodGroup;
            this.calories = calories;
        }
    }



}