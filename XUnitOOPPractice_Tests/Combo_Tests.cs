using System;
using Xunit;
using XUnitOOPPractice;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NuGet.Frameworks;


namespace XUnitOOPPractice_Tests
{
    public class Combo_Tests
    {
        // Test the price property of the Combo.
        [Theory,
        InlineData(1, 1, 1),
        InlineData(1, 2, 3),
        InlineData(6, 3, 2)]
        public void Combo_Price_Get(double chickenValue, double friesValue, double drinkValue)
        {
            // Arrange
            Combo myCombo = new Combo()
            {
                ComboItems = new List<FoodItem>()
                {
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.ChickenStrips,
                        Price = chickenValue
                    },
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.FrenchFries,
                        Price = friesValue
                    },
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.Drink,
                        Price = drinkValue
                    }
                }
            };


            // Act
            double output = myCombo.Price;

            // Assert
            Assert.Equal(Math.Round((chickenValue + friesValue + drinkValue) * myCombo.Discount, 3), output);
        }
    }
}


//In class practice solution by James: @link https://github.com/TECHCareers-by-Manpower/4.1-CSharp-XUnit/tree/Sep09Practice/CSharpXUnit_Tests