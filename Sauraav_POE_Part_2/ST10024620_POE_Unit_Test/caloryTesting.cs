/////Sauraav Jayrajh 
///ST10024620
using System.Collections.Generic;
using NUnit.Framework;
using Sauraav_POE_Part_2;

namespace ST10024620_POE_Unit_Test
{
    ////Class that will run the unit tests
    [TestFixture]
    public class ClassTestingTests
    {
        private classTesting classTesting;
        private List<Ingredient> ingredientList;

        [SetUp]
        public void Setup()
        {
            classTesting = new classTesting();
            ingredientList = new List<Ingredient>
            {
                new Ingredient { name = "Chocolate", calories = 100 },
                new Ingredient { name = "Milk", calories = 200 },
                new Ingredient { name = "Flour", calories = 150 }
            };
        }

        [Test]
        public void TestReturnTotalCalories()
        {
            // Act
            double totalCalories = classTesting.returnTotalCalories(ingredientList);

            // Assert
            double expectedTotalCalories = 450;
            Assert.AreEqual(expectedTotalCalories, totalCalories);
        }
    }
}