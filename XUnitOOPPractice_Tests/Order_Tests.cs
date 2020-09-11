using System;
using Xunit;
using XUnitOOPPractice;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NuGet.Frameworks;
using System.Drawing;

namespace XUnitOOPPractice_Tests
{
    public class Order_Tests
    {
        // Add a chicken strips to the order.
        [Fact]
        public void Order_AddItem_ChickenStrips()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem chicken = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.AddItem(chicken);

            // Assert
            // Assert that the first item in the order is the chicken.
            Assert.Equal(chicken, myOrder.Items[sizeBefore]);
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore + 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(chicken.Price, myOrder.Total);
        }


        // Add a french fries to the order.
        [Fact]
        public void Order_AddItem_FrenchFries()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem chicken = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            FoodItem frenchFries = new FoodItem()
            {
                Type = FoodItem.TypeValue.FrenchFries,
                Price = 1.50
            };
            myOrder.AddItem(chicken);
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.AddItem(frenchFries);

            // Assert
            // Assert that the second item in the order is the fries.
            Assert.Equal(frenchFries, myOrder.Items[sizeBefore]);
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore + 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(chicken.Price + frenchFries.Price, myOrder.Total);
        }

        // Add a drink to the order.
        [Fact]
        public void Order_AddItem_Drink()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem drink = new FoodItem()
            {
                Type = FoodItem.TypeValue.Drink,
                Price = 2.50
            };
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.AddItem(drink);

            // Assert
            // Assert that the first item in the order is the drink.
            Assert.Equal(drink, myOrder.Items[sizeBefore]);
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore + 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(drink.Price, myOrder.Total);
        }

        // Add a combo to the order (as an arg).
        [Fact]
        public void Order_AddItem_ComboArg()
        {
            // Arrange
            Order myOrder = new Order();
            Combo combo = new Combo()
            {
                ComboItems = new List<FoodItem>()
                {
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.ChickenStrips,
                        Price = 2.50
                    },
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.FrenchFries,
                        Price = 1.50
                    },
                    new FoodItem()
                    {
                        Type = FoodItem.TypeValue.Drink,
                        Price = 1.00
                    }
                }
            };
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.AddItem(combo);

            // Assert
            // Assert that the first item in the order is the combo.
            Assert.Equal(combo, myOrder.Items[sizeBefore]);
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore + 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(combo.Price, myOrder.Total);

        }


        // Add a combo to the order (as 3 items).
        [Fact]
        public void Order_AddItem_ComboPiecemeal()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem chicken = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            FoodItem fries = new FoodItem()
            {
                Type = FoodItem.TypeValue.FrenchFries,
                Price = 1.50
            };
            FoodItem drink = new FoodItem()
            {
                Type = FoodItem.TypeValue.Drink,
                Price = 1.00
            };
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.AddItem(chicken);
            myOrder.AddItem(fries);
            myOrder.AddItem(drink);

            // Assert
            // Assert that the first item in the order is the combo.
            Assert.Equal(typeof(Combo), myOrder.Items[sizeBefore].GetType());
            // Assert that our combo contains our items.
            Assert.Contains(chicken, ((Combo)myOrder.Items[sizeBefore]).ComboItems);
            Assert.Contains(fries, ((Combo)myOrder.Items[sizeBefore]).ComboItems);
            Assert.Contains(drink, ((Combo)myOrder.Items[sizeBefore]).ComboItems);
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore + 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal((chicken.Price + fries.Price + drink.Price) * 0.8, myOrder.Total);

        }


        // Remove a single item from the order.
        [Fact]
        public void Order_RemoveItem_FoodItem()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem chicken = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            FoodItem frenchFries = new FoodItem()
            {
                Type = FoodItem.TypeValue.FrenchFries,
                Price = 1.50
            };
            myOrder.AddItem(chicken);
            myOrder.AddItem(frenchFries);
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.RemoveItem();

            // Assert
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore - 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(chicken.Price, myOrder.Total);
        }

        // Remove a combo from the order.
        [Fact]
        public void Order_RemoveItem_Combo()
        {
            // Arrange
            Order myOrder = new Order();
            FoodItem chicken = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            FoodItem chicken2 = new FoodItem()
            {
                Type = FoodItem.TypeValue.ChickenStrips,
                Price = 2.50
            };
            FoodItem fries = new FoodItem()
            {
                Type = FoodItem.TypeValue.FrenchFries,
                Price = 1.50
            };
            FoodItem drink = new FoodItem()
            {
                Type = FoodItem.TypeValue.Drink,
                Price = 1.00
            };
            myOrder.AddItem(chicken);
            myOrder.AddItem(chicken2);
            myOrder.AddItem(fries);
            myOrder.AddItem(drink);
            int sizeBefore = myOrder.ItemCount;

            // Act
            myOrder.RemoveItem();

            // Assert
            // Assert that the size of the order went up by one.
            Assert.Equal(sizeBefore - 1, myOrder.ItemCount);
            // Check that the order total is correct.
            Assert.Equal(chicken2.Price, myOrder.Total);

        }

    }
}

//In class practice solution by James: @link https://github.com/TECHCareers-by-Manpower/4.1-CSharp-XUnit/tree/Sep09Practice/CSharpXUnit_Tests
